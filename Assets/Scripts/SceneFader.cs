using System;
using System.Collections;
using EnterKratos.Fader;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace EnterKratos
{
    public class SceneFader : MonoBehaviour
    {
        [SerializeField]
        private float fadeDuration;

        [SerializeField]
        private AnimationCurve animationCurve;

        [SerializeField]
        private Image image;

        [SerializeField]
        private UnityEvent onSceneFadeInComplete;

        [SerializeField]
        private UnityEvent onSceneFadeOutComplete;

        public void FadeIn()
        {
            StartCoroutine(FadeCoroutine(FadeDirection.In, () => onSceneFadeInComplete.Invoke()));
        }

        public void FadeOut()
        {
            StartCoroutine(FadeCoroutine(FadeDirection.Out, () => onSceneFadeOutComplete.Invoke()));
        }

        private IEnumerator FadeCoroutine(FadeDirection fadeDirection, Action onFadeComplete)
        {
            var accumulatedTime = 0F;
            const int minAlpha = 0;
            const int maxAlpha = 255;
            var a = fadeDirection == FadeDirection.In ? maxAlpha : minAlpha;
            var b = fadeDirection == FadeDirection.Out ? maxAlpha : minAlpha;

            while(accumulatedTime <= fadeDuration)
            {
                accumulatedTime += Time.deltaTime;
                var curveValue = animationCurve.Evaluate(accumulatedTime / fadeDuration);
                var alpha = (int)Mathf.Lerp(a, b, curveValue);
                image.color = new Color(image.color.r, image.color.g, image.color.b, alpha / (float)maxAlpha);
                yield return null;
            }

            var finalColor = new Color(image.color.r, image.color.g, image.color.b, b);
            image.color = finalColor;

            onFadeComplete.Invoke();
        }
    }
}