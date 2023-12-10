using UnityEngine;
using UnityEngine.SceneManagement;

namespace QWOP_GA.Runtime
{
    public class TimeScaleController : MonoBehaviour
    {
        public void OnTimeScaleButtonClick (int timeScale)
        {
            Time.timeScale = timeScale;
        }

        public void OnResetButtonClick ()
        {
            SceneManager.LoadScene(0);
        }
    }
}