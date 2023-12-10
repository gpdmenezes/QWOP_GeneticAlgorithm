using UnityEngine;

namespace QWOPGeneticAlgorithm {

    public class RunnerController : MonoBehaviour
    {
        [SerializeField] private float hingeSpeed = 40f;

        [SerializeField] private HingeJoint2D rightThigh;
        [SerializeField] private HingeJoint2D leftThigh;
        [SerializeField] private HingeJoint2D rightCalf;
        [SerializeField] private HingeJoint2D leftCalf;

        private JointMotor2D rightThighMotor;
        private JointMotor2D leftThighMotor;
        private JointMotor2D rightCalfMotor;
        private JointMotor2D leftCalfMotor;

        private void Awake ()
        {
            rightThighMotor = rightThigh.motor;
            leftThighMotor = leftThigh.motor;
            rightCalfMotor = rightCalf.motor;
            leftCalfMotor = leftCalf.motor;
        }

        private void Update ()
        {
            TestFunction();
            return;
            ProcessThighInput();
            ProcessCalfInput();
        }

        private void TestFunction ()
        {

        }

        private void ProcessThighInput ()
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                MoveThighs(true);
                return;
            }
            
            if (Input.GetKeyDown(KeyCode.W))
            {
                MoveThighs(false);
                return;
            }

            rightThigh.useMotor = false;
            leftThigh.useMotor = false;
        }

        private void ProcessCalfInput ()
        {
            if (Input.GetKeyDown(KeyCode.O))
            {
                MoveCalfs(true);
                return;
            }
            
            if (Input.GetKeyDown(KeyCode.P))
            {
                MoveCalfs(false);
                return;
            }

            rightCalf.useMotor = false;
            leftCalf.useMotor = false;
        }

        private void MoveThighs (bool isRight)
        {
            rightThigh.useMotor = true;
            leftThigh.useMotor = true;

            if (isRight)
            {
                rightThighMotor.motorSpeed = hingeSpeed;
                leftThighMotor.motorSpeed = -hingeSpeed;
            } else
            {
                rightThighMotor.motorSpeed = -hingeSpeed;
                leftThighMotor.motorSpeed = hingeSpeed;
            }
            
            rightThigh.motor = rightThighMotor;
            leftThigh.motor = leftThighMotor;
        }

        private void MoveCalfs (bool isRightCalf)
        {
            rightCalf.useMotor = true;
            leftCalf.useMotor = true;

            if (isRightCalf)
            {
                rightCalfMotor.motorSpeed = hingeSpeed;
                leftCalfMotor.motorSpeed = -hingeSpeed;
            }
            else
            {
                rightCalfMotor.motorSpeed = -hingeSpeed;
                leftCalfMotor.motorSpeed = hingeSpeed;
            }

            rightCalf.motor = rightThighMotor;
            leftCalf.motor = leftThighMotor;
        }

    }

}