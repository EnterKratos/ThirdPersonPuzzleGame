using System;
using Cinemachine;
using EnterKratos.Extensions;
using UnityEngine;

namespace EnterKratos
{
    public class CameraVolumePriorityUpdater : MonoBehaviour
    {
        [SerializeField]
        private CinemachineVirtualCamera virtualCamera;

        [SerializeField]
        private new Collider collider;
        
        [SerializeField]
        private int desiredPriority;

        [SerializeField]
        private bool resetOnExit;

        private int _oldPriority;

        private void Awake()
        {
            collider.AssertTrigger();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.IsPlayer())
            {
                virtualCamera.Priority = desiredPriority;
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (!resetOnExit && !other.gameObject.IsPlayer())
            {
                return;
            }

            virtualCamera.Priority = _oldPriority;
        }
    }
}