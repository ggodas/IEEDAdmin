using System;
using System.Collections.Generic;
using System.Linq;
using SoftSize.Ieed.Model;
using SoftSize.Ieed.Model.ServiceInterfaces;
using SoftSize.Ieed.Model.UsuarioModel;
using SoftSize.Infrastructure;

namespace SoftSize.Ieed.Service
{
    public class UsuarioService : IUsuarioService
    {
        private IRepository<Usuario> usuarios;
        private IPerfilService perfilService;
        public UsuarioService(IRepository<Usuario> usuarios, IPerfilService perfilService)
        {
            this.usuarios = usuarios;
            this.perfilService = perfilService;
        }
        public void Incluir(Usuario usuario)
        {
            var existeUsuarioComMesmoLogin = usuarios.FindAll(new UsuariosPorLogin(usuario.NomeDeUsuario));
            usuario.AdicionarPerfilDeAcesso(perfilService.RecuperarPerfilPadrao());

            if (existeUsuarioComMesmoLogin.Count() > 0)
                throw new InvalidOperationException("Nome de Usuário já existente");

            if (usuario.PerfisDeAcesso.Count() == 0)
                throw new InvalidOperationException("Usuário sem Perfil atribuido.");
            usuarios.Add(usuario);
        }

        public void Alterar(Usuario usuario)
        {
            usuarios.Add(usuario);
        }

        public void Desativar(Usuario usuario)
        {
            //usuario.Ativo = false;
            usuarios.Add(usuario);
        }

        public Usuario Validar(string login, string senha)
        {
            return usuarios.FindOne(new UsuariosPorLogin(login) & new UsuariosPorSenha(senha));
        }

        public IEnumerable<Usuario> RecuperarTodosInclusiveInativos()
        {
            return usuarios;
        }
        
        public IEnumerable<Usuario> RecuperarTodosExcetoInativos()
        {
            return usuarios;
        }

        public Usuario RecuperarPor(Guid userId)
        {
            return usuarios.FindOne(new UsuariosPorId(userId));
        }

        public Usuario RecuperarPor(string userName)
        {
            return usuarios.FindOne(new UsuariosPorLogin(userName));
        }
    }
}
