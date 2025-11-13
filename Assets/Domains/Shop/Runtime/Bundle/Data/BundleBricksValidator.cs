#if UNITY_EDITOR
using System;
using System.Collections.Generic;
using Core.Data.Bundle.BundleBrick;
using UnityEngine;

namespace Shop.Bundle.Data
{
    internal static class BundleBricksValidator
    {
        public static T[] RemoveDuplicatesByStatType<T>(T[] bricks) where T : BrickBase
        {
            if (bricks == null)
                return null;

            var seen = new HashSet<Type>();
            var result = new List<T>();

            foreach (var brick in bricks)
            {
                if (brick == null)
                {
                    result.Add(null);
                    continue;
                }

                var statType = brick.StatType;
                if (seen.Add(statType))
                {
                    result.Add(brick);
                }
                else
                {
                    result.Add(null);
                    Debug.LogWarning($"Stat type {statType} is already used by another brick in bundle {brick.name}");
                }
            }

            return result.ToArray();
        }
    }
}
#endif