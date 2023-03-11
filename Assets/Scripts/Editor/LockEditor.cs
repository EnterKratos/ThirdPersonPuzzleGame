using UnityEditor;
using UnityEngine;

namespace EnterKratos.Editor
{
    [CustomEditor(typeof(Lock))]
    public class LockEditor : DebugEditorBase
    {
        protected override void Draw()
        {
            if (GUILayout.Button("Unlock"))
            {
                ((Lock)target).Unlock();
            }
        }
    }
}