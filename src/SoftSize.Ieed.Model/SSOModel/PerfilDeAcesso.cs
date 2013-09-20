using System.Collections.Generic;
using SoftSize.Infrastructure;

namespace CTF.Fidelidade.Premmia.Domain.SSODomain
{
    public class PerfilDeAcesso : Entity, IAggregateRoot//, IPerfilDeAcesso
    {
        public PerfilDeAcesso()
        {
            Permissoes = new List<Permissao>();
            subPerfis = new List<PerfilDeAcesso>();
        }
        //public virtual IEnumerable<Acesso> Acessos { get; protected set; }
        public virtual string Nome { get; set; }
        public virtual bool Ativo { get; set; }
        public virtual bool EPerfilPadrao { get; set; }
        public virtual bool EPerfilMaquina { get; set; }
        public virtual PerfilDeAcesso PerfilDeAcessoGerador { get; protected set; }
        private IList<PerfilDeAcesso> subPerfis;
        public virtual IEnumerable<PerfilDeAcesso> SubPerfis
        {
            get { return subPerfis; }
        }

        public virtual IList<Permissao> Permissoes { get; protected set; }

        public virtual void IncluirSubPerfil(PerfilDeAcesso perfilDeAcesso)
        {
            subPerfis.Add(perfilDeAcesso);
        }

    }
}
