using FluentNHibernate.Mapping;
using SoftSize.Ieed.Model.FinanceiroModel.FormasDePagamento;
using SoftSize.Ieed.Model.FinanceiroModel.Lancamento;

namespace SoftSize.Ieed.Maps.LancamentoMaps
{
    public sealed class ChequeMap : SubclassMap<Cheque>
    {
        public ChequeMap()
        {
            Map(m => m.BomPara, "ChequeBomPara");
            Map(m => m.Numero, "ChequeNumero");
        }
    }
}

