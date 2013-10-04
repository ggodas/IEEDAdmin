using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftSize.Ieed.ViewModels.ServiceInterfaces
{
    public interface ICentroDeCustoServiceApplication
    {
        void Inserir(CentroDeCustoViewModel centroDeCustoViewModel);
        IEnumerable<CentroDeCustoViewModel> CentrosDeCustoPor(string descricao);
    }
}
