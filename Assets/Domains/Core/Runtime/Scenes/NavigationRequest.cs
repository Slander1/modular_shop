using System;

namespace Core.Scenes
{
    public struct NavigationRequest
    {
        public readonly Type CatalogType;
        public readonly string SceneName;
        public readonly ISceneLoadDataMarker Data;

        public NavigationRequest(Type catalogType, string sceneName, ISceneLoadDataMarker data = null)
        {
            CatalogType = catalogType; 
            SceneName = sceneName; 
            Data = data;
        }
    }
}