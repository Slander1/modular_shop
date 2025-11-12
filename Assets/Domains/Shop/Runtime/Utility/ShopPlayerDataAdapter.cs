using Shop.Bundle.Data;

namespace Shop.Utility
{
    public sealed class ShopPlayerDataAdapter
    {
        public bool InButtonAvailable(BundleData bundleData)
        {
            foreach (var costBrick in bundleData.costBricks)
            {
                // costBrick.CanPurchase();
            }

            return true;
        }
    }
}