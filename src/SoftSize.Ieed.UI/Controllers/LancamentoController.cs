using System;
using System.Collections.Generic;
using System.Web.Mvc;
using SoftSize.Ieed.Model;
using SoftSize.Ieed.Model.ServiceInterfaces;
using SoftSize.Ieed.ViewModels;
using SoftSize.Ieed.ViewModels.ServiceInterfaces;
using System.Linq;

namespace SoftSize.Ieed.UI.Controllers
{
    public class LancamentoController : Controller
    {
        //
        // GET: /LancamentoMensalidade/
        private IAssociadoServiceApplication associadoServiceApplication;
        private ILancamentoServiceApplication lancamentoServiceApplication;

        public LancamentoController(
            IAssociadoServiceApplication associadoServiceApplication,
            ILancamentoServiceApplication lancamentoServiceApplication)
        {
            this.associadoServiceApplication = associadoServiceApplication;
            this.lancamentoServiceApplication = lancamentoServiceApplication;
        }

        [Authorize(Roles = "ConsultaFinanceiro")]
        public ActionResult Index(string filtroMensalidade, Guid? idAssociado = null)
        {
            if (idAssociado != null)
            {
                var associado = associadoServiceApplication.RecuperarAssociadoModelPor(idAssociado ?? new Guid());
                var mensalidades = lancamentoServiceApplication.ListarMensalidadesDo(associado);
                
                ViewBag.idAssociado = idAssociado;
                return View(mensalidades);


            }

            string url = "Index?idAssociado=";
            return View("PesquisaDeAssociados", new PesquisaDeAssociadosViewModel() { Label = "Nome do Associado", Titulo = "Lista de Lançamentos", Url = url });
        }


        public ActionResult ListaDespesa()
        {
                var despesasModel = lancamentoServiceApplication.ListarLancamentosDespesa();//lancamentoServiceApplication.ListarMensalidadesDo(associado);

                return View(despesasModel);
        }

        public ActionResult Details(int id)
        {
            return View();
        }


        [Authorize(Roles = "NovoLancamentoFinanceiro")]
        public ActionResult Create(Guid? idAssociado = null)
        {
            if (idAssociado == null)
            {

                string url = "Create?idAssociado=";
                return View("PesquisaDeAssociados", new PesquisaDeAssociadosViewModel() { Label = "Nome do Associado", Titulo = "Novo Lançamento", Url = url });
            }

            var mensalidadeModel = lancamentoServiceApplication.CriarLancamentoMensalidadeModel(null, idAssociado ?? new Guid());
            return View(mensalidadeModel);
        }


        [HttpPost]
        [Authorize(Roles = "NovoLancamentoFinanceiro")]
        public ActionResult Create(LancamentoModel mensalidadeModel)
        {
            lancamentoServiceApplication.IncluirMensalidade(mensalidadeModel);

            return RedirectToAction("Index", "Lancamento", new { idAssociado = mensalidadeModel.Associado.Id });
            //mensalidadeModel = lancamentoServiceApplication.CriarLancamentoMensalidadeModel(mensalidadeModel, mensalidadeModel.Associado.Id);
            //return View(mensalidadeModel);
        }


        [Authorize(Roles = "LancamentoDoacao")]
        public ActionResult Doacao(Guid? idAssociado = null)
        {
            if (idAssociado == null)
            {

                string url = "Doacao?idAssociado=";
                return View("PesquisaDeAssociados", new PesquisaDeAssociadosViewModel() { Label = "Nome do Associado", Titulo = "Novo Lançamento", Url = url });
            }

            var mensalidadeModel = lancamentoServiceApplication.CriarLancamentoMensalidadeModel(null, idAssociado ?? new Guid());
            return View(mensalidadeModel);
        }


        [HttpPost]
        [Authorize(Roles = "LancamentoDoacao")]
        public ActionResult Doacao(LancamentoModel mensalidadeModel)
        {
            lancamentoServiceApplication.IncluirDoacao(mensalidadeModel);

            return RedirectToAction("Index", "Lancamento", new { idAssociado = mensalidadeModel.Associado.Id });
            //mensalidadeModel = lancamentoServiceApplication.CriarLancamentoMensalidadeModel(mensalidadeModel, mensalidadeModel.Associado.Id);
            //return View(mensalidadeModel);
        }



