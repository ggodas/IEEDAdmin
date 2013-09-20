using System;
using System.Collections.Generic;
using CTF.Fidelidade.Premmia.Domain.SSODomain;
using SoftSize.Infrastructure;

namespace SoftSize.Ieed.Model.UsuarioModel
{
    public class Usuario : Entity, IAggregateRoot
    {
        public Usuario()
        {
            perfisDeAcesso = new List<PerfilDeAcesso>();
            Ativo = true;
        }
        public virtual string Nome { get; set; }
        public virtual string NomeDeUsuario { get; set; }
        public virtual string Senha { get; set; }
        public virtual string Email { get; set; }
        public virtual bool Ativo { get; set; }
        public virtual bool PrimeiroLogin { get; set; }

        private IList<PerfilDeAcesso> perfisDeAcesso;
        public virtual IEnumerable<PerfilDeAcesso> PerfisDeAcesso
        {
            get { return perfisDeAcesso; }
        }

        public virtual void AdicionarPerfilDeAcesso(PerfilDeAcesso perfilDeAcesso)
        {
            perfisDeAcesso.Add(perfilDeAcesso);
        }

        public virtual Associado Associado { get; set; }

    }
}
