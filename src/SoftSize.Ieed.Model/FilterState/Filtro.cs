using System;
using System.Collections.Generic;
using SoftSize.Ieed.Model.UsuarioModel;
using SoftSize.Infrastructure;

namespace SoftSize.Ieed.Model.FilterState
{
    public class Filtro : Entity, IAggregateRoot
    {
        public virtual Usuario Usuario { get; set; }
        public virtual string Nome { get; set; }
        public virtual Guid FuncionalidadeId { get; set; }
        public virtual IList<ItemFiltro> ItensFiltro { get; private set; }

        public virtual void RemoverTodosItensFiltro()
        {
            ItensFiltro.Clear();
        }
    }


    public class ItemFiltro : Entity
    {
        public virtual string Key { get; set; }
        public virtual string Value { get; set; }

        public virtual Filtro Filtro { get; set; }
    }
}
