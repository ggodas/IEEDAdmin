using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftSize.Ieed.ViewModels
{
    public class LancamentoMensalidadeLoteViewModel
    {
        public CentroDeCustoViewModel CentroDeCustoLancamento { get; set; }
        public IEnumerable<dynamic> CentrosDeCusto { get; set; }
    }
}
