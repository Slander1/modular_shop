using Core.Data.Player;
using Shop.Bundle.Data;

namespace Shop.Utility
{
    public sealed class ShopPlayerDataAdapter
    {
        public bool InButtonAvailable(BundleData bundleData)
        {
            var playerData = PlayerData.Instance;
            
            foreach (var costBrick in bundleData.costBricks)
            {
                // var key = costBrick;
                playerData.IsSatisfied<>(key)
            }
        }
    }
}