using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SoftSize.Infrastructure;

namespace SoftSize.Ieed.Model.UsuarioModel
{
    public class GrauEspiritual : Entity, IAggregateRoot
    {
        public virtual string Grau { get; set; }

    }
}
