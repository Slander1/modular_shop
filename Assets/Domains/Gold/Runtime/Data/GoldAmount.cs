using Core.Data.Player.Stats;
using Core.Data.Player.Stats.Variants;

namespace Gold.Data
{
    public sealed class GoldAmount : IntStatGenericBase
    {
        //TODO : подгружать с конфигов
        public override int DefaultValue => 100;
    }
}