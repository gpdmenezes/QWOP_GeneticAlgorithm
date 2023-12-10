using UnityEngine;

namespace QWOP_GA.Runtime 
{
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

        private bool isMoving = false;
        private int currentMovementType = 0;
        private float currentMovementDuration = 0;
        private float currentMovementStartTime = 0;

        private void Awake ()
        {
            rightThighMotor = rightThigh.motor;
            leftThighMotor = leftThigh.motor;
            rightCalfMotor = rightCalf.motor;
            leftCalfMotor = leftCalf.motor;
        }

        public void StartMovement (int movementType, float movementDuration)
        {
            currentMovementType = movementType;
            currentMovementDuration = movementDuration;
            currentMovementStartTime = Time.time;
            isMoving = true;
        }

        private void Update ()
        {
            if (!isMoving) return;

            if (Time.time >= currentMovementStartTime + currentMovementDuration)
            {
                isMoving = false;
                return;
            }

            switch (currentMovementType)
            {
                case 0:
                    MoveThighs(true);
                    StopMovingCalfs();
                    break;
                case 1:
                    MoveThighs(false);
                    StopMovingCalfs();
                    break;
                case 2:
                    MoveCalfs(true);
                    StopMovingThighs();
                    break;
                case 3:
                    MoveCalfs(false);
                    StopMovingThighs();
                    break;
            }
        }

        private void MoveThighs (bool isRightThigh)
        {
            rightThigh.useMotor = true;
            leftThigh.useMotor = true;

            if (isRightThigh)
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

            rightCalf.motor = rightCalfMotor;
            leftCalf.motor = leftCalfMotor;
        }

        private void StopMovingThighs()
        {
            rightThigh.useMotor = false;
            leftThigh.useMotor = false;
        }

        private void StopMovingCalfs()
        {
            rightCalf.useMotor = false;
            leftCalf.useMotor = false;
        }
    }
}