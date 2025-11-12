using UnityEngine;

namespace Shop.Bundle.Data
{
    [CreateAssetMenu(
        menuName = "Shop/Bundles Data",
        fileName = "BundlesData",
        order = 0)]
    
    public sealed class BundlesData : ScriptableObject
    {
        public BundleData[] bundles;
    }
}