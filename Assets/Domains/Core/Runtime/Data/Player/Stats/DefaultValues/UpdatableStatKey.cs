using Core.Data.Base;

namespace Core.Data.Player.Stats.DefaultValues
{
    public abstract class UpdatableStatKey : StatKey
    {
        public abstract void UpdatePlayerData();
    }
}