using System;
using System.Collections.Generic;
using SoftSize.Infrastructure;

namespace CTF.Fidelidade.Premmia.Domain.SSODomain
{
    public class Permissao : Entity, IAggregateRoot
    {

        public Permissao()
        {
            subPermissoes = new List<Permissao>();
        }
        public virtual string NomePermissao { get; set; }
        public virtual string NomeDaFuncionalidade { get; set; }
        public virtual bool Privado { get; set; }


        public virtual Permissao PermissaoPai { get; protected set; }
        
        private IList<Permissao> subPermissoes;
        public virtual IEnumerable<Permissao> SubPermissoes
        {
            get { return subPermissoes; }
        }

        public virtual void IncluirSubPermissao(Permissao permissao)
        {
            subPermissoes.Add(permissao);
        }

        public virtual Permissao RecuperarPermissaoGeradora()
        {
            Func<Permissao, Permissao> recuperarPai = null;
            recuperarPai = permissao =>
                                                           {
                                                               if (permissao.PermissaoPai != null)
                                                               {
                                                                   return recuperarPai(permissao.PermissaoPai);
                                                                   //recuper
                                                                   //recuperarPai(permissao.PermissaoPai);
                                                               }
                                                               return permissao;
                                                           };
            return recuperarPai(this);
        }
    }
}
