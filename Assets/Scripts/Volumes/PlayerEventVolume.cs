using EnterKratos.Extensions;
using UnityEngine;

namespace EnterKratos.Volumes
{
    public class PlayerEventVolume : EventVolumeBase<Collider>
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.IsPlayer())
            {
                onEnter.Invoke(other);
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.gameObject.IsPlayer())
            {
                onExit.Invoke(other);
            }
        }
    }
}