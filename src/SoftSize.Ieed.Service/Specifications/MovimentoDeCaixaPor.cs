using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using LinqSpecs;
using SoftSize.Ieed.Model.FinanceiroModel.Caixa;
using SoftSize.Ieed.Model.FinanceiroModel.Lancamento;

namespace SoftSize.Ieed.Service.Specifications
{
    public class MovimentoDeCaixaPor : Specification<MovimentoDeCaixa>
    {
        private LancamentoBase lancamentoBase;
        public MovimentoDeCaixaPor(LancamentoBase lancamentoBase)
        {
            this.lancamentoBase = lancamentoBase;
        }
        public override Expression<Func<MovimentoDeCaixa, bool>> IsSatisfiedBy()
        {
            return m => m.LancamentoBase.Id == lancamentoBase.Id;
        }
    }
}
