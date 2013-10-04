using System;
using System.Collections.Generic;

namespace SoftSize.Ieed.ViewModels.ViewModels
{
    public class FiltroViewModel
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string Nome { get; set; }
        public virtual Guid FuncionalidadeId { get; set; }
        public IEnumerable<ItemFiltroViewModel> ItemsFiltro { get; set; }
    }
}
