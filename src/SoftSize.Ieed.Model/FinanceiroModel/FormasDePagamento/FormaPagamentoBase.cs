using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SoftSize.Infrastructure;

namespace SoftSize.Ieed.Model.FinanceiroModel.FormasDePagamento
{
    public abstract class FormaPagamentoBase : Entity
    {
        public virtual string Valor { get; set; }
    }
}
