using FluentNHibernate.Mapping;
using SoftSize.Ieed.Model.FinanceiroModel;
using SoftSize.Ieed.Model.FinanceiroModel.Caixa;

namespace SoftSize.Ieed.Maps
{
    public sealed class MovimentoDeCaixaMap : ClassMap<MovimentoDeCaixa>
    {
        public MovimentoDeCaixaMap()
        {
            Id(m => m.Id).GeneratedBy.GuidComb();

            Map(m => m.DataDaMovimentacao);
            Map(m => m.Total);
            Map(m => m.NumeroDocumento);

            Version(m => m.Version);

            References(m => m.LancamentoBase);
            
            DiscriminateSubClassesOnColumn("TipoDeMovimento");
            Table("MovimentoDeCaixa");

        }
    }
    public class DebitoMap : SubclassMap<MovimentoDeCaixaDebito>
    {
        public DebitoMap()
        {
            Map(m => m.Debito);
        }
    }

    public class CreditoMap : SubclassMap<MovimentoDeCaixaCredito>
    {
        public CreditoMap()
        {
            Map(m => m.Credito);
        }
    }
}

