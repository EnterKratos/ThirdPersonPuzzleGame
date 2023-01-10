using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace EnterKratos
{
    public class RigidBodyEventVolume : EventVolumeBase<Rigidbody>
    {
        [SerializeField]
        private float minimumMass;

        private float _totalMass;

        private void OnTriggerEnter(Collider other)
        {
            var rigidBody = other.GetComponent<Rigidbody>();
            if (rigidBody == null)
            {
                return;
            }

            _totalMass += rigidBody.mass;

            if (_totalMass < minimumMass)
            {
                return;
            }

            onEnter.Invoke(rigidBody);
        }

        private void OnTriggerExit(Collider other)
        {
            var rigidBody = other.GetComponent<Rigidbody>();
            if (rigidBody == null)
            {
                return;
            }

            _totalMass -= rigidBody.mass;

            if (_totalMass >= minimumMass)
            {
                return;
            }

            onExit.Invoke(rigidBody);
        }
    }
}