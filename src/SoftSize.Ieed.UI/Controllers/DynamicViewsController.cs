using System;
using System.Web.Mvc;
using System.Linq;
using SoftSize.Ieed.ViewModels;
using SoftSize.Ieed.ViewModels.ServiceInterfaces;
using SoftSize.Ieed.ViewModels.ViewModels;

namespace SoftSize.Ieed.UI.Controllers
{
    public class DynamicViewsController : Controller
    {
        private readonly IDynamicViewServiceApplication dynamicViewServiceApplication;
        private readonly IUsuarioServiceApplication usuarioServiceApplication;
        private readonly IFilterStateServiceApp filterStateServiceApp;

        public DynamicViewsController(IDynamicViewServiceApplication dynamicViewServiceApplication,
                                        IUsuarioServiceApplication usuarioServiceApplication,
                                        IFilterStateServiceApp filterStateServiceApp
                                        )
        {
            this.dynamicViewServiceApplication = dynamicViewServiceApplication;
            this.usuarioServiceApplication = usuarioServiceApplication;
            this.filterStateServiceApp = filterStateServiceApp;
        }

        [Authorize]
        public ActionResult Index(Guid viewId)
        {
            bool userIsInRole = HttpContext.User.IsInRole(viewId.ToString());
            if (userIsInRole)
            {
                var ret = dynamicViewServiceApplication.RecuperarViewPor(viewId);
                


                var user = User.Identity.Name;
                Guid guid;
                long idEntidade;
                UsuarioViewModel usuario = null;

                if (Guid.TryParse(user, out guid))
                    usuario = usuarioServiceApplication.RecuperarPor(new Guid(user));


                var controls = ret.ControlsInView.Where(x => 
                    x.ExibirSomenteParaOsPerfis.Count == 0 ||
                    x.ExibirSomenteParaOsPerfis.Where(m => m.ToUpper() == usuario.PerfisDeAcessosPermitidos.ToList()[0].Nome.ToUpper()).Count() > 0
                    );

                ret.ControlsInView = controls.ToList();

                var perfisAtribuidos = usuario.PerfisDeAcessosPermitidos;

                


                return View(ret);
            }
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        [Authorize]
        public JsonResult RecuperarFiltros(string q)
        {
            var user = Guid.Parse(User.Identity.Name);
            var itemsFilters = filterStateServiceApp.RecuperarFiltrosPor(user, Guid.Parse(q));
            return Json(itemsFilters);
        }

        [HttpPost]
        public JsonResult RecuperarItensFiltro(string q)
        {
            if (q == "")
                return null;

            var itemsFilters = filterStateServiceApp.GetItemsFiltersFrom(Guid.Parse(q));
            return Json(itemsFilters);

        }


        [HttpPost]
        public void InserirFiltro(FormCollection formCollection)
        {
            var listaFiltros = formCollection.AllKeys.Select(key => new ItemFiltroViewModel {Key = key, Value = formCollection[key]}).ToList();

            var removidos = listaFiltros.RemoveAll(m => m.Key == "COMBO_FILTRO" || m.Key == "Id" || m.Key == "");

            FiltroViewModel filtroViewModel = new FiltroViewModel();
            filtroViewModel.ItemsFiltro = listaFiltros;
            filtroViewModel.Nome = formCollection["NOME_FILTRO"];
            filtroViewModel.UserId = Guid.Parse(User.Identity.Name);
            filtroViewModel.FuncionalidadeId = Guid.Parse(formCollection["Id"]);

            Guid comboFiltro;
            if (Guid.TryParse(formCollection["COMBO_FILTRO"], out comboFiltro))
            {
                filtroViewModel.Id = comboFiltro;
               
            }

            filterStateServiceApp.InserirItensFiltro(filtroViewModel);
        }
    }
}
