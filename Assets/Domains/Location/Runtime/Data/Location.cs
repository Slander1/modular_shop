using Core.Data.Player.Stats.Variants;

namespace Location.Data
{
    public sealed class Location : StringStateGenericBase
    {
        public override bool IsSatisfied(string newValue)
        {
            return true;
        }
    }
}