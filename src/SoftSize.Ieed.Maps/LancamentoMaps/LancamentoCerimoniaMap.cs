using SoftSize.Ieed.Model.FinanceiroModel.Lancamento;
using FluentNHibernate.Mapping;

namespace SoftSize.Ieed.Maps.LancamentoMaps
{
    public class LancamentoCerimoniaMap : SubclassMap<LancamentoCerimonia>
    {
        public LancamentoCerimoniaMap()
        {
            Table("LancamentoCerimonia");
        }
    }
}

