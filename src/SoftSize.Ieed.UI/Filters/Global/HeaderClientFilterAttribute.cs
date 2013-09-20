using System;
using System.Web;
using System.Web.Mvc;
using Ninject;
using Ninject.Extensions.Logging;
using SoftSize.Ieed.UI.App_Start;
using SoftSize.Ieed.ViewModels.ServiceInterfaces;

namespace SoftSize.Ieed.UI.Filters.Global
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
    public class HeaderClientFilterAttribute : ActionFilterAttribute
    {
        [Inject]
        public IUsuarioServiceApplication UsuarioServiceApplication { get; set; }

        public ILogger Logger { get; set; }

        public HeaderClientFilterAttribute(ILogger logger)
        {
            Logger = logger;
            NinjectMVC3.bootstrapper.Kernel.Inject(this);
        }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if(Logger.IsWarnEnabled)
            { 
                if (!string.IsNullOrEmpty(filterContext.HttpContext.Request.QueryString["userGuid"]))
                {
                    var guid = filterContext.HttpContext.Request.QueryString["userGuid"];
                    Logger.Warn("UserGuid={0}", guid);
                }
            }
            if (IsAuthenticated(filterContext))
            {
                var user = filterContext.HttpContext.User.Identity.Name;

                    //var usuario = UsuarioServiceApplication.RecuperarPor(new Guid(user));

                    //if (usuario.PrimeiroLogin && filterContext.ActionDescriptor.ActionName != "ChangePassword")
                    //{
                    //    HttpContext ctx = HttpContext.Current;
                    //    UrlHelper helper = new UrlHelper(filterContext.RequestContext);
                    //    String url = helper.Action("ChangePassword", "Account");
                    //    ctx.Response.Redirect(url);
                    //}

                    //filterContext.Controller.ViewBag.UsuarioNome = usuario.Nome;
                    //filterContext.Controller.ViewBag.UsuarioEmail = usuario.Email;
                }

            base.OnActionExecuting(filterContext);
        }

        private bool IsAuthenticated(ActionExecutingContext filterContext)
        {
            return filterContext.HttpContext.Request.IsAuthenticated;
        }

    }
}
