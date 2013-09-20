using System;
using System.Collections.Generic;
using System.Linq;
using SoftSize.Ieed.Model.FilterState;
using SoftSize.Ieed.Model.ServiceInterfaces;
using SoftSize.Ieed.Model.UsuarioModel;
using SoftSize.Infrastructure;

namespace SoftSize.Ieed.Service
{
    public class FilterStateService : IFilterStateService
    {
        private readonly IRepository<Filtro> filtros;
        public FilterStateService(IRepository<Filtro> filtros)
        {
            this.filtros = filtros;
        }

        public IEnumerable<Filtro> RecuperarFiltrosPor(Usuario usuario)
        {
            return filtros.Where(m => m.Usuario.Id == usuario.Id);
        }

        public Filtro RecuperarFiltroPor(Guid filtroId)
        {
            return filtros.First(m => m.Id == filtroId);
        }

        public void InserirItensFiltro(Filtro filtro)
        {
            filtros.Add(filtro);
        }

        public void ExcluirFiltro(Filtro filtro)
        {
            filtro.RemoverTodosItensFiltro();
            filtros.Add(filtro);
            filtros.Remove(filtro);
        }
    }
}
