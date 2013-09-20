using System;
using System.Collections.Generic;
using System.Linq;
using SoftSize.Ieed.Model.FilterState;
using SoftSize.Ieed.Model.ServiceInterfaces;
using SoftSize.Ieed.ModelMapping;
using SoftSize.Ieed.ViewModels.ServiceInterfaces;
using SoftSize.Ieed.ViewModels.ViewModels;
using SoftSize.Ieed.Model.ServiceInterfaces;

namespace SoftSize.Ieed.ServiceApplication
{
    public class FilterStateServiceApp : IFilterStateServiceApp
    {
        private readonly IFilterStateService filterStateService;
        private readonly IUsuarioService usuarioService;
        public FilterStateServiceApp(IFilterStateService filterStateService,
                                     IUsuarioService usuarioService)
        {
            this.filterStateService = filterStateService;
            this.usuarioService = usuarioService;
        }

        public IEnumerable<FiltroViewModel> RecuperarFiltrosPor(Guid usuario, Guid funcionalidadeId)
        {
            var usuarioModel = usuarioService.RecuperarPor(usuario);
            return filterStateService.RecuperarFiltrosPor(usuarioModel).Where(m => m.FuncionalidadeId == funcionalidadeId).ToFiltrosViewModel();
        }

        public IEnumerable<ItemFiltroViewModel> GetItemsFiltersFrom(Guid filter)
        {
            var filtro = filterStateService.RecuperarFiltroPor(filter);
            return filtro.ItensFiltro.ToItensFiltroViewModel();
        }

        public void InserirItensFiltro(FiltroViewModel filtroViewModel)
        {
            if (filtroViewModel.Nome.Trim().Length > 0)
            {
                var usuarioModel = usuarioService.RecuperarPor(filtroViewModel.UserId);
                var filtros = filterStateService.RecuperarFiltrosPor(usuarioModel).Where(
                    m => m.Nome.Trim() == filtroViewModel.Nome.Trim());

                if (filtros != null && filtros.Count() > 0)
                {
                    foreach (var filtro in filtros.ToList())
                    {
                        filterStateService.ExcluirFiltro(filtro);
                    }
                }

                Filtro filtroModel = filtroViewModel.ToFiltroModel();
                filtroModel.Usuario = usuarioService.RecuperarPor(filtroViewModel.UserId);

                filterStateService.InserirItensFiltro(filtroModel);

            }
        }
    }
}
