using System;
using System.Collections.Generic;
using SoftSize.Ieed.ViewModels.ViewModels;

namespace SoftSize.Ieed.ViewModels.ServiceInterfaces
{
    public interface IFilterStateServiceApp
    {
        IEnumerable<FiltroViewModel> RecuperarFiltrosPor(Guid usuario, Guid funcionalidadeId);
        IEnumerable<ItemFiltroViewModel> GetItemsFiltersFrom(Guid filter);
        void InserirItensFiltro(FiltroViewModel filtroViewModel);
    }
}
