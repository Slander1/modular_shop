namespace Core.Data.Player.Stats
{
    public abstract class StatGenericBase<T> : ITypedPlayerStat<T>
    {
        public abstract T DefaultValue { get; }

        public T CurrentValue { get; protected set; }

        protected StatGenericBase()
        {
            LoadDataSnapshotFromStorage();
        }
        
        public abstract void UpdateValue(T changeValueOn);
        
        public void ReplaceValue(T newValue)
        {
            CurrentValue = newValue;
        }

        public abstract bool IsSatisfied(T newValue);

        //TODO : важная деталь
        /// <summary>
        /// Тут должна быть переопределенная в своем .asmdef логика загрузки с диска
        /// Согласно ТЗ данную логику скипаем и просто выставляем дефолтное значение
        /// </summary>
        protected void LoadDataSnapshotFromStorage()
        {
            CurrentValue = DefaultValue;
        }
    }
}