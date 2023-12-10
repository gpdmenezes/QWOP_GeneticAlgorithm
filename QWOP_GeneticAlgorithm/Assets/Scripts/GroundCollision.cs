using UnityEngine;
using UnityEngine.SceneManagement;

namespace QWOPGeneticAlgorithm
{

    public class GroundCollision : MonoBehaviour
    {
        [SerializeField] private GameObject gameOverUI;

        private bool hasCollidedWithGround = false;

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.transform.CompareTag("Torso"))
            {
                hasCollidedWithGround = true;
                gameOverUI.SetActive(true);
            }
        }

        private void Update()
        {
            if (!hasCollidedWithGround) return;

            if (Input.GetKeyDown(KeyCode.Space))
            {
                SceneManager.LoadScene(0);
            }
        }

    }

}