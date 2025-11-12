using Core.Scenes;
using Core.Scenes.Data;
using UnityEngine;

namespace Core.Bootstrap
{
    public sealed class GameBootstrap : MonoBehaviour
    {
        [SerializeField] private ScenesCatalog scenesCatalog;
        
        #region === Unity Events ===

        private void Awake()
        {
            Initialize();
        }

        #endregion === Unity Events ===
        
        private void Initialize()
        {
            var scenesCoordinator = ScenesCoordinator.Instance;
            scenesCoordinator.Construct(scenesCatalog);
            
            _ = ScenesCoordinator.Instance.LoadStartSceneAsync();
        }
    }
}