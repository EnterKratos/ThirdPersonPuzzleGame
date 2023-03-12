using EnterKratos.ScriptableObjects;
using UnityEngine;

namespace EnterKratos
{
    public class SceneArrivalHandler : MonoBehaviour
    {
        [SerializeField]
        private GameEventGameObject onSceneArrival;

        public void OnSceneArrival()
        {
            onSceneArrival.Raise(gameObject);
        }
    }
}