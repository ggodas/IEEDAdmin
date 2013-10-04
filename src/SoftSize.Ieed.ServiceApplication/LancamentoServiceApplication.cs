using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SoftSize.Ieed.Model;
using SoftSize.Ieed.Model.FinanceiroModel.Lancamento;
using SoftSize.Ieed.Model.ServiceInterfaces;
using SoftSize.Ieed.Model.UsuarioModel;
using SoftSize.Ieed.ViewModels;
using SoftSize.Ieed.ViewModels.ServiceInterfaces;
using SoftSize.Ieed.ModelMapping;
using SoftSize.Infrastructure;

namespace SoftSize.Ieed.ServiceApplication
{
    public class LancamentoServiceApplication : ILancamentoServiceApplication
    {
        private readonly ILancamentoService lancamentoService;
        private readonly IAssociadoService _associadoService;
        private readonly IRepository<CentroDeCustoLancamento> centrosDeCusto;
        public LancamentoServiceApplication(ILancamentoService _lancamentoService,
            IAssociadoService associadoService,
            IRepository<CentroDeCustoLancamento> centrosDeCusto)
        {
            this.lancamentoService = _lancamentoService;
            this._associadoService = associadoService;
            this.centrosDeCusto = centrosDeCusto;
        }

        public IEnumerable<LancamentoModel> ListarLancamentosDespesa()
        {
            return lancamentoService.ListarLancamentosDespesa().ToListaDespesaModel();
        }

        public IEnumerable<LancamentoModel> ListarMensalidadesDo(AssociadoModel associado)
        {
            var lancamentoModel = lancamentoService.ListarLancamentosDo(associado.ToAssociado()).ToListaLancamentoModel();
            return lancamentoModel;
        }

        public LancamentoModel ListarMensalidadesDoAssociadoEDependentes(AssociadoModel associado)
        {
            throw new NotImplementedException();
        }

        public void IncluirMensalidadesParaUsuariosAtivos(LancamentoMensalidadeLoteViewModel dataLancamentoMensalidadeModel)
        {
            Guid idCentroDeCusto = dataLancamentoMensalidadeModel.CentroDeCustoLancamento.Id;
            var centroDeCusto = centrosDeCusto.First(m => m.Id == idCentroDeCusto);

            lancamentoService.GerarMensalidadesEmLote(centroDeCusto);
        }


        public LancamentoMensalidadeLoteViewModel CriarlancamentoMensalidadeLoteViewModel(LancamentoMensalidadeLoteViewModel lancamentoMensalidadeLoteViewModel)
        {

            if (lancamentoMensalidadeLoteViewModel == null)
                lancamentoMensalidadeLoteViewModel = new LancamentoMensalidadeLoteViewModel();

            Func<string, DateTime, string> formatarNome = (descricao, data) => string.Format("{0} - {1}", descricao,
                                                                                             data.ToString("dd/MM/yyyy"));
            lancamentoMensalidadeLoteViewModel.CentrosDeCusto = centrosDeCusto.Select(m =>
                                                                    new
                                                                    {
                                                                        m.Id,
                                                                        Descricao = formatarNome(m.Descricao, m.Data)
                                                                    });

            return lancamentoMensalidadeLoteViewModel;
        }

        public LancamentoModel CriarLancamentoMensalidadeModel(LancamentoModel mensalidadeModel, Guid idAssociado)
        {

            if (mensalidadeModel == null)
                mensalidadeModel = new LancamentoModel();

            Func<string, DateTime, string> formatarNome = (descricao, data) => string.Format("{0} - {1}", descricao,
                                                                                             data.ToString("dd/MM/yyyy"));
            mensalidadeModel.CentrosDeCusto = centrosDeCusto.Select(m =>
                                                                    new
                                                                        {
                                                                            m.Id,
                                                                            Descricao = formatarNome(m.Descricao, m.Data)
                                                                        });
            mensalidadeModel.Associado = _associadoService.RecuperarAssociadoPor(idAssociado).ToAssociadoViewModel();

            return mensalidadeModel;
        }

        public void IncluirMensalidade(LancamentoModel mensalidadeModel)
        {

            LancamentoMensalidade mensalidade = new LancamentoMensalidade();//mensalidadeModel.ToMensalidade();
            var associado = _associadoService.RecuperarAssociadoPor(mensalidadeModel.Associado.Id);
            mensalidade.Associado = associado;
            mensalidade.CentroDeCustoLancamento = centrosDeCusto.First(m => m.Id == mensalidadeModel.CentroDeCustoLancamento.Id);

            decimal? valor = mensalidadeModel.Valor;
            mensalidade.Valor = (valor == null || valor == 0 ? associado.MensalidadeCategoria.Valor : valor) ?? 0;

            lancamentoService.IncluirLancamento(mensalidade);
        }

