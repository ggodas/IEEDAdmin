using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace SoftSize.Ieed.ViewModels
{
    public class LancamentoModel
    {
        //public AssociadoModel Associado { get; set; }
        //public IEnumerable<MensalidadeModel> LancamentosDeMensalidades { get; set; }
        //public IEnumerable<LancamentoCerimoniaModel> LancamentosDeCerimonias { get; set; }
        public AssociadoModel Associado { get; set; }
        public Guid Id { get; set; }
        public CentroDeCustoViewModel CentroDeCustoLancamento { get; set; }
        public IEnumerable<dynamic> CentrosDeCusto { get; set; }

        public DateTime? DataPagamento { get; set; }

        public string Fornecedor { get; set; }

        public DateTime? DataDeVencimento { get; set; }
        public DateTime DataLancamento { get; set; }

        [Display(Description = "Valor da Mensalidade")]
        public decimal? Valor { get; set; }

     }

    public class CentroDeCustoViewModel
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Descrição do centro de Custo Requerido.")]
        public string Descricao { get; set; }
        public DateTime? Data { get; set; }

        public override string ToString()
        {
            return string.Format("{0} - {1:dd/MM/yyyy}", Descricao, Data);
        }
    }

    public class MensalidadeModel
    {
        public AssociadoModel Associado { get; set; }


        
        

        [Display(Description = "Valor da Mensalidade")]
        public decimal? Valor { get; set; }

    }
}
