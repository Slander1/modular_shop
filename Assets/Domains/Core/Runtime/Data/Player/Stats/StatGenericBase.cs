namespace Core.Data.Player.Stats
{
    public abstract class StatGenericBase<T> : ITypedPlayerStat<T>
    {
        public T Value { get; protected set; }

        protected StatGenericBase()
        { }
        
        public abstract void UpdateValue(T changeValueOn);
        
        public void ReplaceValue(T newValue)
        {
            Value = newValue;
        }

        public abstract bool IsSatisfied(T newValue);
    }
}