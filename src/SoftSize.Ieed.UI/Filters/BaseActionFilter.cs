﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SoftSize.Ieed.UI.Filters
{
    public abstract class BaseActionFilter : IActionFilter, IResultFilter
    {
        public virtual void OnActionExecuting(ActionExecutingContext filterContext)
        {

        }

        public virtual void OnActionExecuted(ActionExecutedContext filterContext)
        {

        }

        public virtual void OnResultExecuting(ResultExecutingContext filterContext)
        {

        }

        public virtual void OnResultExecuted(ResultExecutedContext filterContext)
        {

        }
    }
}