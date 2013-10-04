
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace SoftSize.Ieed.ViewModels
{
    public class LancamentoCerimoniaModel
    {
        public Guid? Id { get; set; }

        public DateTime DataLancamento { get; set; }

        [Display(Name = "Cerimônia(Centro de Custo)")]
        [Required(ErrorMessage = "Necessário selecionar um centro de custo.")]
        public CentroDeCustoViewModel CentroDeCustoLancamento { get; set; }
        public IEnumerable<dynamic> CentrosDeCusto { get; set; }

        [Display(Name = "Valor")]
        [Required(ErrorMessage = "Valor da Cerimônia requerido.")]
        [DataType(DataType.Currency)]
        public virtual decimal? Valor { get; set; }

        public AssociadoModel Associado { get; set; }


    }
}
