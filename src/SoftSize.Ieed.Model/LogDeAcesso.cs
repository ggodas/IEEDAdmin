using System;
using SoftSize.Ieed.Model.UsuarioModel;
using SoftSize.Infrastructure;

namespace SoftSize.Ieed.Model
{
    public class LogDeAcesso : Entity, IAggregateRoot
    {
        public virtual Usuario Usuario { get; set; }
        public virtual DateTime DataDeAcesso { get; set; }
        public virtual string IP { get; set; }
        public virtual string Controller { get; set; }
        public virtual string Action { get; set; }
        public virtual string Parameters { get; set; }
        public virtual string Observacao { get; set; }
        public virtual string HostName { get; set; }
    }
}
