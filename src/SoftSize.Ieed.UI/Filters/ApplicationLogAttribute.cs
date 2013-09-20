using System;
using System.Net;
using System.Web.Mvc;
using Ninject;
using Ninject.Extensions.Logging;
using SoftSize.Ieed.Model;
using SoftSize.Ieed.Model.ServiceInterfaces;

namespace SoftSize.Ieed.UI.Filters
{
    [AttributeUsage(AttributeTargets.All, AllowMultiple = true)]
    public class ApplicationLogAttribute : ActionFilterAttribute
    {
        [Inject]
        public ILogAcessoService LogAcessoService { get; set; }

        [Inject]
        public IUsuarioService UsuarioService { get; set; }

        [Inject]
        public ILogger Logger { get; set; }


        private string descricao;
        public ApplicationLogAttribute(string descricao = "")
        {
            this.descricao = descricao;
        }

        public override void OnResultExecuted(ResultExecutedContext filterContext)
        {
            try
            {
                var user = filterContext.HttpContext.User.Identity.Name;
                var ip = filterContext.HttpContext.Request.UserHostName;
                var hostName = GetHostName(ip);
                var actionName = filterContext.RouteData.Values["action"].ToString();
                var controllerName = filterContext.RouteData.Values["controller"].ToString();

                Guid usuario;
                long entidade;

                var logAcesso = new LogDeAcesso
                                    {
                                        Action = actionName,
                                        Controller = controllerName,
                                        DataDeAcesso = DateTime.Now,
                                        HostName = hostName,
                                        IP = ip,
                                        Observacao = descricao
                                    };

                if (Guid.TryParse(user, out usuario))
                {
                    logAcesso.Usuario = UsuarioService.RecuperarPor(usuario);
                }

                LogAcessoService.Incluir(logAcesso);
            }
            catch(Exception ex)
            {
                if (Logger != null)
                {
                    Logger.Error("", ex);
                }
            }

            base.OnResultExecuted(filterContext);
        }

        public string GetHostName(string IP)
        {
            try
            {
                IPAddress myIP = IPAddress.Parse(IP);
                IPHostEntry getIpHost = Dns.GetHostEntry(myIP);
                return getIpHost.HostName; 
            }
            catch(Exception)
            {
            }
            return "";
        } 
    }
}