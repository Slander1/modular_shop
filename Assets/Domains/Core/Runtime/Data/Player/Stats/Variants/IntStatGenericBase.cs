using System;

namespace Core.Data.Player.Stats.Variants
{
    public abstract class IntStatGenericBase : StatGenericBase<int>
    {
        public override void UpdateValue(int changeValueOn)
        {
            var updatedValue = CurrentValue + changeValueOn;
            if (updatedValue < 0) throw new ArgumentException("Value must be greater than or equal to 0 after UpdateValue");
            CurrentValue += changeValueOn;
        }
    }
}