using System;
using UnityEngine;
using UnityEngine.UI;

namespace QWOP_GA.UI
{
    public class UIManager : MonoBehaviour
    {
        [SerializeField] private Text generationText;
        [SerializeField] private Text timeText;
        [SerializeField] private Text lastGenerationText;
        [SerializeField] private Text allTimeBestText;

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