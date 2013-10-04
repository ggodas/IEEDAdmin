using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using LinqSpecs;
using SoftSize.Ieed.Model.UsuarioModel;

namespace SoftSize.Ieed.Service
{
    public class AssociadosAtivos : Specification<Associado>
    {
        public override Expression<Func<Associado, bool>> IsSatisfiedBy()
        {
            return m => m.Ativo;
        }
    }
}
