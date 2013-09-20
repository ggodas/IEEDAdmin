using System.Web.Mvc;
using Ninject;
using Ninject.Extensions.Logging;
using SoftSize.Ieed.UI.App_Start;

namespace SoftSize.Ieed.UI.Filters.Global
{
    public class CustomExceptionAttribute : HandleErrorAttribute
    {
        [Inject]
        public ILogger Logger { get; set; }

        public CustomExceptionAttribute(ILogger logger)
        {
            Logger = logger;
            NinjectMVC3.bootstrapper.Kernel.Inject(this);
        }

        public override void OnException(ExceptionContext filterContext)
        {
            if (Logger.IsErrorEnabled)
                Logger.Error(filterContext.Exception, "");

            
            base.OnException(filterContext);
        }
    }
}