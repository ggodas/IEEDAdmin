using System;
using SoftSize.Ieed.Model.ServiceInterfaces;

namespace SoftSize.Ieed.Model.FinanceiroModel.Lancamento
{
    public class LancamentoDespesa : LancamentoBase, IDebito
    {
        public virtual DateTime? DataDeVencimento { get; set; }
        public virtual DateTime DataCompra { get; set; }
        public virtual string Observacao { get; set; }
        public virtual string NumeroDoDocumento { get; set; }
        public virtual string Fornecedor { get; set; }
    }
}
