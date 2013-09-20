using FluentNHibernate.Mapping;
using SoftSize.Ieed.Model.FinanceiroModel.Lancamento;

namespace SoftSize.Ieed.Maps.LancamentoMaps
{
    public class LancamentoDoacaoMap : SubclassMap<LancamentoDoacao>
    {
        public LancamentoDoacaoMap()
        {
            Table("LancamentoDoacao");
        }
    }
}

