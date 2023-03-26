using UnityEditor;
using UnityEditor.Build;
using UnityEditor.Build.Reporting;
using UnityEngine.SceneManagement;

namespace EnterKratos.SceneLoader.Editor
{
    internal class SceneArrivalBuildProcessor : IProcessSceneWithReport
    {
        public int callbackOrder => 1;

        public void OnProcessScene(Scene scene, BuildReport report)
        {
            foreach (var gameObject in scene.GetRootGameObjects())
            {
                var arrivalHandlers = gameObject.GetComponentsInChildren<SceneArrivalHandler>(true);
                foreach (var handler in arrivalHandlers)
                {
                    foreach (var eventMapping in handler.SceneArrivalEventMapping)
                    {
                        eventMapping.scenePath = AssetDatabase.GUIDToAssetPath(eventMapping.sceneGuid);
                    }
                }
            }
        }
    }
}