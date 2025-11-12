using UnityEngine;

namespace Core.Data.Bundle
{
    [CreateAssetMenu(
        menuName = "Core/Bundle Data",
        fileName = "BundleData",
        order = 0)]
    
    public class BundleData : ScriptableObject
    {
        [Header("UI")]
        public string bundleName;
        
        // [Space]
        // [Header("Config")]
        // public 
    }
}