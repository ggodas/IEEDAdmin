using System;
using SoftSize.Ieed.Model.FinanceiroModel.Lancamento;

namespace SoftSize.Ieed.Model.FinanceiroModel.Caixa
{
    public class MovimentoDeCaixaDebito : MovimentoDeCaixa
    {
        protected MovimentoDeCaixaDebito()
        {

        }
        internal MovimentoDeCaixaDebito(LancamentoBase lancamentoBase)
        {
            base.LancamentoBase = lancamentoBase;
        }

        public virtual decimal Debito { get; set; }
        public override void CalcularTotal(decimal total)
        {
            this.Total = total - Debito;
        }
    }
}
