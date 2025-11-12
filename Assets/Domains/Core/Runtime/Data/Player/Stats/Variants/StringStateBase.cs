namespace Core.Data.Player.Stats.Variants
{
    public abstract class StringStateBase : StatBase<string>
    {
        public override void UpdateValue(string changeValueOn)
        {
            ReplaceValue(changeValueOn);
        }
    }
}