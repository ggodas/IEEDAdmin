using System;
using System.Collections.Generic;
using System.Linq;
using CTF.Fidelidade.Premmia.Domain.SSODomain;
using SoftSize.Ieed.Model.ServiceInterfaces;
using SoftSize.Ieed.Model.UsuarioModel;
using SoftSize.Infrastructure;

namespace SoftSize.Ieed.Service
{
    public class PerfilService : IPerfilService
    {

        private IRepository<PerfilDeAcesso> perfisDeAcesso;
        private IRepository<Usuario> usuarios;
        public PerfilService(IRepository<PerfilDeAcesso> perfisDeAcesso, IRepository<Usuario> usuarios)
        {
            this.perfisDeAcesso = perfisDeAcesso;
            this.usuarios = usuarios;
        }

        public PerfilDeAcesso RecuperarPerfilDeAcessoPor(Guid userId)
        {
            return perfisDeAcesso.First(p => p.Id == userId);
        }

        public PerfilDeAcesso RecuperarPerfilPadrao()
        {
            return perfisDeAcesso.FindOne(new PerfilPadrao());
        }


        public IEnumerable<PerfilDeAcesso> RecuperarSubPerfisDeAcessoDo(Guid userId)
        {
            IList<PerfilDeAcesso> perfilDeAcessos = new List<PerfilDeAcesso>();

            var usuario = usuarios.First(u => u.Id == userId);

            Action<PerfilDeAcesso> CarregarPerfis = null;

            CarregarPerfis = perfilDeAcesso =>
                             {
                                 perfilDeAcessos.Add(perfilDeAcesso);
                                 foreach (var perfil in perfilDeAcesso.SubPerfis)
                                 {
                                     perfilDeAcessos.Add(perfil);
                                     if (perfil.SubPerfis.Count() > 0)
                                     {
                                         CarregarPerfis(perfil);
                                     }
                                 }
                             };

            foreach (var perfilDeAcesso in usuario.PerfisDeAcesso)
            {
                CarregarPerfis(perfilDeAcesso);
            }

            //foreach (var perfilDeAcesso in usuario.PerfisDeAcesso)
            //{
            //    perfilDeAcessos.Add(perfilDeAcesso);
            //    foreach (var deAcesso in perfilDeAcesso.SubPerfis)
            //    {
            //        perfilDeAcessos.Add(deAcesso);
            //    }
            //}
            return perfilDeAcessos.Distinct();
        }
    }
}
