namespace Core.Data.Player.Stats
{
    public interface IPlayerStat<T> : IReadOnlyPlayerStat<T>
    {
        public T DefaultValue { get; }
        public void UpdateValue(T changeValueOn);
        public void ReplaceValue(T newValue);
    }
}