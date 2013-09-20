using System;
using System.Collections.Generic;
using SoftSize.Infrastructure;

namespace SoftSize.Ieed.Model.FinanceiroModel.Lancamento
{
    public class CentroDeCustoLancamento : Entity, IAggregateRoot
    {

        public virtual string Descricao { get; set; }
        public virtual DateTime Data { get; set; }
        public virtual IEnumerable<LancamentoBase> LancamentosBase { get; set; }
    }
}
