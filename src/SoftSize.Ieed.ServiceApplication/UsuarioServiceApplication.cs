using System;
using System.Collections.Generic;
using System.Linq;
using CTF.Fidelidade.Premmia.ViewModel;
using SoftSize.Ieed.Model;
using SoftSize.Ieed.Model.ServiceInterfaces;
using SoftSize.Ieed.Model.UsuarioModel;
using SoftSize.Ieed.ModelMapping;
using SoftSize.Ieed.ViewModels;
using SoftSize.Ieed.ViewModels.ServiceInterfaces;

namespace SoftSize.Ieed.ServiceApplication
{
    public class UsuarioServiceApplication : IUsuarioServiceApplication
    {
        private readonly IUsuarioService usuarioService;
        private readonly IPerfilService perfilService;

        public UsuarioServiceApplication(IUsuarioService usuarioService, IPerfilService perfilService)
        {
            this.usuarioService = usuarioService;
            this.perfilService = perfilService;
        }

        public void Incluir(UsuarioViewModel usuarioViewModel)
        {
            Usuario usuario = new Usuario();
            usuario = usuarioViewModel.ToUsuario();
            usuarioService.Incluir(usuario);
        }

        public void Incluir(RegisterModel usuarioViewModel)
        {
            Usuario usuario = new Usuario();
            usuario = usuarioViewModel.ToUsuario();
            usuarioService.Incluir(usuario);
        }

        public void Alterar(UsuarioViewModel usuarioModel)
        {
            //var usuario = usuarioService.RecuperarPor(usuarioModel.Id);
            //usuario = usuarioModel.ToUsuario(usuario);

            //if (usuarioModel.PerfisDeAcessosAtribuidos != null)
            //{
            //    usuario.ExcluirTodosPerfis();
            //    foreach (var perfisDeAcessosAtribuido in usuarioModel.PerfisDeAcessosAtribuidos)
            //    {
            //        usuario.AssociarPerfil(perfilService.RecuperarPerfilDeAcessoPor(new Guid(perfisDeAcessosAtribuido)));
            //    }
            //}
            //usuarioService.Alterar(usuario);
        }


        public void Desativar(Guid userId)
        {
            var usuario = usuarioService.RecuperarPor(userId);
            usuarioService.Desativar(usuario);
        }

        public void AlterarSenha(ChangePasswordModel changePasswordModel)
        {
            var usuario = usuarioService.RecuperarPor(changePasswordModel.Id ?? new Guid());

            var usuarioValido = usuarioService.Validar(usuario.NomeDeUsuario, changePasswordModel.OldPassword);
            if (usuarioValido != null)
            {
                usuario.Senha = changePasswordModel.NewPassword;
                usuarioService.Alterar(usuario);
                return;
            }
            throw new InvalidOperationException("Talvez a senha atual esteja incorreta, ou a nova senha seja inválida.");
        }

        //public IEnumerable<UsuarioViewModel> RecuperarTodosInclusiveInativos()
        //{
        //    return usuarioService.RecuperarTodosInclusiveInativos().ToUsuariosViewModel();
        //}

        public UsuarioViewModel RecuperarPor(Guid userId, Guid? userManager = null)
        {
            var usuario = usuarioService.RecuperarPor(userId);
            var usuarioViewModel = usuario.ToUsuarioViewModel();
            usuarioViewModel.PerfisDeAcessosPermitidos = perfilService.RecuperarSubPerfisDeAcessoDo(userManager ?? userId).ToPerfisViewModel();
            usuarioViewModel.PerfisDeAcessosAtribuidos = usuario.PerfisDeAcesso.Select(p => p.Id);
            return usuarioViewModel;
        }

        public UsuarioViewModel RecuperarPor(string nomeUsuario, string senha)
        {
            var usuario = usuarioService.Validar(nomeUsuario, senha);
            return usuario.ToUsuarioViewModel();
        }

        public UsuarioViewModel RecuperarPor(string nomeUsuario)
        {
            var usuario = usuarioService.RecuperarPor(nomeUsuario);
            return usuario.ToUsuarioViewModel();
        }

    }
}
