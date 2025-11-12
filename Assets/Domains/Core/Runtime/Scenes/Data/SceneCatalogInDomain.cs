using System;
using UnityEngine;

namespace Core.Scenes.Data
{
    [Serializable]
    public abstract class SceneCatalogInDomain : ScriptableObject
    {
        public Type ScenesCatalogTypeKey => GetType();
        [SerializeField] public int domainPriorityAsStartScene;
        [SerializeField] public SceneReference[] scenes;
        
#if UNITY_EDITOR
        private void OnValidate()
        {
            if (scenes == null || scenes.Length == 0) return;

            var priorityIndex = 1;
            foreach (var sceneReference in scenes)
            {
                sceneReference.UpdateSceneName();
                sceneReference.priority = priorityIndex;
                priorityIndex++;
            }

            UnityEditor.EditorUtility.SetDirty(this);
            
            
        }
#endif
    }
}