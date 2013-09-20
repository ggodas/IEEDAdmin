using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SoftSize.Ieed.ViewModels;
using SoftSize.Ieed.ViewModels.ServiceInterfaces;
using SoftSize.Infrastructure;

namespace SoftSize.Ieed.UI.Controllers
{
    public class CentroDeCustoController : Controller
    {
        private ICentroDeCustoServiceApplication centroDeCustoServiceApplication;
        public CentroDeCustoController(ICentroDeCustoServiceApplication centroDeCustoServiceApplication)
        {
            this.centroDeCustoServiceApplication = centroDeCustoServiceApplication;
        }


        public JsonResult ProcurarCentroDeCustoPor(string q)
        {
            var centrosDeCusto = centroDeCustoServiceApplication.CentrosDeCustoPor(q).Select(m => new {id = m.Id, name= string.Format("{0} - {1:dd/MM/yyyy}", m.Descricao, m.Data)});
            return Json(centrosDeCusto, JsonRequestBehavior.AllowGet);
        }

        [Authorize(Roles = "NovoCentroDeCusto")]
        public ActionResult Create()
        {

            return View(new CentroDeCustoViewModel());
        }

        [HttpPost]
        [Authorize(Roles = "NovoCentroDeCusto")]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CentroDeCustoViewModel centroDeCustoViewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    centroDeCustoServiceApplication.Inserir(centroDeCustoViewModel);
                    return RedirectToAction("Index", "Home");
                }

            }
            catch
            {
                return View();
            }
            return View(centroDeCustoViewModel);
        }


        [HttpPost]
        public JsonResult RecuperarCentroCustoPor(string descricao)
        {
            var custos = centroDeCustoServiceApplication.CentrosDeCustoPor(descricao)
                .Select(m => 
                    new
                        {
                            Id = m.Id,
                            Descricao = m.Descricao
                        }
                       );
            return Json(custos.ToList());
        }


    }
}
