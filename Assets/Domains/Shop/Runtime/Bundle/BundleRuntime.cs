using System;
using System.Linq;
using Core.Data.Player;
using Shop.Bundle.Data;

namespace Shop.Bundle
{
    public sealed class BundleRuntime : IBundleRuntime, IDisposable
    {
        public event Action CostPlayerDataChanged;
        
        private readonly BundleData _data;
        private readonly IDataStorage _storage;
        
        public BundleRuntime(BundleData data, IDataStorage storage)
        {
            _data = data;
            _storage = storage;

            ConstructBricks(_storage);
            SubscribeOnPlayerDataChange();
        }
        
        public void Purchase()
        {
            if (!CanPurchase()) throw new ArgumentException("dont enough resources");
            
            foreach (var costBrickBase in _data.costBricks)
            {
                costBrickBase.ExecutePurchase();
            }
            
            foreach (var rewardBrick in _data.rewardBricks)
            {
                rewardBrick.GiveReward();
            }
            
            foreach (var changeableBrickBase in _data.changeableBricks)
            {
                changeableBrickBase.ChangeData();
            }
        }
        
        public bool CanPurchase()
        {
            return _data.costBricks.All(brick => brick.CanPurchase());
        }
        
        private void ConstructBricks(IDataStorage dataStorage)
        {
            var storage = dataStorage;
            
            foreach (var brick in _data.costBricks)
            {
                brick.Construct(storage);
            }
            
            foreach (var rewardBrickBase in _data.rewardBricks)
            {
                rewardBrickBase.Construct(storage);
            }
            
            foreach (var changeableBrick in _data.changeableBricks)
            {
                changeableBrick.Construct(storage);
            }
        }
        
        public void SubscribeOnPlayerDataChange()
        {
            foreach (var brick in _data.costBricks)
            {
                brick.Subscribe();
                brick.PlayerDataChanged += CostBrickOnPlayerDataChanged;
            }
        }

        public void UnsubscribeOnPlayerDataChange()
        {
            foreach (var brick in _data.costBricks)
            {
                brick.Unsubscribe();
                brick.PlayerDataChanged -= CostBrickOnPlayerDataChanged;
            }
        }
        
        private void CostBrickOnPlayerDataChanged()
        {
            CostPlayerDataChanged?.Invoke();
        }

        public void Dispose()
        {
            UnsubscribeOnPlayerDataChange();
        }
    }
}