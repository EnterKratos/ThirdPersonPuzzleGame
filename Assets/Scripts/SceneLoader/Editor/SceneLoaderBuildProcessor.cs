using UnityEditor;
using UnityEditor.Build;
using UnityEditor.Build.Reporting;
using UnityEngine.SceneManagement;

namespace EnterKratos.SceneLoader.Editor
{
    internal class SceneLoaderBuildProcessor : IProcessSceneWithReport
    {
        public int callbackOrder => 0;

        public void OnProcessScene(Scene scene, BuildReport report)
        {
            foreach (var gameObject in scene.GetRootGameObjects())
            {
                var sceneLoaders = gameObject.GetComponentsInChildren<SceneLoader>(true);
                foreach (var sceneLoader in sceneLoaders)
                {
                    sceneLoader.scenePath = AssetDatabase.GUIDToAssetPath(sceneLoader.sceneGuid);
                }

                var sceneUnloaders = gameObject.GetComponentsInChildren<SceneUnloader>(true);
                foreach (var sceneUnloader in sceneUnloaders)
                {
                    sceneUnloader.scenePath = AssetDatabase.GUIDToAssetPath(sceneUnloader.sceneGuid);
                }
            }
        }
    }
}