using System;
using System.Collections.Generic;
using System.Linq;
using SoftSize.Ieed.Model;
using SoftSize.Ieed.Model.ServiceInterfaces;
using SoftSize.Ieed.Model.UsuarioModel;
using SoftSize.Infrastructure;
using SoftSize.Infrastructure.CustomExtensions;

namespace SoftSize.Ieed.Service
{
    public class AssociadoService : IAssociadoService
    {
        private IRepository<Associado> associados;
        private readonly Guid novoIdDeUsuario;

        public AssociadoService(IRepository<Associado> associadoRepository)
        {
            novoIdDeUsuario = new Guid();
            associados = associadoRepository;
        }
        public StatusProcessamento IncluirAssociado(Associado associado)
        {
            associados.Add(associado);
            return new StatusProcessamento(){Sucesso = true};
        }

        public IEnumerable<Associado> RecuperarTodos()
        {
            return associados;
        }

        public Associado RecuperarAssociadoPor(Guid Id)
        {
            return associados.FindOne(new AssociadoPorId(Id));
        }

        public IOrderedEnumerable<Associado> RecuperarTodosExceto(Guid Id)
        {
            return associados
                  .Where(m => m.DependenteDe == null && m.Id != Id)
                   .OrderBy(x => x.Nome);
        }

        public void RemoverAssociadoPor(Guid Id)
        {
            var associado = RecuperarAssociadoPor(Id);
            associado.Ativo = false;

            associados.Add(associado);
        }


        public IEnumerable<Associado> RecuperarAssociados(bool somenteAtivos)
        {
            return associados.Where(x => somenteAtivos ? true : x.Ativo);
        }

        public IEnumerable<Associado> RecuperarAssociadoPor(string nome)
        {
            return associados.FindAll(new AssociadosPorQualquerParteDoNome(nome));
        }
    }
}
