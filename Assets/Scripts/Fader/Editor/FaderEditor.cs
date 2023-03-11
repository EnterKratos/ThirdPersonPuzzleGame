using EnterKratos.Editor;
using UnityEditor;
using UnityEngine;

namespace EnterKratos.Fader.Editor
{
    [CustomEditor(typeof(Fader))]
    public class FaderEditor : DebugEditorBase
    {
        private Fader Fader => (Fader)target;

        protected override bool PreDraw()
        {
            var faderGroup = Fader.GetComponentInParent<FaderGroup>();

            if (!faderGroup || !faderGroup.enabled)
            {
                return true;
            }

            EditorGUILayout.HelpBox($"This component is driven by a {nameof(FaderGroup)}", MessageType.Info);
            if (GUILayout.Button($"Find {nameof(FaderGroup)}"))
            {
                EditorGUIUtility.PingObject(faderGroup);
            }

            return false;
        }

        protected override void Draw()
        {
            if (GUILayout.Button("Fade Out"))
            {
                Fader.FadeOut();
            }
        }
    }
}