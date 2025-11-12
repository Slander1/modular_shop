namespace Core.Data.Player.Stats
{
    public abstract class TypedStatBase<T> : ITypedPlayerStat<T>
    {
        public T Value { get; protected set; }

        protected TypedStatBase()
        { }
        
        public abstract void UpdateValue(T changeValueOn);
        
        public void ReplaceValue(T newValue)
        {
            Value = newValue;
        }
    }
}