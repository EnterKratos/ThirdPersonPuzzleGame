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
    }
}