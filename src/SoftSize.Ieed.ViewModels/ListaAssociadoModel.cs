using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftSize.Ieed.ViewModels
{
    public class ListaAssociadoModel
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string AssociadoDetalheCPF { get; set; }

        public bool Dependente { get; set; }

        public IList<ListaAssociadoModel> ListaAssociadoModels { get; set; }
    }
}
