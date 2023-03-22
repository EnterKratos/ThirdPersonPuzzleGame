using EnterKratos.SceneLoader;
using UnityEditor;
using UnityEngine;

namespace EnterKratos.Editor
{
    [CustomEditor(typeof(MoveObjectToScene))]
    public class MoveObjectToSceneEditor : DebugEditorBase
    {
        private GameObject obj;

        protected override void Draw()
        {
            obj = (GameObject)EditorGUILayout.ObjectField("Object to move", obj, typeof(GameObject), true);

            if (GUILayout.Button("Move"))
            {
                ((MoveObjectToScene)target).Move(obj);
            }
        }
    }
}