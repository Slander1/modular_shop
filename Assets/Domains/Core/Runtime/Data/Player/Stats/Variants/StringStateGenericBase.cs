namespace Core.Data.Player.Stats.Variants
{
    public abstract class StringStateGenericBase : StatGenericBase<string>
    {
        public override void UpdateValue(string changeValueOn)
        {
            ReplaceValue(changeValueOn);
        }
    }
}