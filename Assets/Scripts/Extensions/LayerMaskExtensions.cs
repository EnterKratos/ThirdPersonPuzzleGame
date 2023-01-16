using UnityEngine;

namespace EnterKratos.Extensions
{
    public static class LayerMaskExtensions
    {
        public static bool Includes(this LayerMask mask, int layer)
        {
            return mask == (mask | (1 << layer));
        }
    }
}