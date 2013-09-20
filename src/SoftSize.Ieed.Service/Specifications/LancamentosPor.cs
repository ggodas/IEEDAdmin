using System;
using System.Linq.Expressions;
using LinqSpecs;
using SoftSize.Ieed.Model.FinanceiroModel.Lancamento;

namespace SoftSize.Ieed.Service.Specifications
{
    public class LancamentosPor : Specification<LancamentoBase>
    {
        private Guid id;

        public LancamentosPor(Guid id)
        {
            this.id = id;
        }

        public override Expression<Func<LancamentoBase, bool>> IsSatisfiedBy()
        {
            return m => m.Id == id;
        }
    }
}
