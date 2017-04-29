using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using log4net;

namespace Wen.TaskManager.WebUI.Infrastructure.Filters
{
    /// <summary>
    /// 自定义异常处理过滤器特性
    /// </summary>
    public class CustomHandleErrorAttribute : HandleErrorAttribute
    {
        private readonly ILog _logger = LogManager.GetLogger(typeof(CustomHandleErrorAttribute));

        public override void OnException(ExceptionContext filterContext)
        {
            //记录异常日志
            var ex = filterContext.Exception;
            _logger.ErrorFormat($"{ex}\r\n");

            filterContext.Result = new RedirectResult("/Home/Error");
            filterContext.ExceptionHandled = true;

            base.OnException(filterContext);
        }
    }
}