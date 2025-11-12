using Core.Data.Base;
using Core.Data.Player;

namespace Core.Data.Bundle.BundleBrick
{
    public abstract class BrickBase : StatKey
    {
        protected IDataStorage CachedDataStorage;
 
        public void Construct(IDataStorage storage)
        {
            CachedDataStorage = storage;
        }
    }
}