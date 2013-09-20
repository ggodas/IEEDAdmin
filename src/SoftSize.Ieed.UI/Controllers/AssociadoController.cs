using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using SoftSize.Ieed.ViewModels;
using SoftSize.Ieed.ViewModels.ServiceInterfaces;
using SoftSize.Infrastructure;

namespace SoftSize.Ieed.UI.Controllers
{
    public class AssociadoController : Controller
    {
        private IAssociadoServiceApplication associadoServiceApplication;
        public AssociadoController(IAssociadoServiceApplication associadoServiceApplication)
        {
            this.associadoServiceApplication = associadoServiceApplication;
        }

        
        [Authorize(Roles = "AlteracaoAssociado")]
        public ActionResult Edit(Guid idAssociado)
        {
            var associadoModel = associadoServiceApplication.RecuperarAssociadoModelPor(idAssociado);
            return View(associadoModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "AlteracaoAssociado")]
        public ActionResult Edit(AssociadoModel associado)
        {
            if (ModelState.IsValid)
            {
                associadoServiceApplication.IncluirAssociadoModel(associado);
                return RedirectToAction("Index", "Home");
            }

            return View(associado);
        }

        [Authorize]
        public ActionResult Delete(string idAssociado)
        {
            associadoServiceApplication.DesabilitarAssociadoPor(new Guid(idAssociado));
            return RedirectToAction("ListaAssociado");
        }

        //[Authorize(Roles = "CadastroAssociado")]
        public ActionResult Create()
        {
            return View(associadoServiceApplication.CriarNovoAssociadoModel(null));
        }

        //[Authorize(Roles = "CadastroAssociado")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AssociadoModel associado)
        {
            if (ModelState.IsValid)
            {
                associadoServiceApplication.IncluirAssociadoModel(associado);
                return RedirectToAction("ListaAssociado");
            }
            else
            {
                associadoServiceApplication.CriarNovoAssociadoModel(associado);
            }
            return View(associado);
        }

        [Authorize]
        public ActionResult PesquisaDeAssociados()
        {
            return View();
        }

        [Authorize]
        public ActionResult ListaAssociado(string guidUsuario = null)
        {
            var associadosAtivos = associadoServiceApplication.RecuperarTodosListaAssociados(true);
            return View(associadosAtivos);
        }

        [Authorize]
        public JsonResult ProcurarAssociadoPor(string nome)
        {
            var listaDeAssociados = associadoServiceApplication.RecuperarAssociadoModelPor(nome)
                .Select(m =>
                        new
                            {
                                m.Id,
                                m.Nome
                            }
                );

            return Json(listaDeAssociados, JsonRequestBehavior.AllowGet);
        }
    }
}
