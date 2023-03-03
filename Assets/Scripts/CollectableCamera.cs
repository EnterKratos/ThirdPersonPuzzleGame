using EnterKratos.ScriptableObjects;
using UnityEngine;

namespace EnterKratos
{
    public class CollectableCamera : MonoBehaviour
    {
        private GameObject _currentObject;

        public void Display(Collectable collectable)
        {
            if (_currentObject != null)
            {
                Destroy(_currentObject);
            }

            var parentTransform = transform;
            _currentObject = Instantiate(collectable.model, parentTransform, true);
        }
    }
}
