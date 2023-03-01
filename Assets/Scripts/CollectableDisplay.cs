using EnterKratos.ScriptableObjects;
using TMPro;
using UnityEngine;

namespace EnterKratos
{
    public class CollectableDisplay : MonoBehaviour
    {
        [SerializeField]
        private TextMeshProUGUI nameField;
        
        [SerializeField]
        private TextMeshProUGUI descriptionField;
        
        public void Display(Collectable collectable)
        {
            nameField.text = collectable.name;
            descriptionField.text = collectable.description;
        }
    }
}
