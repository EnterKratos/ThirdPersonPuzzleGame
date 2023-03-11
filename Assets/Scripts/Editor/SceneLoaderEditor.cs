﻿using UnityEditor;
using UnityEngine;

namespace EnterKratos.Editor
{
    [CustomEditor(typeof(SceneLoader))]
    public class SceneLoaderEditor : DebugEditorBase
    {
        protected override void Draw()
        {
            if (GUILayout.Button("Load Scene"))
            {
                ((SceneLoader)target).LoadSceneAdditive();
            }
        }
    }
}