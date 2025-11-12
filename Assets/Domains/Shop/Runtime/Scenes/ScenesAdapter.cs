using Core.Scenes;
using Core.Scenes.Data;
using Cysharp.Threading.Tasks;

namespace Shop.Scenes
{
    public class ScenesAdapter
    {
        protected readonly ScenesCoordinator ScenesCoordinator;
        
        protected ScenesAdapter(ScenesCoordinator scenesCoordinator)
        {
            ScenesCoordinator = scenesCoordinator;
        }
    }
}