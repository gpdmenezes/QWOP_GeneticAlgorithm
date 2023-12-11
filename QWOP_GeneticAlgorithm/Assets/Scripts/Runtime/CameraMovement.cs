using UnityEngine;

namespace QWOP_GA.Runtime
{
    public class CameraMovement : MonoBehaviour
    {
        [SerializeField] private float cameraSpeed = 15f;

        private Camera mainCamera;
        private float minXPosition = 0f;
        private float maxXPosition = 50f;

        private void Awake ()
        {
            mainCamera = GetComponent<Camera>();
        }

        private void Update ()
        {
            ProcessCameraMovement();
        }

        private void ProcessCameraMovement ()
        {
            float cameraInput = Input.GetAxis("Horizontal") * cameraSpeed * Time.deltaTime;
            Vector3 newPosition = mainCamera.transform.position;
            newPosition.x += cameraInput;
            newPosition.x = Mathf.Clamp(newPosition.x, minXPosition, maxXPosition);
            mainCamera.transform.position = newPosition;
        }

    }
}