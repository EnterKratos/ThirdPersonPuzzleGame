using UnityEditor;

namespace EnterKratos.Editor
{
    public class DebugEditorBase : UnityEditor.Editor
    {
        private bool _displayDebugFields;

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

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