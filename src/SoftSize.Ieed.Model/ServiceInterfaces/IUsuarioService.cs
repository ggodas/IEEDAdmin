using System;
using System.Collections.Generic;
using SoftSize.Ieed.Model.UsuarioModel;

namespace SoftSize.Ieed.Model.ServiceInterfaces
{
    public interface IUsuarioService
    {
        void Incluir(Usuario usuario);
        void Alterar(Usuario usuario);
        void Desativar(Usuario usuario);
        Usuario Validar(string login, string senha);
        IEnumerable<Usuario> RecuperarTodosInclusiveInativos();
        IEnumerable<Usuario> RecuperarTodosExcetoInativos();
        Usuario RecuperarPor(Guid userId);
        Usuario RecuperarPor(string userName);

    }
}
