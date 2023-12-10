using System;

namespace QWOP_GA.GeneticAlgorithm
{
    [Serializable]
    public class MovementSequence
    {
        public int movementType;
        public float movementDuration;
        public float nextMovementDelay;
    }

}