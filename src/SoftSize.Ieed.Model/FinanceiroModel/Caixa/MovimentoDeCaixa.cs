using System;
using System.Collections.Generic;
using SoftSize.Ieed.Model.FinanceiroModel.FormasDePagamento;
using SoftSize.Ieed.Model.FinanceiroModel.Lancamento;
using SoftSize.Infrastructure;

namespace SoftSize.Ieed.Model.FinanceiroModel.Caixa
{
    public abstract class MovimentoDeCaixa : Entity, IAggregateRoot
    {
        public virtual DateTime DataDaMovimentacao { get; set; }
        public virtual decimal Total { get; set; }

        public virtual int NumeroDocumento { get; set; }
        public virtual LancamentoBase LancamentoBase { get; set; }
        public abstract void CalcularTotal(decimal total);
        public virtual IEnumerable<FormaPagamentoBase> FormasDePagamento { get; set; }

    }
}