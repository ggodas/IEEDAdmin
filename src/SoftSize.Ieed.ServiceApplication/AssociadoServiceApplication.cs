using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CTF.Fidelidade.Premmia.Domain.SSODomain;
using SoftSize.Ieed.Model;
using SoftSize.Ieed.Model.FinanceiroModel.Lancamento;
using SoftSize.Ieed.Model.ServiceInterfaces;
using SoftSize.Ieed.Model.UsuarioModel;
using SoftSize.Ieed.ViewModels;
using SoftSize.Ieed.ModelMapping;
using SoftSize.Ieed.ViewModels.ServiceInterfaces;
using SoftSize.Infrastructure;

namespace SoftSize.Ieed.ServiceApplication
{
    public class AssociadoServiceApplication : IAssociadoServiceApplication
    {

        private IAssociadoService associadoService;
        private IRepository<GrauEspiritual> grausEspirituais;
        private IRepository<MensalidadeCategoria> categoriasDeMensalidade;
        private IPerfilService perfilService;

        public AssociadoServiceApplication(IAssociadoService associadoService, 
            IRepository<GrauEspiritual> grausEspirituais,
            IPerfilService perfilService,
            IRepository<MensalidadeCategoria> categoriasDeMensalidade)
        {
            this.associadoService = associadoService;
            this.grausEspirituais = grausEspirituais;
            this.perfilService = perfilService;
            this.categoriasDeMensalidade = categoriasDeMensalidade;
        }

        public void DesabilitarAssociadoPor(Guid id)
        {
            associadoService.RemoverAssociadoPor(id);
        }

        public IOrderedEnumerable<AssociadoModel> RecuperarTodosExceto(Guid Id)
        {
            return associadoService.RecuperarTodosExceto(Id).ToAssociadosViewModel();
        }

        public AssociadoModel CriarNovoAssociadoModel(AssociadoModel associadoModel)
        {
            if (associadoModel == null)
                associadoModel = new AssociadoModel();

            associadoModel.Associados = associadoService.RecuperarTodosExceto(associadoModel.Id)
                .Select(x =>
                        new
                            {
                                Id = x.Id.ToString(),
                                x.Nome
                            }
                ).OrderBy(o => o.Nome);
            associadoModel.GrausEspirituais = grausEspirituais.Select(
                x =>
                new
                    {
                        Id = x.Id.ToString(),
                        x.Grau
                    }
                );

            associadoModel.CategoriasDeMensalidade = categoriasDeMensalidade.Select(
                x =>
                new
                    {
                        Id = x.Id,
                        Descricao = x.Descricao + " - Valor: " + x.Valor.ToString("C")
                    }
                );
            return associadoModel;
        }

        public IEnumerable<ListaAssociadoModel> RecuperarTodosListaAssociados(bool somenteAtivos)
        {
            return associadoService.RecuperarAssociados(somenteAtivos).ToListaAssociadoModel();
        }


        public IEnumerable<AssociadoModel> RecuperarAssociadoModelPor(string nome)
        {
            return associadoService.RecuperarAssociadoPor(nome).ToAssociadosViewModel();
        }

        public AssociadoModel RecuperarAssociadoModelPor(Guid id)
        {
            var associado = associadoService.RecuperarAssociadoPor(id);
            var associadoModel = associado.ToAssociadoViewModel();
            var associados = associadoService.RecuperarTodosExceto(associadoModel.Id);


            if (associados != null)
            {
                associadoModel.Associados = associados.Select(x =>
                                                              new
                                                                  {
                                                                      Id = x.Id.ToString(),
                                                                      x.Nome
                                                                  }
                    ).OrderBy(o => o.Nome);
            }
            associadoModel.GrausEspirituais = grausEspirituais.Select(
                x =>
                new
                    {
                        Id = x.Id.ToString(),
                        x.Grau
                    }
                );

            associadoModel.CategoriasDeMensalidade = categoriasDeMensalidade.Select(
            x =>
            new
            {
                Id = x.Id,
                Descricao = x.Descricao + " - Valor: " + x.Valor.ToString("C")
            }
            );

            associadoModel.PossuiDependentes = associado.Dependentes.Count > 0;
            return associadoModel;
        }

        public void IncluirAssociadoModel(AssociadoModel associadoModel)
        {
            Associado associado;

            if (associadoModel.Id == new Guid())
            {
                associado = associadoModel.ToAssociado();
            }
            else
            {
                associado = associadoModel.ToAssociado(associadoService.RecuperarAssociadoPor(associadoModel.Id));
            }

            var dependente = associadoService.RecuperarAssociadoPor(associadoModel.Dependente ?? new Guid());
            associado.DependenteDe = dependente;

            var grauEspiritual = grausEspirituais.Where(g => g.Id == associadoModel.GrauEspiritualAtual).First();
            associado.GrauEspiritual = grauEspiritual;

            associado.MensalidadeCategoria = categoriasDeMensalidade.First(m => m.Id == associadoModel.MensalidadeCategoria);

            associado.AdicionarPerfilDeAcesso(perfilService.RecuperarPerfilPadrao());


            associadoModel.Associados = associadoService.RecuperarTodosExceto(associadoModel.Id)
                .Select(x =>
                        new
                        {
                            Id = x.Id.ToString(),
                            x.Nome
                        }
                );

            associadoModel.GrausEspirituais = grausEspirituais.Select(
                x =>
                new
                {
                    Id = x.Id.ToString(),
                    x.Grau
                }
                );

            associadoService.IncluirAssociado(associado);
        }
    }
}
