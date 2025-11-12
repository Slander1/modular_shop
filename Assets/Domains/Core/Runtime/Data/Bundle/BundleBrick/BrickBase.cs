using Core.Data.Base;
using Core.Data.Player;

namespace Core.Data.Bundle.BundleBrick
{
    public abstract class BrickBase : StatKey
    {
        protected IDataStorage CashedDataStorage;
 
        public void Construct(IDataStorage storage)
        {
            CashedDataStorage = storage;
        }
    }
}