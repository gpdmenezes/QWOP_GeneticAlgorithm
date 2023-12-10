using QWOP_GA.GeneticAlgorithm;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace QWOP_GA.UI
{
    public class UIManager : MonoBehaviour
    {
        [Header("Menu")]
        [SerializeField] private PopulationManager populationManager;
        [SerializeField] private GameObject backgroundBlur;
        [SerializeField] private GameObject menuPanel;

        [Header("Input")]
        [SerializeField] private InputField populationInput;
        [SerializeField] private InputField mutationInput;

        [Header("Stats")]
        [SerializeField] private Text generationText;
        [SerializeField] private Text timeText;
        [SerializeField] private Text lastGenerationText;
        [SerializeField] private Text allTimeBestText;

        public void OnStartButtonClick ()
        {
            int population = int.Parse(populationInput.text);
            int mutation = int.Parse(mutationInput.text);

            if (population >= 4 && mutation >= 1)
            {
                populationManager.SetupPopulationSettings(population, mutation);

                backgroundBlur.SetActive(false);
                menuPanel.SetActive(false);
            }
        }

        public void UpdateGenerationText (int generation)
        {
            generationText.text = "- Generation: " + generation;
        }

        public void UpdateTimeText (float time)
        {
            timeText.text = "- Time Elapsed: " + String.Format("{0:0.00}", time);
        }

        public void UpdateLastGenerationText (float distance)
        {
            lastGenerationText.text = "- Last Generation Best: " + String.Format("{0:0.00}", distance);
        }

        public void UpdateAllTimeBestText (float distance)
        {
            allTimeBestText.text = "- All Time Best: " + String.Format("{0:0.00}", distance);
        }

    }
}