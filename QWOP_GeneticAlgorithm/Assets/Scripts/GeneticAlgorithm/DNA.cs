using System.Collections.Generic;
using UnityEngine;

namespace QWOP_GA.GeneticAlgorithm {

    public class DNA
    {
        private List<int> genes = new List<int>();
        private int dnaLength = 0;
        private int maxGeneValue = 0;

        public DNA (int dnaLength, int maxGeneValue)
        {
            this.dnaLength = dnaLength;
            this.maxGeneValue = maxGeneValue;
            SetRandomGeneValues();
        }

        public void SetRandomGeneValues ()
        {
            genes.Clear();
            for (int i = 0; i < dnaLength; i++)
            {
                genes.Add(Random.Range(0, maxGeneValue));
            }
        }

        public void SetGeneValue (int genePosition, int value)
        {
            genes[genePosition] = value;
        }

        public void CombineDNAs (DNA dna1, DNA dna2)
        {
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
        }

        public void MutateGene ()
        {
            genes[Random.Range(0, dnaLength)] = Random.Range(0, maxGeneValue);
        }

        public int GetGeneValue (int genePosition)
        {
            return genes[genePosition];
        }

    }

}