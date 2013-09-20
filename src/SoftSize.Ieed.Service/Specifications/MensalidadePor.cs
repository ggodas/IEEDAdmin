using System;
using System.Linq.Expressions;
using LinqSpecs;
using SoftSize.Ieed.Model.FinanceiroModel.Lancamento;
using SoftSize.Ieed.Model.UsuarioModel;

namespace SoftSize.Ieed.Service
{
    public class LancamentoPorCentroDeCusto : Specification<LancamentoBase>
    {
        private CentroDeCustoLancamento centroDeCustoLancamento;
        public LancamentoPorCentroDeCusto(CentroDeCustoLancamento centroDeCustoLancamento)
        {
            this.centroDeCustoLancamento = centroDeCustoLancamento;
        }
        public override Expression<Func<LancamentoBase, bool>> IsSatisfiedBy()
        {
            return m => m.CentroDeCustoLancamento.Id == centroDeCustoLancamento.Id && !m.LancamentoCancelado;
        }
    }

    public class LancamentoPorAssociado : Specification<LancamentoBase>
    {
        private Associado associado;
        public LancamentoPorAssociado(Associado associado)
        {
            this.associado = associado;
        }
        public override Expression<Func<LancamentoBase, bool>> IsSatisfiedBy()
        {
            return m => m.Associado.Id == associado.Id && !m.LancamentoCancelado;
        }
    }

    //public class LancamentoPor : Specification<LancamentoBase>
    //{
    //    private LancamentoBase lancamentoBase;
    //    public LancamentoPor(LancamentoBase lancamentoBase)
    //    {
    //        this.lancamentoBase = lancamentoBase;
    //    }
    //    public override Expression<Func<LancamentoBase, bool>> IsSatisfiedBy()
    //    {
    //        return m => m.CentroDeCustoLancamento.Id == centroDeCustoLancamento.Id;
    //    }
    //}
}
