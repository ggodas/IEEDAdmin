using System;
using System.Collections.Generic;
using CTF.Fidelidade.Premmia.ViewModel;

namespace SoftSize.Ieed.ViewModels.ServiceInterfaces
{
    public interface IUsuarioServiceApplication
    {
        void Incluir(UsuarioViewModel usuarioViewModel);
        void Incluir(RegisterModel usuarioViewModel);
        void Alterar(UsuarioViewModel usuarioModel);
        void Desativar(Guid userId);
        void AlterarSenha(ChangePasswordModel changePasswordModel);

        //IEnumerable<UsuarioViewModel> RecuperarTodosInclusiveInativos();
        UsuarioViewModel RecuperarPor(Guid userId, Guid? userManager = null);
        UsuarioViewModel RecuperarPor(string nomeUsuario, string senha);
        UsuarioViewModel RecuperarPor(string nomeUsuario);
    }
}