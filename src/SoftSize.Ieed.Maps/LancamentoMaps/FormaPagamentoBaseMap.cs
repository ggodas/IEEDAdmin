using FluentNHibernate.Mapping;
using SoftSize.Ieed.Model.FinanceiroModel.FormasDePagamento;
using SoftSize.Ieed.Model.FinanceiroModel.Lancamento;

namespace SoftSize.Ieed.Maps.LancamentoMaps
{
    public sealed class FormaPagamentoBaseMap : ClassMap<FormaPagamentoBase>
    {
        public FormaPagamentoBaseMap()
        {
            Id(m => m.Id).GeneratedBy.GuidComb();
            Version(m => m.Version);
            Map(m => m.Valor);


            Table("FormaPagamento");
            DiscriminateSubClassesOnColumn("TipoFormaPagamento");
        }
    }
}

