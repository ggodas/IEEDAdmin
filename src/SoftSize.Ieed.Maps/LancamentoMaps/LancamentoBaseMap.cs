using FluentNHibernate.Mapping;
using SoftSize.Ieed.Model.FinanceiroModel.Lancamento;

namespace SoftSize.Ieed.Maps.LancamentoMaps
{
    public sealed class LancamentoBaseMap : ClassMap<LancamentoBase>
    {
        public LancamentoBaseMap()
        {
            Id(m => m.Id).GeneratedBy.GuidComb();
            Version(m => m.Version);
            Map(m => m.Valor);
            Map(m => m.DataLancamento);
            Map(m => m.DataPagamento);
            Map(m => m.LancamentoCancelado);

            References(m => m.CentroDeCustoLancamento);
            References(m => m.Associado);

            
            Table("Lancamento");
        }
    }
}

