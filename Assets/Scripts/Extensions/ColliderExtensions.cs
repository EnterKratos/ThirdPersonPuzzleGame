using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace EnterKratos.Extensions
{
    public static class ColliderExtensions
    {
        public static void AssertTrigger(this IEnumerable<Collider> colliders)
        {
            if (!colliders.Any(c => c.isTrigger))
            {
                Debug.LogError("Object must contain a collider that is a trigger");
            }
        }
    }
}