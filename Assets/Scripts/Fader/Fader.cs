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

        private Direction _lastDirection;

        private float _lastFadeOutRequest;

        private static readonly int AlphaId = Shader.PropertyToID("_Alpha");

        public void FadeOut(bool groupCall = false)
        {
            Fade(Direction.Out);

            if (_faderGroup && !groupCall)
            {
                _faderGroup.FadeOut(this);
            }
        }

        private void FadeIn()
        {
            Fade(Direction.In);
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

        private void Fade(Direction direction)
        {
            _lastFadeOutRequest = Time.time;

            if (_fadeCoroutine != null || _lastDirection == direction)
            {
                return;
            }

            _fadeCoroutine = FadeCoroutine(direction);
            StartCoroutine(_fadeCoroutine);

            _lastDirection = direction;
        }

        private IEnumerator FadeCoroutine(Direction direction)
        {
            var accumulatedTime = 0F;
            var a = direction == Direction.In ? MinAlpha : MaxAlpha;
            var b = direction == Direction.Out ? MinAlpha : MaxAlpha;

            while(accumulatedTime <= FadeOutDuration)
            {
                accumulatedTime += Time.deltaTime / FadeOutDuration;
                var normalisedAlpha = Mathf.InverseLerp(a, b, accumulatedTime);
                _rend.material.SetFloat(AlphaId, Mathf.Clamp(normalisedAlpha, MinAlpha, MaxAlpha));
                yield return null;
            }

            _fadeCoroutine = null;
        }

        private enum Direction
        {
            In,
            Out
        }
    }
}