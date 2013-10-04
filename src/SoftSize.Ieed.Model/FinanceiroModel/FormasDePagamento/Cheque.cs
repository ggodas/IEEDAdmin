using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftSize.Ieed.Model.FinanceiroModel.FormasDePagamento
{
    public class Cheque : FormaPagamentoBase
    {
        public virtual string Numero { get; set; }
        public virtual DateTime BomPara { get; set; }
    }
}
