using UnityEngine;

namespace Core.Data.Base
{
    public abstract class StatKey : ScriptableObject
    {
        public abstract System.Type StatType { get; }
    }
}