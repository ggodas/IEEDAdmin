using System;
using System.Collections.Generic;
using System.Linq;
using SoftSize.Ieed.Model.UsuarioModel;

namespace SoftSize.Ieed.Model.ServiceInterfaces
{
    public interface IAssociadoService
    {
        StatusProcessamento IncluirAssociado(Associado associado);
        Associado RecuperarAssociadoPor(Guid Id);
        IEnumerable<Associado> RecuperarAssociadoPor(string nome);
        IOrderedEnumerable<Associado> RecuperarTodosExceto(Guid Id);
        IEnumerable<Associado> RecuperarAssociados(bool somenteAtivos);
        void RemoverAssociadoPor(Guid Id);

    }
}
