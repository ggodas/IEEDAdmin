using System;
using System.Collections.Generic;
using CTF.Fidelidade.Premmia.ViewModel;
using SoftSize.Ieed.Model;
using SoftSize.Ieed.Model.ServiceInterfaces;
using SoftSize.Ieed.ModelMapping;
using SoftSize.Ieed.ViewModels.ServiceInterfaces;

namespace SoftSize.Ieed.ServiceApplication
{
    public class PermissaoServiceApplication : IPermissaoServiceApplication
    {
        private readonly IPermissaoService permissaoService;
        public PermissaoServiceApplication(IPermissaoService permissaoService)
        {
            this.permissaoService = permissaoService;
        }
        public IEnumerable<PermissaoViewModel> RecuperarPermissoesPor(string userName)
        {
            return permissaoService.RecuperarPermissoesPor(userName).ToPermissoesViewModel();
        }
    }
}
