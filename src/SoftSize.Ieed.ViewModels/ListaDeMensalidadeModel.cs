using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftSize.Ieed.ViewModels
{
    public class ListaDeMensalidadeModel
    {
        public Guid IdUsuario { get; set; }
        public IEnumerable<LancamentoModel> MensalidadesModel { get; set; }
    }
}
