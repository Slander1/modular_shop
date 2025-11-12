using UnityEngine;

namespace Core.Scenes.Data
{
    [CreateAssetMenu(
        fileName = "ScenesCoreCatalog",
        menuName = "Scenes/Scenes Core Catalog")]
    public class ScenesCatalog : ScriptableObject
    {
        [Header("Приоритет доменов определяется позицией в списке")]
        
        [SerializeField]
        public SceneCatalogInDomain[] domainsCatalogs;
        
#if UNITY_EDITOR
        
        
        private void OnValidate()
        {
            if (domainsCatalogs == null || domainsCatalogs.Length == 0) return;

            var priorityIndex = 1;
            foreach (var catalog in domainsCatalogs)
            {
                catalog.domainPriorityAsStartScene = priorityIndex;
                priorityIndex++;
            }

            UnityEditor.EditorUtility.SetDirty(this);
        }
#endif
    }
}