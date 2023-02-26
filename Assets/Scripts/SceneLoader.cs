using UnityEditor;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

namespace EnterKratos
{
    public class SceneLoader : MonoBehaviour
    {
        [SerializeField]
        private SceneAsset scene;

        [SerializeField]
        private UnityEvent onSceneLoaded;

        public void LoadSceneAdditive()
        {
            SceneManager.LoadSceneAsync(scene.name, LoadSceneMode.Additive);
            onSceneLoaded.Invoke();
        }
    }
}
