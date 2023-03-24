#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

namespace EnterKratos.SceneLoader
{
    [ExecuteInEditMode]
    public class SceneUnloader : MonoBehaviour
    {
#if UNITY_EDITOR
        [SerializeField]
        private SceneAsset scene;
#endif

        [SerializeField]
        private UnloadSceneOptions options;

        [SerializeField]
        private UnityEvent onSceneUnloaded;

        [HideInInspector]
        public string sceneGuid;

        [HideInInspector]
        public string scenePath;

        public void UnloadScene()
        {
            SceneManager.UnloadSceneAsync(scenePath, options);

            onSceneUnloaded.Invoke();
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
                    $"No scene file set in {nameof(SceneUnloader)}({GetInstanceID()}) on {gameObject.name}({gameObject.GetInstanceID()})");
                return;
            }

            scenePath = AssetDatabase.GetAssetOrScenePath(scene);
            sceneGuid = AssetDatabase.GUIDFromAssetPath(scenePath).ToString();
        }
#endif
    }
}