        public void IncluirDoacao(LancamentoModel mensalidadeModel)
        {

            LancamentoDoacao mensalidade = new LancamentoDoacao();//mensalidadeModel.ToDoacao();
            var associado = _associadoService.RecuperarAssociadoPor(mensalidadeModel.Associado.Id);
            mensalidade.Associado = associado;
            mensalidade.CentroDeCustoLancamento = centrosDeCusto.First(m => m.Id == mensalidadeModel.CentroDeCustoLancamento.Id);

            decimal? valor = mensalidadeModel.Valor;
            mensalidade.Valor = (valor == null || valor == 0 ? associado.MensalidadeCategoria.Valor : valor) ?? 0;

            lancamentoService.IncluirLancamentoSemValidacao(mensalidade);
        }


        public void IncluirCerimonia(LancamentoCerimoniaModel cerimoniaModel)
        {
            var lancamentoCerimonia = new LancamentoCerimonia();// cerimoniaModel.ToLancamentoCerimonia();

            lancamentoCerimonia.CentroDeCustoLancamento = centrosDeCusto.First(m => m.Id == cerimoniaModel.CentroDeCustoLancamento.Id);

            var associado = _associadoService.RecuperarAssociadoPor(cerimoniaModel.Associado.Id);
            lancamentoCerimonia.Associado = associado;

            //lancamentoCerimonia.CentroDeCustoLancamento = centrosDeCusto.First(m => m.Id == cerimoniaModel.CentroDeCusto);

            lancamentoService.IncluirLancamento(lancamentoCerimonia);
        }


        public LancamentoDespesaModel CriarLancamentoDespesaModel(LancamentoDespesaModel lancamentoDespesaModel)
        {
            if (lancamentoDespesaModel == null)
                lancamentoDespesaModel = new LancamentoDespesaModel();

            Func<string, DateTime, string> formatarNome = (descricao, data) => string.Format("{0} - {1}", descricao,
                                                                                             data.ToString("dd/MM/yyyy"));

            lancamentoDespesaModel.CentrosDeCusto = centrosDeCusto.Select(m =>
                                                                         new
                                                                         {
                                                                             m.Id,
                                                                             Nome = formatarNome(m.Descricao, m.Data)
                                                                         });
            return lancamentoDespesaModel;
        }

        public LancamentoCerimoniaModel CriarLancamentoCerimoniaModel(LancamentoCerimoniaModel lancamentoCerimoniaModel)
        {
            if (lancamentoCerimoniaModel == null)
                lancamentoCerimoniaModel = new LancamentoCerimoniaModel();

            Func<string, DateTime, string> formatarNome = (descricao, data) => string.Format("{0} - {1}", descricao,
                                                                                             data.ToString("dd/MM/yyyy"));

            lancamentoCerimoniaModel.CentrosDeCusto = centrosDeCusto.Select(m =>
                                                                         new
                                                                         {
                                                                             m.Id,
                                                                             Nome = formatarNome(m.Descricao, m.Data)
                                                                         });
            return lancamentoCerimoniaModel;
        }

        public void IncluirLancamentoDespesa(LancamentoDespesaModel lancamentoDespesaModel)
        {
            var lancamentoDespesa = lancamentoDespesaModel.ToLancamentoDespesa();
            lancamentoDespesa.CentroDeCustoLancamento =
                centrosDeCusto.First(m => m.Id == lancamentoDespesaModel.CentroDeCustoLancamentoId);
            lancamentoService.IncluirLancamento(lancamentoDespesa);
            
            if (lancamentoDespesaModel.EfetivarPagamento)
            {
                lancamentoService.Pagar(lancamentoDespesa, 0);
            }
        }

        public PagementosSelecionadosModel RecuperarLancamentosPor(PagamentoModel pagamentoModel)
        {
            PagementosSelecionadosModel pagementosSelecionadosModel = new PagementosSelecionadosModel();
            pagementosSelecionadosModel.PagamentoItens = lancamentoService.ListarLancamentosPor(pagamentoModel.ToGuids()).ToPagamentoItemModel();
            return pagementosSelecionadosModel;
        }

        public void Pagar(PagamentoModel pagamentoModel)
        {
            var lancamentos = lancamentoService.ListarLancamentosPor(pagamentoModel.ToGuids());
            lancamentoService.Pagar(lancamentos, pagamentoModel.NumeroRecibo);
        }

      
    }
}
