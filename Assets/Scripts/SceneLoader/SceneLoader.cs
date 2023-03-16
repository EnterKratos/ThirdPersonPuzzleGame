#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

namespace EnterKratos.SceneLoader
{
    [ExecuteInEditMode]
    public class SceneLoader : MonoBehaviour
    {
#if UNITY_EDITOR
        [SerializeField]
        private SceneAsset scene;
#endif

        [SerializeField]
        private bool loadOnStart;

        [SerializeField]
        private bool loadAsync;

        [SerializeField]
        private LoadSceneMode mode;

        [SerializeField]
        private UnityEvent onSceneLoaded;

        [HideInInspector]
        public string sceneGuid;

        [HideInInspector]
        public string scenePath;

        public void LoadScene()
        {
            if (loadAsync)
            {
                SceneManager.LoadSceneAsync(scenePath, mode);
            }
            else
            {
                SceneManager.LoadScene(scenePath, mode);
            }

            onSceneLoaded.Invoke();
        }

#if UNITY_EDITOR
        private void OnEnable()
        {
            Validate();
        }

        private void OnValidate()
        {
            Validate();
        }

        private void Validate()
        {
            if (!scene)
            {
                Debug.LogWarning(
                    $"No scene file set in {nameof(SceneLoader)}({GetInstanceID()}) on {gameObject.name}({gameObject.GetInstanceID()})");
                return;
            }

            scenePath = AssetDatabase.GetAssetOrScenePath(scene);
            sceneGuid = AssetDatabase.GUIDFromAssetPath(scenePath).ToString();
        }
#endif

        private void Start()
        {
            if (loadOnStart && Application.isPlaying)
            {
                LoadScene();
            }
        }
    }
}
