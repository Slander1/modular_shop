namespace Core.Data.Bundle.BundleBrick.ChangeData
{
    public abstract class TypedDataChangeableBrick<T> : DataChangeableBrickBase
    {
        public T newData;
    }
}