namespace Core.Data.Player.Stats.Variants
{
    public abstract class StringStateGenericBase : TypedStatBase<string>
    {
        public override void UpdateValue(string changeValueOn)
        {
            ReplaceValue(changeValueOn);
        }
    }
}