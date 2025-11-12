using System;
using UnityEngine;

namespace Core.Data.Bundle.BundleBrick
{
    public abstract class BrickBase : ScriptableObject
    {
        public abstract Type StatType { get; }
    }
}