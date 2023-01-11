using UnityEditor;
using UnityEngine;

namespace EnterKratos.Editor
{
    [CustomEditor(typeof(HealthSystem))]
    public class HealthSystemEditor : UnityEditor.Editor
    {
        private bool _displayDebugFields;
        private int _attackValue;

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            EditorGUILayout.Space();
            _displayDebugFields = EditorGUILayout.Foldout(_displayDebugFields, "Debug", true);
            if (!_displayDebugFields)
            {
                return;
            }

            _attackValue = EditorGUILayout.IntField("Attack Value", _attackValue);

            if (GUILayout.Button("Attack"))
            {
                ((HealthSystem)target)?.Attack(_attackValue);
            }
        }
    }
}