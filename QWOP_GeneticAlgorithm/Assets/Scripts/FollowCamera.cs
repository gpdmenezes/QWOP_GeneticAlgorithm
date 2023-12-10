using UnityEngine;

namespace QWOPGeneticAlgorithm
{

    public class FollowCamera : MonoBehaviour
    {

        [SerializeField] private Transform followTarget;

        private void Update ()
        {
            transform.position = new Vector3(followTarget.position.x, transform.position.y, transform.position.z);
        }

    }

}