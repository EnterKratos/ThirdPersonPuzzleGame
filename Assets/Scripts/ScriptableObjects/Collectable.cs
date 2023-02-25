using UnityEngine;

namespace EnterKratos.ScriptableObjects
{
    [CreateAssetMenu]
    public class Collectable : ScriptableObject
    {
        public new string name;
        public string description;
        public GameObject model;
    }
}