        [Authorize(Roles = "LancamentoMensalidadeLote")]
        public ActionResult LancamentoEmLote()
        {
            var lancamentoEmLoteViewModel = lancamentoServiceApplication.CriarlancamentoMensalidadeLoteViewModel(null);
            return View(lancamentoEmLoteViewModel);
        }


        [HttpPost]
        [Authorize(Roles = "LancamentoMensalidadeLote")]
        public ActionResult LancamentoEmLote(LancamentoMensalidadeLoteViewModel lancamentoMensalidadeLoteViewModel)
        {
                lancamentoServiceApplication.IncluirMensalidadesParaUsuariosAtivos(lancamentoMensalidadeLoteViewModel);
                return PartialView("Mensagem",
                                   new MensagemViewModel
                                       {Mensagem = "Lançamento de mensalidades executada com sucesso."});
        }

        //[Authorize(Roles = "Pagar")]
        public ActionResult Pagar(PagamentoModel pagarModel)
        {
            try
            {
                lancamentoServiceApplication.Pagar(pagarModel);
                return RedirectToAction("Index", "Home");
            }
            catch (Exception ex)
            {
                return PartialView("Mensagem",
                                       new MensagemViewModel { Mensagem = ex.Message });
            }

            var lancamentos = lancamentoServiceApplication.RecuperarLancamentosPor(pagarModel);
            return PartialView("Pagamento", lancamentos);
        }

        //[Authorize(Roles = "Caixa")]
        public PartialViewResult Caixa(PagamentoModel pagamentoModel)
        {
            var lancamentos = lancamentoServiceApplication.RecuperarLancamentosPor(pagamentoModel);
            return PartialView("Pagamento", lancamentos);
        }


        public ActionResult Despesa()
        {
            var lancamento = lancamentoServiceApplication.CriarLancamentoDespesaModel(null);
            return View(lancamento);
        }


        [HttpPost]
        public ActionResult Despesa(LancamentoDespesaModel lancamentoDespesaModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    lancamentoServiceApplication.IncluirLancamentoDespesa(lancamentoDespesaModel);
                    return PartialView("Mensagem",
                                       new MensagemViewModel { Mensagem = "Lançamento de Despesa Incluído com Sucesso." });
                }
            }
            catch
            {
                return PartialView("Mensagem",
                                   new MensagemViewModel { Mensagem = "Erro ao lançar despesa tente novamente. " });
            }
            var lancamentoDespesa = lancamentoServiceApplication.CriarLancamentoDespesaModel(lancamentoDespesaModel);
            return View(lancamentoDespesa);
        }

        public ActionResult Cerimonia(Guid? idAssociado = null)
        {
            if (idAssociado == null)
            {

                string url = "Cerimonia?idAssociado=";
                return View("PesquisaDeAssociados", new PesquisaDeAssociadosViewModel() { Label = "Nome do Associado", Titulo = "Novo Lançamento de Cerimonia", Url = url });
            }
            var lancamento = lancamentoServiceApplication.CriarLancamentoCerimoniaModel(null);
            lancamento.Associado = associadoServiceApplication.RecuperarAssociadoModelPor(idAssociado ?? new Guid());
            return View(lancamento);
        }

        [HttpPost]
        public ActionResult Cerimonia(LancamentoCerimoniaModel lancamentoCerimoniaModel)
        {
            try
            {
                //if (ModelState.IsValid)
                //{
                lancamentoServiceApplication.IncluirCerimonia(lancamentoCerimoniaModel);
                return PartialView("Mensagem",
                                   new MensagemViewModel { Mensagem = "Lançamento de Cerimonia Incluído com Sucesso." });
                //}
            }
            catch (InvalidOperationException ex)
            {
                return PartialView("Mensagem",
                                   new MensagemViewModel { Mensagem = ex.Message });
            }
            lancamentoCerimoniaModel = lancamentoServiceApplication.CriarLancamentoCerimoniaModel(lancamentoCerimoniaModel);
            return View(lancamentoCerimoniaModel);
        }

    }


}
