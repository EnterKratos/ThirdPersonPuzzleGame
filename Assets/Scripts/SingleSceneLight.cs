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
#endif
        }

        private void OnDisable()
        {
            SetLightEnabledState();

#if UNITY_EDITOR
            EditorSceneManager.sceneOpened -= OnSceneOpened;
#endif
        }

        private void SetLightEnabledState()
        {
            light.enabled = SceneManager.sceneCount == 1;
        }

#if UNITY_EDITOR
        private void OnSceneOpened(Scene scene, OpenSceneMode mode)
        {
            SetLightEnabledState();
        }
#endif
    }
}