using System;
using System.Collections.Generic;
using CTF.Fidelidade.Premmia.ViewModel;
using SoftSize.Ieed.Model;
using SoftSize.Ieed.Model.ServiceInterfaces;
using SoftSize.Ieed.ModelMapping;
using SoftSize.Ieed.ViewModels.ServiceInterfaces;

namespace SoftSize.Ieed.ServiceApplication
{
    public class PerfilServiceApplication : IPerfilServiceApplication
    {
        private IPerfilService perfilService;
        public PerfilServiceApplication(IPerfilService perfilService)
        {
            this.perfilService = perfilService;
        }

        public IEnumerable<PerfilViewModel> RecuperarSubPerfisDeAcessoDo(Guid userId)
        {
            return perfilService.RecuperarSubPerfisDeAcessoDo(userId).ToPerfisViewModel();
        }
    }
}
