using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using LinqSpecs;
using SoftSize.Ieed.Model.FinanceiroModel.Lancamento;

namespace SoftSize.Ieed.Service.Specifications
{
    public class CerimoniaPor : Specification<LancamentoCerimonia>
    {
        private LancamentoCerimonia lancamentoCerimonia;
        public CerimoniaPor(LancamentoCerimonia lancamentoCerimonia)
        {
            this.lancamentoCerimonia = lancamentoCerimonia;
        }
        public override Expression<Func<LancamentoCerimonia, bool>> IsSatisfiedBy()
        {
            return m => m.CentroDeCustoLancamento.Id == 
                lancamentoCerimonia.CentroDeCustoLancamento.Id && 
                m.Associado.Id == lancamentoCerimonia.Associado.Id && 
                m.LancamentoCancelado != true;
        }
    }
}
