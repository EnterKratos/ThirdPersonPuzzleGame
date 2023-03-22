using EnterKratos.Health;
using UnityEditor;
using UnityEngine;

namespace EnterKratos.Editor
{
    [CustomEditor(typeof(HealthSystem))]
    public class HealthSystemEditor : DebugEditorBase
    {
        private int _attackValue;

        protected override void Draw()
        {
            _attackValue = EditorGUILayout.IntField("Attack Value", _attackValue);

            if (GUILayout.Button("Attack"))
            {
                ((HealthSystem)target).Attack(_attackValue);
            }
        }
    }
}