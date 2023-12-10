using QWOP_GA.Runtime;
using UnityEngine;

namespace QWOP_GA.GeneticAlgorithm
{

    [RequireComponent(typeof(RunnerController))]
    public class Brain : MonoBehaviour
    {
        [SerializeField] private RunnerController runnerController;
        [SerializeField] private Transform torsoReference;

        private DNA dna;
        private int dnaLength = 1;
        private float distanceWalked = 0;
        private bool isAlive = true;

        private int[] movementSequence;
        private int currentMovementStep = 0;
        private float lastMoveTime = 0;

        public void Initialize ()
        {
            dna = new DNA(dnaLength, 6);
            distanceWalked = 0;
            currentMovementStep = 0;
            SetupMovementSequence();
            isAlive = true;
        }

        public void OnDeath ()
        {
            isAlive = false;
        }

        private void FixedUpdate ()
        {
            if (!isAlive) return;

            distanceWalked = Vector3.Distance(Vector3.zero, torsoReference.position);

            

        }

        private void OnNextMove ()
        {
            lastMoveTime = Time.time;
            int movementType = movementSequence[currentMovementStep];
            runnerController.Move(movementType);
            currentMovementStep++;
        }

        private void SetupMovementSequence ()
        {
            movementSequence = new int[4];
            for (int i = 0; i < movementSequence.Length; i++)
            {
                movementSequence[i] = dna.GetGeneValue(i);
            }
        }

    }

}