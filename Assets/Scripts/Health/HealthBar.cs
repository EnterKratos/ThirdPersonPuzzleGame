using TNRD;
using UnityEngine;
using UnityEngine.UI;

namespace EnterKratos.Health
{
    public class HealthBar : MonoBehaviour
    {
        [SerializeField]
        private Slider slider;

        [SerializeField]
        private SerializableInterface<IKillable> killable;

        private void OnEnable()
        {
            slider.maxValue = killable.Value.MaxHealth;
        }

        public void DecreaseProgress(int value)
        {
            slider.value -= value;
        }

        public void IncreaseProgress(int value)
        {
            slider.value += value;
        }
    }
}