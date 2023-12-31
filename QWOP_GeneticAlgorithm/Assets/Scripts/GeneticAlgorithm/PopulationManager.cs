using QWOP_GA.UI;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace QWOP_GA.GeneticAlgorithm
{
    public class PopulationManager : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] private UIManager UIManager;
        [SerializeField] private GameObject runnerPrefab;

        [Header("Main Settings")]
        [SerializeField] private int populationSize = 10;
        [SerializeField] private float initialTrialTime = 10f;
        [SerializeField] private int mutationChance = 1;

        private List<GameObject> population = new List<GameObject>();
        private int currentGeneration = 1;
        private float timeElapsed = 0;
        private float allTimeBest = 0;
        private float trialTime = 0;

        private void Awake ()
        {
            trialTime = initialTrialTime;
            UIManager.UpdateGenerationText(currentGeneration);
            UIManager.UpdateLastGenerationText(0f);
            UIManager.UpdateAllTimeBestText(0f);
        }

        public void SetupPopulationSettings (int populationSize, int mutationChance)
        {
            this.populationSize = populationSize;
            this.mutationChance = mutationChance;
            SpawnFirstPopulation();
        }

        public void SpawnFirstPopulation ()
        {
            for (int i = 0; i < populationSize; i++)
            {
                GameObject runner = Instantiate(runnerPrefab, this.transform);
                population.Add(runner);
                runner.GetComponent<Brain>().Initialize();
            }
        }

        private GameObject Breed (GameObject parent1, GameObject parent2)
        {
            GameObject offspring = Instantiate(runnerPrefab, this.transform);
            Brain brain = offspring.GetComponent<Brain>();
            brain.Initialize();
            if (Random.Range(0, 100) == mutationChance)
            {
                brain.GetDNA().MutateGene();
            } else
            {
                brain.GetDNA().CombineDNAs(parent1.GetComponent<Brain>().GetDNA(), parent2.GetComponent<Brain>().GetDNA());
            }
            return offspring;
        }

        private void BreedNewPopulation ()
        {
            List<GameObject> sortedPopulation = population.OrderBy(o => o.GetComponent<Brain>().GetFitness()).ToList();
            
            UpdateTrialValues(sortedPopulation);

            for (int i = (int)(sortedPopulation.Count / 2f) - 1; i < sortedPopulation.Count - 1; i++)
            {
                population.Add(Breed(sortedPopulation[i], sortedPopulation[i + 1]));
                population.Add(Breed(sortedPopulation[i + 1], sortedPopulation[i]));
            }

            for (int i = 0; i < sortedPopulation.Count; i++)
            {
                population.Remove(sortedPopulation[i]);
                Destroy(sortedPopulation[i]);
            }

            currentGeneration++;
            UIManager.UpdateGenerationText(currentGeneration);
        }

        private void UpdateTrialValues(List<GameObject> sortedPopulation)
        {
            float lastGenerationBest = sortedPopulation[sortedPopulation.Count - 1].GetComponent<Brain>().GetFitness();
            UIManager.UpdateLastGenerationText(lastGenerationBest);
            UpdateTrialTime(lastGenerationBest);

            if (lastGenerationBest > allTimeBest)
            {
                allTimeBest = lastGenerationBest;
                UIManager.UpdateAllTimeBestText(allTimeBest);
            }
        }

        private void Update ()
        {
            timeElapsed += Time.deltaTime;
            UIManager.UpdateTimeText(timeElapsed);
            if (timeElapsed >= trialTime)
            {
                BreedNewPopulation();
                timeElapsed = 0;
            }
        }

        private void UpdateTrialTime (float lastGenerationFitness)
        {
            if (lastGenerationFitness <= 10)
            {
                trialTime = initialTrialTime;
            } else
            {
                int newTrialTime = (int) initialTrialTime + (int) ((lastGenerationFitness - 10) / 5) * (int) (initialTrialTime / 2);
                trialTime = newTrialTime;
            }
        }
    }
}