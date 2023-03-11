using UnityEditor;
using UnityEngine;

namespace EnterKratos.Editor
{
    public class DebugEditorBase : UnityEditor.Editor
    {
        private bool _displayDebugFields;

        public override void OnInspectorGUI()
        {
            if (!PreDraw())
            {
                return;
            }

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

        /// <summary>
        /// Draws before the default inspector fields and provides a way to prevent them being drawn.
        /// </summary>
        /// <returns>True to continue drawing default inspector fields, else false</returns>
        protected virtual bool PreDraw()
        {
            return true;
        }

        protected virtual void Draw()
        {

        }
    }
}