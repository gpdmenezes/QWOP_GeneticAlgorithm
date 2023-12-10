using QWOP_GA.UI;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace QWOP_GA.GeneticAlgorithm
{
    public class PopulationManager : MonoBehaviour
    {
        [SerializeField] private UIManager UIManager;
        [SerializeField] private GameObject runnerPrefab;
        [SerializeField] private int populationSize = 10;
        [SerializeField] private float trialTime = 10f;
        [SerializeField] private int mutationChance = 1;

        private List<GameObject> population = new List<GameObject>();
        private int currentGeneration = 1;
        private float timeElapsed = 0;
        private float allTimeBest = 0;

        private void Awake ()
        {
            UIManager.UpdateGenerationText(currentGeneration);
            UIManager.UpdateLastGenerationText(0f);
            SpawnFirstPopulation();
        }

        private void SpawnFirstPopulation ()
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
            List<GameObject> sortedPopulation = population.OrderBy(o => o.GetComponent<Brain>().GetWalkedDistance()).ToList();

            float lastGenerationBest = sortedPopulation[sortedPopulation.Count - 1].GetComponent<Brain>().GetWalkedDistance();
            UIManager.UpdateLastGenerationText(lastGenerationBest);
            if (lastGenerationBest > allTimeBest)
            {
                allTimeBest = lastGenerationBest;
                UIManager.UpdateAllTimeBestText(allTimeBest);
            }

            for (int i = (int) (sortedPopulation.Count / 2f) - 1; i < sortedPopulation.Count - 1; i++)
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
    }
}