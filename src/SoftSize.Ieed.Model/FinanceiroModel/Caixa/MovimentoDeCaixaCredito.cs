using System;
using SoftSize.Ieed.Model.FinanceiroModel.Lancamento;

namespace SoftSize.Ieed.Model.FinanceiroModel.Caixa
{
    public class MovimentoDeCaixaCredito : MovimentoDeCaixa
    {
        protected MovimentoDeCaixaCredito()
        {

        }
        internal MovimentoDeCaixaCredito(LancamentoBase lancamentoBase)
        {
            base.LancamentoBase = lancamentoBase;
        }


        public virtual decimal Credito { get; set; }
        public override void CalcularTotal(decimal total)
        {
            this.Total = total + Credito;
        }
    }
}
