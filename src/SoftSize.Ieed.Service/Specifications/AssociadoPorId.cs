using System;
using System.Linq.Expressions;
using LinqSpecs;
using SoftSize.Ieed.Model.UsuarioModel;
using SoftSize.Infrastructure.CustomExtensions;

namespace SoftSize.Ieed.Service
{
    public class AssociadoPorId : Specification<Associado>
    {
        private readonly Guid id;
        public AssociadoPorId(Guid id)
        {
            this.id = id;
        }
        public override Expression<Func<Associado, bool>> IsSatisfiedBy()
        {
            return m => m.Id == id;
        }
    }
}
