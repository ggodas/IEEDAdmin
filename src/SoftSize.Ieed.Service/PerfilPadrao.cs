using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using CTF.Fidelidade.Premmia.Domain.SSODomain;
using LinqSpecs;
using SoftSize.Ieed.Model.UsuarioModel;

namespace SoftSize.Ieed.Service
{
    public class PerfilPadrao : Specification<PerfilDeAcesso>
    {
        public override Expression<Func<PerfilDeAcesso, bool>> IsSatisfiedBy()
        {
            return m => m.EPerfilPadrao;
        }
    }
}
