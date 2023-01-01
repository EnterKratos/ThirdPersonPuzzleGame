using UnityEditor;
using UnityEngine;

namespace EnterKratos.ScriptableObjects.Editor
{
    [CustomEditor(typeof(GameEvent))]
    public class GameEventEditor : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            if (GUILayout.Button("Fire Event"))
            {
                ((GameEvent)target)?.Raise();
            }
        }
    }
}