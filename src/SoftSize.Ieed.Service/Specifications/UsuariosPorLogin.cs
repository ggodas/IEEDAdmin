using System;
using System.Linq.Expressions;
using LinqSpecs;
using SoftSize.Ieed.Model.UsuarioModel;

namespace SoftSize.Ieed.Service
{
    public class UsuariosPorLogin : Specification<Usuario>
    {
        private readonly string nomeDeUsuario;
        public UsuariosPorLogin(string nomeDeUsuario)
        {
            this.nomeDeUsuario = nomeDeUsuario;
        }
        public override Expression<Func<Usuario, bool>> IsSatisfiedBy()
        {
            return m => m.NomeDeUsuario == nomeDeUsuario;
        }
    }

    public class UsuariosPorId : Specification<Usuario>
    {
        private readonly Guid userId;
        public UsuariosPorId(Guid userId)
        {
            this.userId = userId;
        }
        public override Expression<Func<Usuario, bool>> IsSatisfiedBy()
        {
            return m => m.Id == userId;
        }
    }

    //public class UsuariosAtivos : Specification<Usuario>
    //{
    //    public override Expression<Func<Usuario, bool>> IsSatisfiedBy()
    //    {
    //        return m => m.Ativo;
    //    }
    //}
}
