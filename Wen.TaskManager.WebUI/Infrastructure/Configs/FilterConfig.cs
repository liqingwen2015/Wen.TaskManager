using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Wen.TaskManager.WebUI.Infrastructure.Filters;

namespace Wen.TaskManager.WebUI.Infrastructure.Configs
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            //filters.Add(new CustomHandleErrorAttribute());
            //filters.Add(new CustomActionFilterAttribute());
            //filters.Add(new CustomAuthorizeFilterAttribute());
        }
    }
}