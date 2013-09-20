using System;
using System.Linq.Expressions;
using LinqSpecs;
using SoftSize.Ieed.Model.UsuarioModel;

namespace SoftSize.Ieed.Service
{
    public class UsuariosPorSenha : Specification<Usuario>
    {
        private readonly string senha;
        public UsuariosPorSenha(string senha)
        {
            this.senha = senha;
        }
        public override Expression<Func<Usuario, bool>> IsSatisfiedBy()
        {
            return m => m.Senha == senha;
        }
    }
}
