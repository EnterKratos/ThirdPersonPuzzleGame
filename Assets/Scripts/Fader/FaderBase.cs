using UnityEngine;

namespace EnterKratos.Fader
{
    public class FaderBase : MonoBehaviour
    {
        [Range(0, 1)]
        public float minAlpha;

        [Range(0, 1)]
        public float maxAlpha = 1;

        public float fadeOutDuration = 1F;

        public float cooldown = 1F;
    }
}