using UnityEditor;
using UnityEngine;

namespace EnterKratos.ScriptableObjects.Editor
{
    [CustomEditor(typeof(GameEventInt))]
    public class GameEventIntEditor : UnityEditor.Editor
    {
        private int _currentEventValue;

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            DrawDefaultInspector();

            _currentEventValue = EditorGUILayout.IntField("Event Value", _currentEventValue);

            if (GUILayout.Button("Fire Event"))
            {
                ((GameEventInt)target).Raise(_currentEventValue);
            }
        }
    }
}