using System.Configuration;
using System.Web.Mvc;
using CTF.Fidelidade.Premmia.Service;
using NHibernate;
using Ninject.Extensions.Logging;
using SoftSize.Ieed.Model.ServiceInterfaces;
using SoftSize.Ieed.Service;
using SoftSize.Ieed.ServiceApplication;
using SoftSize.Ieed.UI.Filters.Global;
using SoftSize.Ieed.ViewModels.ServiceInterfaces;
using SoftSize.Infrastructure;
using SoftSize.Infrastrucure.NHibernateRepository;
using Ninject.Web.Mvc.FilterBindingSyntax;

[assembly: WebActivator.PreApplicationStartMethod(typeof(SoftSize.Ieed.UI.App_Start.NinjectMVC3), "Start")]
[assembly: WebActivator.ApplicationShutdownMethodAttribute(typeof(SoftSize.Ieed.UI.App_Start.NinjectMVC3), "Stop")]

namespace SoftSize.Ieed.UI.App_Start
{
    using Microsoft.Web.Infrastructure.DynamicModuleHelper;
    using Ninject;
    using Ninject.Web.Mvc;

    public static class NinjectMVC3 
    {
        public static readonly Bootstrapper bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start() 
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestModule));
            DynamicModuleUtility.RegisterModule(typeof(HttpApplicationInitializationModule));
            bootstrapper.Initialize(CreateKernel);
        }
        
        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            bootstrapper.ShutDown();
        }
        
        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            RegisterServices(kernel);
            return kernel;
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
            kernel.Bind(typeof (IRepository<>)).To(typeof (NHibernateRepository<>)).InSingletonScope();
            kernel.Bind<ISessionFactory>().ToConstant(MvcApplication.SessionFactory).InRequestScope();

            kernel.Bind<IAssociadoService>().To<AssociadoService>();
            kernel.Bind<ILancamentoService>().To<LancamentoService>();
            kernel.Bind<IPermissaoService>().To<PermissaoService>();
            kernel.Bind<IUsuarioService>().To<UsuarioService>();
            kernel.Bind<IPerfilService>().To<PerfilService>();

            kernel.Bind<IMovimentoDeCaixaService>().To<MovimentoDeCaixaService>();

            kernel.Bind<IAssociadoServiceApplication>().To<AssociadoServiceApplication>();
            kernel.Bind<ILancamentoServiceApplication>().To<LancamentoServiceApplication>();
            kernel.Bind<IPermissaoServiceApplication>().To<PermissaoServiceApplication>();
            kernel.Bind<IUsuarioServiceApplication>().To<UsuarioServiceApplication>();
            kernel.Bind<IPerfilServiceApplication>().To<PerfilServiceApplication>();
            kernel.Bind<ICentroDeCustoServiceApplication>().To<CentroDeCustoServiceApplication>();
            kernel.Bind<IFilterStateServiceApp>().To<FilterStateServiceApp>();
            kernel.Bind<IFilterStateService>().To<FilterStateService>();
            kernel.Bind<ILogAcessoService>().To<LogAcessoService>();
            //kernel.Bind<ILogger>().To<Ninject.Extensions.Logging.Log4net.Infrastructure.Log4NetLogger>();
            kernel.BindFilter<CustomExceptionAttribute>(FilterScope.Global, 0);
            kernel.BindFilter<HeaderClientFilterAttribute>(FilterScope.Global, 0);

            kernel.Bind<IDynamicViewServiceApplication>().To<DynamicViewServiceApplication>().WithConstructorArgument("xmlPath", ConfigurationManager.AppSettings["DynamicView"]);

        }
    }
}
