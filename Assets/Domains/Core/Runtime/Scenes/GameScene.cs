using UnityEngine;

namespace Core.Scenes
{
    public abstract class GameScene : MonoBehaviour
    {
        public abstract void Construct(ISceneLoadData data);
    }
}