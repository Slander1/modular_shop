using Core.Scenes;

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