namespace Core.Data.Base
{
    public interface IHaveValue<out T> : IGameStatMarker
    {
        T Value { get; }
    }
}