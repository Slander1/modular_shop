namespace Core.Data.Player.Stats
{
    public interface IReadOnlyPlayerStat<out T>
    {
        T CurrentValue { get; }
    }
}