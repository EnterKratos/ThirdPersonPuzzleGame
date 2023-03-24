#if UNITY_EDITOR
using UnityEditor.SceneManagement;
#endif
using UnityEngine;
using UnityEngine.SceneManagement;

namespace EnterKratos
{
    [ExecuteInEditMode]
    public class SingleSceneLight : MonoBehaviour
    {
        [SerializeField]
        private new Light light;

        private void OnEnable()
        {
            SetLightEnabledState();

#if UNITY_EDITOR
            EditorSceneManager.sceneOpened += OnSceneOpened;
            EditorSceneManager.sceneClosed += OnSceneClosed;
            SceneManager.sceneLoaded += OnSceneLoaded;
            SceneManager.sceneUnloaded += OnSceneUnloaded;
#endif
        }

        private void OnDisable()
        {
            SetLightEnabledState();

#if UNITY_EDITOR
            EditorSceneManager.sceneOpened -= OnSceneOpened;
            EditorSceneManager.sceneClosed -= OnSceneClosed;
            SceneManager.sceneLoaded -= OnSceneLoaded;
            SceneManager.sceneUnloaded -= OnSceneUnloaded;
#endif
        }

        private void SetLightEnabledState()
        {
            light.enabled = SceneManager.sceneCount == 1 || SceneManager.GetActiveScene() == light.gameObject.scene;
        }

#if UNITY_EDITOR
        private void OnSceneOpened(Scene scene, OpenSceneMode mode)
        {
            SetLightEnabledState();
        }

        private void OnSceneClosed(Scene scene)
        {
            SetLightEnabledState();
        }

        private void OnSceneLoaded(Scene arg0, LoadSceneMode arg1)
        {
            SetLightEnabledState();
        }

        private void OnSceneUnloaded(Scene arg0)
        {
            SetLightEnabledState();
        }
#endif
    }
}
