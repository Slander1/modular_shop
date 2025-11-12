using Core.Data.Player;
using UnityEngine;

namespace Core.Data.Bundle
{
    public abstract class BundleOperation : ScriptableObject
    {
        // public T data;
        public abstract bool CanExecute(PlayerData data);
        public abstract void Execute(PlayerData data);
    }
}