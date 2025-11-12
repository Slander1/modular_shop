using System;

namespace Core.Data.Player.Stats.Variants
{
    public abstract class IntStatGenericBase : TypedStatBase<int>
    {
        public override void UpdateValue(int changeValueOn)
        {
            var updatedValue = Value + changeValueOn;
            if (updatedValue < 0) throw new ArgumentException("Value must be greater than or equal to 0 after UpdateValue");
            Value += changeValueOn;
        }

        public override bool IsSatisfied(int value)
        {
            return Value >= value;
        }
    }
}