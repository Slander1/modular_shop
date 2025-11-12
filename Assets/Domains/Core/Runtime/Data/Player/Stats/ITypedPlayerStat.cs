using Core.Data.Base;

namespace Core.Data.Player.Stats
{
    public interface ITypedPlayerStat<T> : IHaveValue<T>
    {
        public void UpdateValue(T changeValueOn);
        public void ReplaceValue(T newValue);
    }
}