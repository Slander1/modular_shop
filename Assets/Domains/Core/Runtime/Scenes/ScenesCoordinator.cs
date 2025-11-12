using System;
using System.Collections.Generic;
using System.Linq;
using Core.Scenes.Data;
using Core.Utility;
using Cysharp.Threading.Tasks;
using UnityEngine.SceneManagement;

namespace Core.Scenes
{
    public sealed class ScenesCoordinator : SingletonBase<ScenesCoordinator>
    {
        private readonly Dictionary<Type, SceneCatalogInDomain> _catalogs = new();
        
        public void Construct(ScenesCatalog scenesCatalog)
        {
            if (_catalogs.Count != 0) throw new ArgumentException("Catalogs have already been constructed");
            
            foreach (var catalog in scenesCatalog.domainsCatalogs)
            {
                if (catalog == null || catalog.scenes == null || catalog.scenes.Length == 0) 
                    throw new ArgumentException("Broken scenesCatalog");
                
                _catalogs.Add(catalog.GetType(), catalog);
            }
        }

        public SceneCatalogInDomain GetSceneCatalogInDomain(Type sceneCatalogType)
        {
            if (!_catalogs.TryGetValue(sceneCatalogType, out var domain))
            {
                throw new ArgumentException($"dont have catalog {sceneCatalogType}");
            }
            
            return domain;
        }

        public UniTask LoadStartSceneAsync()
        {
            var sceneRef = PickStartup();
            return LoadSceneAsync(sceneRef.SceneName);
        }
        
        public async UniTask NavigateAsync(NavigationRequest request)
        {
            var sceneCatalog = _catalogs[request.CatalogType];
            var sceneRef = sceneCatalog.scenes.First(item => item.SceneName == request.SceneName);
            if (request.Data == null)
            {
                await LoadSceneAsync(sceneRef.SceneName);
            }
            else
            {
                await LoadSceneAsync(sceneRef.SceneName, request.Data);
            }
        }
        
        private async UniTask LoadSceneAsync(string sceneName)
        {
            var loadOp = SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Single);
            await loadOp.ToUniTask();
        }
        
        private async UniTask LoadSceneAsync(string sceneName, ISceneLoadDataMarker sceneLoadData)
        {
            var loadOp = SceneManager.LoadSceneAsync(sceneName,  LoadSceneMode.Single);
            await loadOp.ToUniTask();
            var loadedScene = SceneManager.GetSceneByName(sceneName);
            var gameScene = FindGameSceneObj(loadedScene);
            gameScene.Construct(sceneLoadData);
        }
        
        public static GameScene FindGameSceneObj(Scene scene, bool includeInactive = false)
        {
            if (!scene.isLoaded)
                throw new InvalidOperationException($"Scene '{scene.name}' is not loaded.");

            var rootObjects = scene.GetRootGameObjects();

            var target = rootObjects
                .SelectMany(o => o.GetComponentsInChildren<GameScene>(includeInactive))
                .FirstOrDefault();

            if (target == null)
                throw new ArgumentException($"Component of type {nameof(GameScene)} not found in scene '{scene.name}'.");

            return target;
        }
        
        private SceneReference PickStartup()
        {
            if (_catalogs.Count == 0) throw new ArgumentException("Catalogs have not been constructed");

            var firstDomain = _catalogs.Values
                .OrderBy(d => d.domainPriorityAsStartScene)
                .First();

            var firstScene = firstDomain.scenes.OrderBy(d => d.priority).First();
            
            return firstScene;
        }
    }
}