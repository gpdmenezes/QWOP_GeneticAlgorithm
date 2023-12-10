using UnityEngine;

namespace QWOP_GA.GeneticAlgorithm 
{
    public class DNA
    {
        private float rightThighStartingRotation;
        private float leftThighStartingRotation;
        private float rightCalfStartingRotation;
        private float leftCalfStartingRotation;
        private MovementSequence[] movementSequences;

        private float minThighRotation = -90f;
        private float maxThighRotation = 60f;
        private float minCalfRotation = -5f;
        private float maxCalfRotation = 120f;

        private int movementTypes = 4;
        private float maxMovementDuration = 5f;
        private float maxMovementDelay = 5f;

        public DNA (int moventSequencesSize)
        {
            movementSequences = new MovementSequence[moventSequencesSize];
            SetRandomGeneValues();
        }

        public void SetRandomGeneValues ()
        {
            rightThighStartingRotation = Random.Range(minThighRotation, maxThighRotation);
            leftThighStartingRotation = Random.Range(minThighRotation, maxThighRotation);
            rightCalfStartingRotation = Random.Range(minCalfRotation, maxCalfRotation);
            leftCalfStartingRotation = Random.Range(minCalfRotation, maxCalfRotation);

            for (int i = 0; i < movementSequences.Length; i++)
            {
                movementSequences[i] = new MovementSequence();
                movementSequences[i].movementType = Random.Range(0, movementTypes);
                movementSequences[i].movementDuration = Random.Range(0, maxMovementDuration);
                movementSequences[i].nextMovementDelay = Random.Range(0, maxMovementDelay);
            }
        }

        public void MutateGene ()
        {
            int randomGene = Random.Range(0, 5);
            switch (randomGene)
            {
                case 0:
                    rightThighStartingRotation = Random.Range(minThighRotation, maxThighRotation); ;
                    break;
                case 1:
                    leftThighStartingRotation = Random.Range(minThighRotation, maxThighRotation);
                    break;
                case 2:
                    rightCalfStartingRotation = Random.Range(minCalfRotation, maxCalfRotation);
                    break;
                case 3:
                    leftCalfStartingRotation = Random.Range(minCalfRotation, maxCalfRotation);
                    break;
                case 4:
                    int randomMovementStep = Random.Range(0, movementSequences.Length);
                    int randomMovementType = Random.Range(0, 4);
                    movementSequences[randomMovementStep].movementType = randomMovementType;
                    break;
            }
        }

        public void CombineDNAs (DNA dna1, DNA dna2)
        {
            int totalGeneAmount = 4 + (movementSequences.Length * 3);
            for (int i = 0; i < totalGeneAmount; i++)
            {
                if (i < totalGeneAmount / 2f)
                {
                    float geneValue = dna1.GetGeneValue(i);
                    SetGeneValue(i, geneValue);
                } 
                else
                {
                    float geneValue = dna2.GetGeneValue(i);
                    SetGeneValue(i, geneValue);
                }
            }
        }

        public void SetGeneValue (int genePosition, float geneValue)
        {
            if (genePosition < 4)
            {
                switch (genePosition)
                {
                    case 0:
                        rightThighStartingRotation = geneValue;
                        break;
                    case 1:
                        leftThighStartingRotation = geneValue;
                        break;
                    case 2:
                        rightCalfStartingRotation = geneValue;
                        break;
                    case 3:
                        leftCalfStartingRotation = geneValue;
                        break;
                }
            }
            else
            {
                int sequenceIndex = (genePosition - 4) / 3;
                int propertyIndex = (genePosition - 4) % 3;

                if (sequenceIndex < movementSequences.Length)
                {
                    MovementSequence sequence = movementSequences[sequenceIndex];

                    switch (propertyIndex)
                    {
                        case 0:
                            sequence.movementType = (int) geneValue;
                            break;
                        case 1:
                            sequence.movementDuration = geneValue;
                            break;
                        case 2:
                            sequence.nextMovementDelay = geneValue;
                            break;
                    }
                }
            }
        }

        public float GetGeneValue (int genePosition)
        {
            float geneValue = 0;

            if (genePosition < 4)
            {
                switch (genePosition)
                {
                    case 0:
                        geneValue = rightThighStartingRotation;
                        break;
                    case 1:
                        geneValue = leftThighStartingRotation;
                        break;
                    case 2:
                        geneValue = rightCalfStartingRotation;
                        break;
                    case 3:
                        geneValue = leftCalfStartingRotation;
                        break;
                }
            } 
            else
            {
                int sequenceIndex = (genePosition - 4) / 3;
                int propertyIndex = (genePosition - 4) % 3;

                MovementSequence sequence = movementSequences[sequenceIndex];

                switch (propertyIndex)
                {
                    case 0:
                        geneValue = sequence.movementType;
                        break;
                    case 1:
                        geneValue = sequence.movementDuration;
                        break;
                    case 2:
                        geneValue = sequence.nextMovementDelay;
                        break;
                }
            }
            
            return geneValue;
        }

        public MovementSequence[] GetMovementSequences ()
        {
            return movementSequences;
        }
    }
}