﻿using UnityEngine;

namespace EnterKratos
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

        private void Awake()
        {
            _raycastHits = new RaycastHit[rayCastBufferSize];
        }

        private void Update()
        {
            var rayStart = camera.transform.position;
            var rayDirection = player.transform.position - rayStart;

            var hits = Physics.RaycastNonAlloc(rayStart, rayDirection, _raycastHits, rayDirection.magnitude, layerMask);
            Debug.DrawRay(rayStart, rayDirection, hits > 0 ? Color.red : Color.green);

            for (var i = 0; i < hits; i++)
            {
                _raycastHits[i].transform.GetComponent<Fader.Fader>().FadeOut();
            }
        }
    }
}