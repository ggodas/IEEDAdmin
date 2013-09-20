using System.Collections.Generic;
using CTF.Fidelidade.Premmia.Domain.SSODomain;

namespace SoftSize.Ieed.Model.ServiceInterfaces
{
    public interface IPermissaoService
    {
        Permissao RecuperarPermissoes();
        Permissao RecuperarPermissoesPor(int codPermissao);
        IEnumerable<Permissao> RecuperarPermissoesPor(string userName);
        IEnumerable<Permissao> RecuperarPermissoesDo(PerfilDeAcesso perfilDeAcesso);
        IEnumerable<int> RecuperarCodigosDasPermissoesDo(PerfilDeAcesso perfilDeAcesso);


    }
}
