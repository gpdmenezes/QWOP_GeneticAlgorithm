using QWOP_GA.GeneticAlgorithm;
using UnityEngine;

namespace QWOP_GA.Runtime
{

    public class GroundCollision : MonoBehaviour
    {

        private void OnCollisionEnter2D (Collision2D collision)
        {
            if (collision.transform.CompareTag("Torso"))
            {
                collision.transform.parent.GetComponent<Brain>().OnDeath();
            }
        }

    }

}