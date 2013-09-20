using System;
using System.Collections.Generic;
using System.Linq;
using CTF.Fidelidade.Premmia.Domain.SSODomain;
using SoftSize.Ieed.Model;
using SoftSize.Ieed.Model.ServiceInterfaces;
using SoftSize.Ieed.Model.UsuarioModel;
using SoftSize.Ieed.Service;
using SoftSize.Infrastructure;

namespace CTF.Fidelidade.Premmia.Service
{
    public class PermissaoService : IPermissaoService
    {
        private IRepository<Permissao> permissoes;
        private IRepository<Usuario> usuarios;

        public PermissaoService(IRepository<Permissao> permissoes, 
            IRepository<Usuario> usuarios)
        {
            this.permissoes = permissoes;
            this.usuarios = usuarios;
        }
        public Permissao RecuperarPermissoes()
        {
            throw new NotImplementedException();
        }

        public Permissao RecuperarPermissoesPor(int codPermissao)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Permissao> RecuperarPermissoesPor(string userName)
        {
            var usuario = usuarios.FindOne(new UsuariosPorLogin(userName));
            if (usuario.PerfisDeAcesso == null || usuario.PerfisDeAcesso.Count() == 0)
                return new List<Permissao>();

            //var permissoes = new List<Permissao>();

            //Action<IEnumerable<PerfilDeAcesso>> recuperarTodosNiveisDePermissoes = null;
            //recuperarTodosNiveisDePermissoes = perfis =>
            //                                       {
            //                                          foreach(var perfil in perfis)
            //                                          {
            //                                              permissoes.AddRange(perfil.Permissoes);

            //                                              if(perfil.SubPerfis != null && perfil.SubPerfis.Count() > 0)
            //                                              {
            //                                                  recuperarTodosNiveisDePermissoes(perfil.SubPerfis);
            //                                              }
            //                                          }
            //                                       };

            //recuperarTodosNiveisDePermissoes(usuario.PerfisDeAcesso);
            var permissoes = usuario.PerfisDeAcesso.SelectMany(perfilDeAcesso => perfilDeAcesso.Permissoes);
            

            return permissoes.Distinct();
        }

        //public IEnumerable<Permissao> RecuperarPermissoesPor(long entityId)
        //{
        //    var entidade = entidades.FindOne(new EntidadePorId(entityId));
        //    if (entidade.PerfisDeAcesso == null || entidade.PerfisDeAcesso.Count() == 0)
        //        return new List<Permissao>();

        //    return entidade.PerfisDeAcesso.SelectMany(perfilDeAcesso => perfilDeAcesso.Permissoes).Distinct().ToList();
        //}

        public IEnumerable<Permissao> RecuperarPermissoesDo(PerfilDeAcesso perfilDeAcesso)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<int> RecuperarCodigosDasPermissoesDo(PerfilDeAcesso perfilDeAcesso)
        {
            throw new NotImplementedException();
        }
    }
}
