using System;
using System.Collections.Generic;
using CTF.Fidelidade.Premmia.ViewModel;

namespace SoftSize.Ieed.ViewModels.ServiceInterfaces
{
    public interface IPerfilServiceApplication
    {
        IEnumerable<PerfilViewModel> RecuperarSubPerfisDeAcessoDo(Guid userId);

    }
}