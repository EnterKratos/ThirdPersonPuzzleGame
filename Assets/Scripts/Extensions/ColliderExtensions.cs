using UnityEngine;

namespace EnterKratos.Extensions
{
    public static class ColliderExtensions
    {
        public static void AssertTrigger(this Collider collider)
        {
            if (!collider.isTrigger)
            {
                Debug.LogError("Collider must be a trigger");
            }
        }
    }
}