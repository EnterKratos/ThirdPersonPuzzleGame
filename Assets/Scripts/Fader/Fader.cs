using System.Collections;
using UnityEngine;

namespace EnterKratos.Fader
{
    [RequireComponent(typeof(Renderer))]
    public class Fader : FaderBase
    {
        private bool FaderGroupEnabled => _faderGroup && _faderGroup.enabled;

        private float MinAlpha => FaderGroupEnabled ? _faderGroup.minAlpha : minAlpha;

        private float MaxAlpha => FaderGroupEnabled ? _faderGroup.maxAlpha : maxAlpha;

        private float FadeOutDuration => FaderGroupEnabled ? _faderGroup.fadeOutDuration : fadeOutDuration;

        private float Cooldown => FaderGroupEnabled ? _faderGroup.cooldown : cooldown;

        private FaderGroup _faderGroup;

        private Renderer _rend;

        private IEnumerator _fadeCoroutine;

        private FadeDirection lastFadeDirection;

        private float _lastFadeOutRequest;

        private static readonly int AlphaId = Shader.PropertyToID("_Alpha");

        public void FadeOut(bool groupCall = false)
        {
            Fade(FadeDirection.Out);

            if (_faderGroup && !groupCall)
            {
                _faderGroup.FadeOut(this);
            }
        }

        private void FadeIn()
        {
            Fade(FadeDirection.In);
        }

        private void Awake()
        {
            _rend = GetComponent<Renderer>();
        }

        private void Start()
        {
            _faderGroup = GetComponentInParent<FaderGroup>();
        }

        private void Update()
        {
            if (Time.time - _lastFadeOutRequest < Cooldown)
            {
                return;
            }

            FadeIn();
        }

        private void Fade(FadeDirection fadeDirection)
        {
            _lastFadeOutRequest = Time.time;

            if (!enabled || _fadeCoroutine != null || lastFadeDirection == fadeDirection)
            {
                return;
            }

            _fadeCoroutine = FadeCoroutine(fadeDirection);
            StartCoroutine(_fadeCoroutine);

            lastFadeDirection = fadeDirection;
        }

        private IEnumerator FadeCoroutine(FadeDirection fadeDirection)
        {
            var accumulatedTime = 0F;
            var a = fadeDirection == FadeDirection.In ? MinAlpha : MaxAlpha;
            var b = fadeDirection == FadeDirection.Out ? MinAlpha : MaxAlpha;

            while(accumulatedTime <= FadeOutDuration)
            {
                accumulatedTime += Time.deltaTime / FadeOutDuration;
                var normalisedAlpha = Mathf.InverseLerp(a, b, accumulatedTime);
                _rend.material.SetFloat(AlphaId, Mathf.Clamp(normalisedAlpha, MinAlpha, MaxAlpha));
                yield return null;
            }

            _fadeCoroutine = null;
        }
    }
}