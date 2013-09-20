using System;
using System.Web.Mvc;
using System.Web.Routing;
using NHibernate;
using NHibernate.Context;
using SoftSize.Ieed.Maps.UsuarioMaps;
using SoftSize.Ieed.ModelMapping.Configuration;
using SoftSize.Ieed.UI.Filters;
using SoftSize.Ieed.UI.Filters.Global;
using SoftSize.Infrastrucure.NHibernateRepository;

namespace SoftSize.Ieed.UI
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {

        public MvcApplication()
        {
            BeginRequest += MvcApplication_BeginRequest;
            EndRequest += MvcApplication_EndRequest;
        }


        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            //filters.Add(new CustomExceptionAttribute());
            //filters.Add(new HeaderClientFilterAttribute();
        }

        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");


            routes.MapRoute(
                "ListaAssociado", // Route name
                "{controller}/{action}", // URL with parameters
                new {controller = "Associado", action = "ListaAssociado"});
            // Parameter defaults

            routes.MapRoute(
                "Default", // Route name
                "{controller}/{action}/{idAssociado}", // URL with parameters
                new { controller = "Associado", action = "Edit", idAssociado = UrlParameter.Optional });
            // Parameter defaults

            routes.MapRoute(
                "LancamentoMensalidade", // Route name
                "{controller}/{action}/{idAssociado}", // URL with parameters
                new { controller = "LancamentoMensalidade", action = "Create", idAssociado = UrlParameter.Optional }
                // Parameter defaults
                );



        }

        protected void Application_Start()
        {
            log4net.Config.XmlConfigurator.Configure();
            AreaRegistration.RegisterAllAreas();

            RegisterGlobalFilters(GlobalFilters.Filters);
            RegisterRoutes(RouteTable.Routes);
            AutoMapperConfiguration.Configure();
        }


        void MvcApplication_EndRequest(object sender, EventArgs e)
        {
            CurrentSessionContext.Unbind(SessionFactory);
        }


       void MvcApplication_BeginRequest(object sender, EventArgs e)
        {
            var session = SessionFactory.OpenSession();
            CurrentSessionContext.Bind(session);
        }

        #region NHibernateConfiguration

        public static ISessionFactory SessionFactory = CreateSessionFactory();

        private static ISessionFactory CreateSessionFactory()
        {
            return NHConfigurator<UsuarioMap>.SessionFactory;
        }

        #endregion
    }
}