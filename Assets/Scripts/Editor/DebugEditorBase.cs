using UnityEditor;
using UnityEngine;

namespace EnterKratos.Editor
{
    public class DebugEditorBase : UnityEditor.Editor
    {
        private bool _displayDebugFields;

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            if (!Application.isPlaying)
            {
                return;
            }

            EditorGUILayout.Space();
            _displayDebugFields = EditorGUILayout.Foldout(_displayDebugFields, "Debug", true);
            if (!_displayDebugFields)
            {
                return;
            }

            Draw();
        }

        public virtual void Draw()
        {

        }
    }
}