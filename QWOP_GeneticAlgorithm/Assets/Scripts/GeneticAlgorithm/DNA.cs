using UnityEngine;

namespace QWOP_GA.GeneticAlgorithm {

    public class DNA
    {
        private float rightThighStartingRotation;
        private float leftThighStartingRotation;
        private float rightCalfStartingRotation;
        private float leftCalfStartingRotation;
        private MovementSequence[] movementSequences;

        private const float minThighRotation = -90f;
        private const float maxThighRotation = 60f;
        private const float minCalfRotation = -5f;
        private const float maxCalfRotation = 120f;

        private const int movementTypes = 4;
        private const float maxMovementDuration = 5f;
        private const float maxMovementDelay = 5f;

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
                movementSequences[i].movementType = Random.Range(0, movementTypes + 1);
                movementSequences[i].movementDuration = Random.Range(0, maxMovementDuration);
                movementSequences[i].nextMovementDelay = Random.Range(0, maxMovementDelay);
            }
        }

        public void SetGeneValue (float genePosition, float value)
        {
            switch (genePosition)
            {
                case 0:
                    rightThighStartingRotation = value;
                    break;
                case 1:
                    leftThighStartingRotation = value;
                    break;
                case 2:
                    rightCalfStartingRotation = value;
                    break;
                case 3:
                    leftCalfStartingRotation = value;
                    break;
            }
        }

        public void CombineDNAs (DNA dna1, DNA dna2)
        {
            /*
            for (int i = 0; i < dnaLength; i++)
            {
                if (i < dnaLength / 2f)
                {
                    int value = dna1.genes[i];
                    genes[i] = value;
                } 
                else
                {
                    int value = dna2.genes[i];
                    genes[i] = value;
                }
            }
            */
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

        public float GetGeneValue (string geneName)
        {
            float geneValue = 0;
            switch (geneName)
            {
                case "rightThighStartingRotation":
                    geneValue = rightThighStartingRotation;
                    break;
                case "leftThighStartingRotation":
                    geneValue = leftThighStartingRotation;
                    break;
                case "rightCalfStartingRotation":
                    geneValue = rightCalfStartingRotation;
                    break;
                case "leftCalfStartingRotation":
                    geneValue = leftCalfStartingRotation;
                    break;
            }
            return geneValue;
        }

        public MovementSequence[] GetMovementSequence ()
        {
            return movementSequences;
        }

    }

}