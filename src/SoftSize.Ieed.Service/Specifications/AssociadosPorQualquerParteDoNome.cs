using System;
using System.Linq.Expressions;
using LinqSpecs;
using SoftSize.Ieed.Model.UsuarioModel;

namespace SoftSize.Ieed.Service
{
    public class AssociadosPorQualquerParteDoNome : Specification<Associado>
    {
        private readonly string nome;
        public AssociadosPorQualquerParteDoNome(string nome)
        {
            this.nome = nome;
        }
        public override Expression<Func<Associado, bool>> IsSatisfiedBy()
        {
            return m => m.Nome.ToLower().Contains(nome.ToLower());
        }
    }
}
