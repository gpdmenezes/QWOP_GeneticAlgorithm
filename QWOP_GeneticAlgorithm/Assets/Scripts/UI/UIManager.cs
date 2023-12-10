using UnityEngine;
using UnityEngine.UI;

namespace QWOP_GA.UI
{
    public class UIManager : MonoBehaviour
    {
        [SerializeField] private Text generationText;
        [SerializeField] private Text timeText;

        public void UpdateGenerationText (int generation)
        {
            generationText.text = "- Generation: " + generation;
        }

        public void UpdateTimeText (float time)
        {
            generationText.text = "- Time Elapsed: " + time;
        }

    }
}