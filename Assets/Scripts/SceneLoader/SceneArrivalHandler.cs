using System.Collections.Generic;
using System.Linq;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;

namespace EnterKratos.SceneLoader
{
    public class SceneArrivalHandler : MonoBehaviour
    {
        [SerializeField]
        private List<SceneArrivalEventMapping> sceneArrivalEventMapping;

        public IReadOnlyCollection<SceneArrivalEventMapping> SceneArrivalEventMapping =>
            sceneArrivalEventMapping.AsReadOnly();

        public void OnSceneArrival()
        {
            var thisObject = gameObject;
            var currentScene = thisObject.scene;
            var eventMapping = sceneArrivalEventMapping.Single(x => x.scenePath == currentScene.path);
            eventMapping.sceneArrivalEvent.Raise(thisObject);
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
            foreach (var mapping in sceneArrivalEventMapping)
            {
                if (!mapping.scene)
                {
                    Debug.LogWarning(
                        $"No scene file set in {nameof(SceneLoader)}({GetInstanceID()}) on {gameObject.name}({gameObject.GetInstanceID()})");
                    return;
                }

                mapping.scenePath = AssetDatabase.GetAssetOrScenePath(mapping.scene);
                mapping.sceneGuid = AssetDatabase.GUIDFromAssetPath(mapping.scenePath).ToString();
            }
        }
#endif
    }
}