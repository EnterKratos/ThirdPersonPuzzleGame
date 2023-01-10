using EnterKratos.Extensions;
using UnityEngine;

namespace EnterKratos
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