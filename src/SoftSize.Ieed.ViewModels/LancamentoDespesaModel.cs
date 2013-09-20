using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SoftSize.Ieed.ViewModels
{
    public class LancamentoDespesaModel
    {
        [Display(Name = "Centro de Custo da Despesa")]
        [Required(ErrorMessage = "É necessário selecionar um Centro de Custo para manter a rastreabilidade da despesa.")]
        public virtual Guid CentroDeCustoLancamentoId { get; set; }
        public virtual IEnumerable<object> CentrosDeCusto { get; set; }


        [Display(Name = "Fornecedor")]
        [Required(ErrorMessage = "É necessário informar o Fornecedor.")]
        public string Fornecedor { get; set; }

        [Display(Name = "Data de Vencimento")]
        public DateTime? DataDeVencimento { get; set; }

        [Display(Name = "Data de Compra")]
        public DateTime? DataCompra { get; set; }
        
        [Display(Name = "Valor da Despesa")]
        [Required(ErrorMessage = "É necessário informar o valor da despesa.")]
        public decimal Valor { get; set; }

        [Display(Name = "Observações da Despesa")]
        public string Observacao { get; set; }

        [Display(Name = "Número do Documento")]
        public string NumeroDoDocumento { get; set; }

        [Display(Name = "Efetivar Pagamento")]
        public bool EfetivarPagamento { get; set; }
    }
}
