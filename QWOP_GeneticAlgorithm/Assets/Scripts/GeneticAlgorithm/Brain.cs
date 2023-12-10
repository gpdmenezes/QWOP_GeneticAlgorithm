using QWOP_GA.Runtime;
using UnityEngine;

namespace QWOP_GA.GeneticAlgorithm
{

    [RequireComponent(typeof(RunnerController))]
    public class Brain : MonoBehaviour
    {
        [SerializeField] private RunnerController runnerController;
        [SerializeField] private Transform torso;
        [SerializeField] private Transform rightThigh;
        [SerializeField] private Transform leftThigh;
        [SerializeField] private Transform rightCalf;
        [SerializeField] private Transform leftCalf;

        private DNA dna;
        private int movementSequencesSize = 4;
        private MovementSequence[] movementSequences;
        private int currentMovementStep = 0;
        private float lastMovementTime = 0;
        private float distanceWalked = 0;
        private bool isAlive = true;

        public void Initialize ()
        {
            dna = new DNA(movementSequencesSize);
            SetupStartingRotation();
            movementSequences = dna.GetMovementSequence();
            currentMovementStep = 0;
            distanceWalked = 0;
            lastMovementTime = float.NegativeInfinity;
            isAlive = true;
        }

        private void SetupStartingRotation()
        {
            rightThigh.eulerAngles = new Vector3(0, 0, dna.GetGeneValue("rightThighStartingRotation"));
            leftThigh.eulerAngles = new Vector3(0, 0, dna.GetGeneValue("leftThighStartingRotation"));
            rightCalf.eulerAngles = new Vector3(0, 0, dna.GetGeneValue("rightCalfStartingRotation"));
            leftCalf.eulerAngles = new Vector3(0, 0, dna.GetGeneValue("leftCalfStartingRotation"));
        }

        public void OnDeath ()
        {
            isAlive = false;
        }

        private void Update ()
        {
            if (!isAlive) return;

            distanceWalked = Vector3.Distance(transform.position, new Vector3(50, 0, 0));

            if (Time.time >= lastMovementTime + movementSequences[currentMovementStep].nextMovementDelay)
            {
                OnNextMove();
            }
        }

        private void OnNextMove ()
        {
            lastMovementTime = Time.time;
            int movementType = movementSequences[currentMovementStep].movementType;
            float movementDuration = movementSequences[currentMovementStep].movementDuration;
            runnerController.StartMovement(movementType, movementDuration);
            currentMovementStep++;
        }

    }

}