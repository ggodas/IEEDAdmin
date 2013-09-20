using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SoftSize.Ieed.Model.FinanceiroModel.Lancamento;
using SoftSize.Ieed.ModelMapping;
using SoftSize.Ieed.ViewModels;
using SoftSize.Ieed.ViewModels.ServiceInterfaces;
using SoftSize.Infrastructure;

namespace SoftSize.Ieed.ServiceApplication
{
    public class CentroDeCustoServiceApplication : ICentroDeCustoServiceApplication
    {
        private IRepository<CentroDeCustoLancamento> centrosDeCusto;
        public CentroDeCustoServiceApplication(IRepository<CentroDeCustoLancamento> centrosDeCusto)
        {
            this.centrosDeCusto = centrosDeCusto;
        }
        public void Inserir(CentroDeCustoViewModel centroDeCustoViewModel)
        {
            var centroDeCustoLancamento = centroDeCustoViewModel.ToCentroDeCustoLancamento();
            centrosDeCusto.Add(centroDeCustoLancamento);
        }

        public IEnumerable<CentroDeCustoViewModel> CentrosDeCustoPor(string descricao)
        {
            return centrosDeCusto.Where(m => 
                m.Descricao
                .ToLower()
                .Contains(descricao.ToLower())
                ).ToCentrosDeCustoViewModel();
        }
    }
}