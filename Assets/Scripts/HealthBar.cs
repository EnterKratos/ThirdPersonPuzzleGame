using EnterKratos.ScriptableObjects;
using UnityEngine;
using UnityEngine.UI;

namespace EnterKratos
{
    public class HealthBar : MonoBehaviour
    {
        [SerializeField]
        private Slider slider;

        [SerializeField]
        private Player player;

        private void OnEnable()
        {
            slider.maxValue = player.maxHealth;
        }

        public void DecreaseProgress(int value)
        {
            slider.value -= value;
        }
    }
}
