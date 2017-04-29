//#region

//using System;
//using System.Web.Mvc;
//using Wen.Helpers.Common.Extend;
//using Wen.TaskManager.BLL.Abstract.Other;
//using Wen.TaskManager.DI;
//using Wen.TaskManager.Domain;
//using Wen.TaskManager.WebUI.Infrastructure.Log;

//#endregion

//namespace Wen.TaskManager.WebUI.Infrastructure.Filters
//{
//    /// <summary>
//    /// 自定义行为过滤器特性
//    /// </summary>
//    public class CustomActionFilterAttribute : ActionFilterAttribute
//    {
//        private const string ActionTimeKey = "ActionTimeKey";
//        private static readonly NinjectDependencyResolver Resolver = new NinjectDependencyResolver();
//        private static readonly IPermissionService PermissionService = Resolver.GetService(typeof(IPermissionService)) as IPermissionService;

//        /// <summary>
//        /// 在执行操作方法之前由 ASP.NET MVC 框架调用
//        /// </summary>
//        /// <param name="filterContext"></param>
//        public override void OnActionExecuting(ActionExecutingContext filterContext)
//        {
//            base.OnActionExecuting(filterContext);

//            var controllerName = filterContext.ActionDescriptor.ControllerDescriptor.ControllerName;

//            filterContext.HttpContext.Items[ActionTimeKey] = DateTime.Now;
//            MyLogger.Debug($"{controllerName}-{nameof(OnActionExecuting)}:{DateTime.Now}");
//        }

//        /// <summary>
//        /// 在执行操作方法后由 ASP.NET MVC 框架调用
//        /// </summary>
//        /// <param name="filterContext"></param>
//        public override void OnActionExecuted(ActionExecutedContext filterContext)
//        {
//            //计算执行时间，并记录日志  
//            if (filterContext.HttpContext.Items.Contains(ActionTimeKey))
//            {
//                var controllerName = filterContext.ActionDescriptor.ControllerDescriptor.ControllerName;

//                var endTime = DateTime.Now;
//                var beginTime = Convert.ToDateTime(filterContext.HttpContext.Items[ActionTimeKey]);
//                var span = endTime - beginTime;
//                var execTimeSpan = span.TotalMilliseconds;
//                MyLogger.Debug($"{controllerName}-{nameof(OnActionExecuted)}:{execTimeSpan}");
//            }

//            base.OnActionExecuted(filterContext);
//        }

//        private string GetLoginUrl(ControllerContext filterContext)
//        {
//            var urlHelper = new UrlHelper(filterContext.RequestContext);
//            var url = urlHelper.Action("Login", "Account");
//            return url;
//        }


//    }
//}