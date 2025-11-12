using System;
using System.Collections.Generic;
using System.IO;
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
        
        /// <summary>
        /// Логика координатора заложена простейшая, не продуманная,
        /// потому что согласно ТЗ пункта такого нет.
        /// </summary>
        /// <returns></returns>
        private SceneReference PickStartup()
        {
            if (_catalogs.Count == 0) throw new ArgumentException("Catalogs have not been constructed");

            var firstDomain = _catalogs.Values
                .OrderBy(d => d.domainPriorityAsStartScene)
                .First();

            var firstScene = firstDomain.scenes.OrderBy(d => d.priority).First();
            
            return firstScene;
        }

        public UniTask LoadStartSceneAsync()
        {
            var sceneRef = PickStartup();
            return LoadSceneAsync(sceneRef.SceneName);
        }
        
        public async UniTask LoadSceneAsync(string sceneName, LoadSceneMode mode = LoadSceneMode.Single)
        {
            var loadOp = SceneManager.LoadSceneAsync(sceneName, mode);
            await loadOp.ToUniTask();
        }

        public async UniTask LoadSceneAsync(int sceneIndex, LoadSceneMode mode = LoadSceneMode.Single)
        {
            var loadOp = SceneManager.LoadSceneAsync(sceneIndex, mode);
            await loadOp.ToUniTask();
        }

        public async UniTask LoadAdditiveAsync(string sceneName)
        {
            var loadOp = SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);
            await loadOp.ToUniTask();
        }

        public async UniTask LoadAdditiveAsync(int sceneIndex)
        {
            var loadOp = SceneManager.LoadSceneAsync(sceneIndex, LoadSceneMode.Additive);
            await loadOp.ToUniTask();
        }

        public async UniTask UnloadSceneAsync(string sceneName)
        {
            var scene = SceneManager.GetSceneByName(sceneName);
            if (!scene.isLoaded)
                return;

            var unloadOp = SceneManager.UnloadSceneAsync(scene);
            await unloadOp.ToUniTask();
        }

        public async UniTask UnloadSceneAsync(int sceneIndex)
        {
            var scene = SceneManager.GetSceneByBuildIndex(sceneIndex);
            if (!scene.isLoaded)
                return;

            var unloadOp = SceneManager.UnloadSceneAsync(scene);
            await unloadOp.ToUniTask();
        }
    }
}