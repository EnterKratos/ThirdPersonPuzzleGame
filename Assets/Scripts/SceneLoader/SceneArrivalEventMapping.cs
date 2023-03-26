using System;
using EnterKratos.ScriptableObjects;
using UnityEditor;
using UnityEngine;

namespace EnterKratos.SceneLoader
{
    [Serializable]
    public class SceneArrivalEventMapping
    {
#if UNITY_EDITOR
        [SerializeField]
        public SceneAsset scene;
#endif

        public GameEventGameObject sceneArrivalEvent;

        [HideInInspector]
        public string sceneGuid;

        [HideInInspector]
        public string scenePath;
    }
}