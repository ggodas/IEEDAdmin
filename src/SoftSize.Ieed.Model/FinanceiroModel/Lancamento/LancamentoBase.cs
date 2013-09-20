using System;
using SoftSize.Ieed.Model.UsuarioModel;
using SoftSize.Infrastructure;

namespace SoftSize.Ieed.Model.FinanceiroModel.Lancamento
{
    public abstract class LancamentoBase: Entity, IAggregateRoot
    {
        protected LancamentoBase()
        {
            DataLancamento = DateTime.Now;
        }
        internal LancamentoBase(CentroDeCustoLancamento centroDeCustoLancamento)
        {
            CentroDeCustoLancamento = centroDeCustoLancamento;
            DataLancamento = DateTime.Now;
        }

        public virtual CentroDeCustoLancamento CentroDeCustoLancamento { get; set; }
        public virtual DateTime DataLancamento { get; protected set; }
        public virtual DateTime? DataPagamento { get; set; }
        public virtual decimal Valor { get; set; }
        public virtual bool LancamentoCancelado { get; set; }

        public virtual Associado Associado { get; set; }


    }
}
