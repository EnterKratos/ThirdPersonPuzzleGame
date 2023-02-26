using System.Collections.Generic;
using EnterKratos.ScriptableObjects;
using UnityEngine;

namespace EnterKratos
{
    public class Inventory : MonoBehaviour
    {
        [SerializeField]
        private List<Collectable> items;

        public bool Contains(Collectable collectable) => items.Contains(collectable);

        public void EventAdd(Collectable collectable) => Add(collectable);

        public bool Add(Collectable collectable)
        {
            if (Contains(collectable))
            {
                return false;
            }

            items.Add(collectable);
            return true;
        }

        public bool Remove(Collectable collectable)
        {
            if (!Contains(collectable))
            {
                return false;
            }

            items.Remove(collectable);
            return true;
        }
    }
}