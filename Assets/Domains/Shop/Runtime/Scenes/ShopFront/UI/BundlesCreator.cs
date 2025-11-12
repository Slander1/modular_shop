using System.Collections.Generic;
using Shop.Bundle.Data;
using Shop.Scenes.ShopFront.ShopItem;
using UnityEngine;

namespace Shop.Scenes.ShopFront.UI
{
    // ReSharper disable once ClassNeverInstantiated.Global
    public sealed class BundlesCreator
    {
        public static List<ShopBundle> CreateAndInitBundles(Transform bundlesContainer, ShopBundle shopBundlePrefab, BundlesData bundleData)
        {
            var bundles = new List<ShopBundle>(bundleData.bundles.Length);
            
            foreach (var bundle in bundleData.bundles)
            {
                var createdBundle = Object.Instantiate(shopBundlePrefab, bundlesContainer);
                createdBundle.Construct(bundle);
                bundles.Add(createdBundle);
            }

            return bundles;
        }
    }
}