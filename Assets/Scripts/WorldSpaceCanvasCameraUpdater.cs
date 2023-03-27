using UnityEngine;

namespace EnterKratos
{
    public class WorldSpaceCanvasCameraUpdater : MonoBehaviour
    {
        [SerializeField]
        private GameObject canvas;

        private Canvas _canvas;
        private LookAt _lookAt;

        private void Awake()
        {
            _canvas = canvas.GetComponent<Canvas>();
            _lookAt = canvas.GetComponent<LookAt>();
        }

        public void SetMainCamera(GameObject newCameraObject)
        {
            var newCamera = newCameraObject.GetComponent<Camera>();

            _canvas.worldCamera = newCamera;
            _lookAt.SetTarget(newCamera.transform);
        }
    }
}