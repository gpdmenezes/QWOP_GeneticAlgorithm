using UnityEngine;

namespace QWOP_GA.Runtime
{
    public class TimeScaleController : MonoBehaviour
    {
        public void OnTimeScaleButtonClick (int timeScale)
        {
            Time.timeScale = timeScale;
        }
    }
}