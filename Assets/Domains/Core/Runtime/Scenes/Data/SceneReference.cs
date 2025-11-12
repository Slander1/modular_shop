using System;
using System.IO;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

namespace Core.Scenes.Data
{
    [Serializable]
    public class SceneReference 
    { 
        public string SceneName { get; private set; }

        [SerializeField] public int priority;
#if UNITY_EDITOR
        [SerializeField] private SceneAsset sceneAsset;
#endif

#if UNITY_EDITOR
        public void UpdateSceneName()
        {
            if (sceneAsset == null)
            {
                SceneName = string.Empty;
                return;
            }

            var path = AssetDatabase.GetAssetPath(sceneAsset);
            SceneName = string.IsNullOrEmpty(path)
                ? sceneAsset.name
                : Path.GetFileNameWithoutExtension(path);
        }
#endif
    }
}