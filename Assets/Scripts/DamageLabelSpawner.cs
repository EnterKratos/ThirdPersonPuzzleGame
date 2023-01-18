using TMPro;
using UnityEngine;

namespace EnterKratos
{
    public class DamageLabelSpawner : MonoBehaviour
    {
        [SerializeField]
        private GameObject labelPrefab;

        public void Spawn(int damage)
        {
            var label = Instantiate(labelPrefab, transform);
            label.GetComponentInChildren<TextMeshProUGUI>().text = $"-{damage}";
        }
    }
}
