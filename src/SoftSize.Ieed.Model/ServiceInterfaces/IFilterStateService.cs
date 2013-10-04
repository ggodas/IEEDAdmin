using System;
using System.Collections.Generic;
using SoftSize.Ieed.Model.FilterState;
using SoftSize.Ieed.Model.UsuarioModel;

namespace SoftSize.Ieed.Model.ServiceInterfaces
{
    public interface IFilterStateService
    {
        IEnumerable<Filtro> RecuperarFiltrosPor(Usuario usuario);
        Filtro RecuperarFiltroPor(Guid filtroId);
        void InserirItensFiltro(Filtro filtro);
        void ExcluirFiltro(Filtro filtro);
    }
}
