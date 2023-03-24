using UnityEngine;

namespace EnterKratos.Fader
{
    public class FadePlayerObstruction : MonoBehaviour
    {
        [SerializeField]
        private new Camera camera;

        [SerializeField]
        private GameObject player;

        [SerializeField]
        private LayerMask layerMask;

        [SerializeField]
        private int rayCastBufferSize;

        private RaycastHit[] _raycastHits;

        private Camera MainCamera => camera != null ? camera : Camera.main;

        private void Awake()
        {
            _raycastHits = new RaycastHit[rayCastBufferSize];
            if (camera == null)
            {
                camera = Camera.main;
            }
        }

        private void Update()
        {
            var rayStart = MainCamera.transform.position;
            var rayDirection = player.transform.position - rayStart;

            var hits = Physics.RaycastNonAlloc(rayStart, rayDirection, _raycastHits, rayDirection.magnitude, layerMask);
            Debug.DrawRay(rayStart, rayDirection, hits > 0 ? Color.red : Color.green);

            for (var i = 0; i < hits; i++)
            {
                _raycastHits[i].transform.GetComponent<Fader>().FadeOut();
            }
        }
    }
}