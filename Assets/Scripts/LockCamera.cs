using Cinemachine;
using UnityEngine;

namespace EnterKratos
{
    [ExecuteInEditMode]
    [SaveDuringPlay]
    [AddComponentMenu("")] // Hide in menu
    public class LockCamera : CinemachineExtension
    {
        [Tooltip("Lock the camera's X position to this value")]
        [SerializeField]
        private EnableableField<float> xPosition;

        [Tooltip("Lock the camera's Y position to this value")]
        [SerializeField]
        private EnableableField<float> yPosition;

        [Tooltip("Lock the camera's Z position to this value")]
        [SerializeField]
        private EnableableField<float> zPosition;

        protected override void PostPipelineStageCallback(
            CinemachineVirtualCameraBase vcam,
            CinemachineCore.Stage stage, ref CameraState state, float deltaTime)
        {
            if (stage != CinemachineCore.Stage.Body)
            {
                return;
            }

            var pos = state.RawPosition;
            pos.x = xPosition.enabled ? xPosition.value : pos.x;
            pos.y = yPosition.enabled ? yPosition.value : pos.y;
            pos.z = zPosition.enabled ? zPosition.value : pos.z;
            state.RawPosition = pos;
        }
    }
}