﻿using Cinemachine;
using UnityEngine;

namespace EnterKratos
{
    public class VirtualCameraPropertySetter : MonoBehaviour
    {
        [SerializeField]
        private new CinemachineVirtualCamera camera;

        [SerializeField, Range(0F, 2F)]
        private float deadZoneWidth;

        [SerializeField, Range(0F, 2F)]
        private float deadZoneHeight;

        private CinemachineComposer _composer;

        public void Set()
        {
            _composer.m_DeadZoneWidth = deadZoneWidth;
            _composer.m_DeadZoneHeight = deadZoneHeight;
        }

        public void SetFollowTarget(Collider target)
        {
            camera.Follow = target.transform;
        }

        public void SetLookAtTarget(Collider target)
        {
            camera.LookAt = target.transform;
        }

        private void Awake()
        {
            _composer = camera.GetCinemachineComponent<CinemachineComposer>();
        }
    }
}