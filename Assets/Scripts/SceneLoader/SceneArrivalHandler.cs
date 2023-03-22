using EnterKratos.ScriptableObjects;
using UnityEngine;

namespace EnterKratos.SceneLoader
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