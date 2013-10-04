using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftSize.Ieed.ViewModels.ServiceInterfaces
{
    public interface IAssociadoServiceApplication
    {
        AssociadoModel RecuperarAssociadoModelPor(Guid id);
        void IncluirAssociadoModel(AssociadoModel associadoModel);
        void DesabilitarAssociadoPor(Guid id);
        IOrderedEnumerable<AssociadoModel> RecuperarTodosExceto(Guid Id);
        AssociadoModel CriarNovoAssociadoModel(AssociadoModel associadoModel);
        IEnumerable<ListaAssociadoModel> RecuperarTodosListaAssociados(bool somenteAtivos);
        IEnumerable<AssociadoModel> RecuperarAssociadoModelPor(string nome);
    }

}
