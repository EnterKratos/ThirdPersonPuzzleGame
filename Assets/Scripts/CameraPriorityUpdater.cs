using System;
using Cinemachine;
using UnityEngine;

namespace EnterKratos
{
    public class CameraPriorityUpdater : MonoBehaviour
    {
        [SerializeField]
        private CinemachineVirtualCamera virtualCamera;

        private int _oldPriority;

        public void UpdatePriority(int priority)
        {
            virtualCamera.Priority = priority;
        }

        public void Reset()
        {
            virtualCamera.Priority = _oldPriority;
        }

        public void SetVirtualCamera(GameObject newVirtualCamera)
        {
            if (newVirtualCamera.TryGetComponent<CinemachineVirtualCamera>(out var cam))
            {
                virtualCamera = cam;
            }
            else
            {
                throw new InvalidOperationException($"{newVirtualCamera.name} does not contain a {nameof(CinemachineVirtualCamera)}");
            }
        }
    }
}