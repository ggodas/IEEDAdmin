using System;
using System.Collections.Generic;
using CTF.Fidelidade.Premmia.ViewModel;

namespace SoftSize.Ieed.ViewModels.ServiceInterfaces
{
    public interface IPermissaoServiceApplication
    {
        IEnumerable<PermissaoViewModel> RecuperarPermissoesPor(string userName);
    }
}