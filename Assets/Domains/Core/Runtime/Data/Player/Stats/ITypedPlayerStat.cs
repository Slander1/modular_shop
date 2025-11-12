namespace Core.Data.Player.Stats
{
    public interface ITypedPlayerStat<T> : IPlayerStatMarker, IReadOnlyPlayerStat<T>
    {
        //TODO : убарть дефоль
        public T DefaultValue { get; }
        public void UpdateValue(T changeValueOn);
        public void ReplaceValue(T newValue);
        public bool IsSatisfied(T newValue);
    }
}