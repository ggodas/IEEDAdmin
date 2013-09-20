using System;
using System.Collections.Generic;
using CTF.Fidelidade.Premmia.Domain.SSODomain;

namespace SoftSize.Ieed.Model.ServiceInterfaces
{
    public interface IPerfilService
    {
        IEnumerable<PerfilDeAcesso> RecuperarSubPerfisDeAcessoDo(Guid login);
        PerfilDeAcesso RecuperarPerfilDeAcessoPor(Guid userId);
        PerfilDeAcesso RecuperarPerfilPadrao();
    }
}
