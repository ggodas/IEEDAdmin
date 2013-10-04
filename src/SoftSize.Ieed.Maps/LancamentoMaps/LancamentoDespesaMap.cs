using FluentNHibernate.Mapping;
using SoftSize.Ieed.Model.FinanceiroModel.Lancamento;

namespace SoftSize.Ieed.Maps.LancamentoMaps
{
	public class LancamentoDespesaMap : SubclassMap<LancamentoDespesa>
	{
	    public LancamentoDespesaMap()
	    {
	        Map(m => m.DataDeVencimento);
	        Map(m => m.Observacao);
	        Map(m => m.NumeroDoDocumento);
	        Map(m => m.Fornecedor).Length(100);
	        Map(m => m.DataCompra);

            Table("LancamentoDespesa");
	    }
	}
}
