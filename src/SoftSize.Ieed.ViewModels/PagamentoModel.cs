using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftSize.Ieed.ViewModels
{
    public class PagamentoModel
    {
        public int NumeroRecibo { get; set; }
        public string[] LancamentoModelPagar { get; set; }
    }

    public class PagementosSelecionadosModel
    {
        public IEnumerable<PagamentoItemModel> PagamentoItens { get; set; }
        public decimal RecuperarTotal()
        {
            return PagamentoItens.Sum(m => m.Valor);
        }
    }
    public class PagamentoItemModel
    {
        public Guid Id { get; set; }
        public DateTime DataLancamento { get; set; }
        public DateTime? DataPagamento { get; set; }
        public decimal Valor { get; set; }
        public bool LancamentoCancelado { get; set; }
        public CentroDeCustoViewModel CentroDeCustoLancamento { get; set; }
        public string Tipo { get; set; }
       
    }
}
