using Core.Data.Player;
using Core.Data.Player.Stats.DefaultValues;
using Core.Scenes;
using Core.Scenes.Data;
using UnityEngine;

namespace Core.Bootstrap
{
    public sealed class GameBootstrap : MonoBehaviour
    {
        [SerializeField] private ScenesCatalog scenesCatalog;
        [SerializeField] private PlayerDataDefaultValues defaultValues;
        
        #region === Unity Events ===

        private void Awake()
        {
            Initialize();
        }

        #endregion === Unity Events ===
        
        private void Initialize()
        {
            var playerData = PlayerData.Instance;
            defaultValues.FillPlayerDataDefaultValues(playerData);
            
            var scenesCoordinator = ScenesCoordinator.Instance;
            scenesCoordinator.Construct(scenesCatalog);
            
            _ = ScenesCoordinator.Instance.LoadStartSceneAsync();
        }
    }
}