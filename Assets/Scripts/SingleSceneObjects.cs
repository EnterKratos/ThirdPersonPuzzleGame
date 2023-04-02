#if UNITY_EDITOR
using UnityEditor.SceneManagement;
#endif
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace EnterKratos
{
    [ExecuteInEditMode]
    public class SingleSceneObjects : MonoBehaviour
    {
        [SerializeField]
        public List<GameObject> objects = new();

        private void SetActiveState()
        {
            var newActiveState = SceneManager.sceneCount == 1 || SceneManager.GetActiveScene() == gameObject.scene;

            foreach (var obj in objects.Where(obj => obj != null))
            {
                obj.SetActive(newActiveState);
            }
        }

        private void OnEnable()
        {
            SetActiveState();

#if UNITY_EDITOR
            EditorSceneManager.sceneOpened += OnSceneOpened;
            EditorSceneManager.sceneClosed += OnSceneClosed;
#endif
            SceneManager.sceneLoaded += OnSceneLoaded;
            SceneManager.sceneUnloaded += OnSceneUnloaded;
        }

        private void OnDisable()
        {
            SetActiveState();

#if UNITY_EDITOR
            EditorSceneManager.sceneOpened -= OnSceneOpened;
            EditorSceneManager.sceneClosed -= OnSceneClosed;
#endif
            SceneManager.sceneLoaded -= OnSceneLoaded;
            SceneManager.sceneUnloaded -= OnSceneUnloaded;
        }

#if UNITY_EDITOR
        private void OnSceneOpened(Scene scene, OpenSceneMode mode)
        {
            SetActiveState();
        }

        private void OnSceneClosed(Scene scene)
        {
            SetActiveState();
        }
#endif

        private void OnSceneLoaded(Scene arg0, LoadSceneMode arg1)
        {
            SetActiveState();
        }

        private void OnSceneUnloaded(Scene arg0)
        {
            SetActiveState();
        }
    }
}