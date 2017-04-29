//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Net;
//using System.Web;
//using System.Web.Mvc;
//using System.Web.Security;
//using Wen.Helpers.Common.Extend;
//using Wen.TaskManager.BLL.Abstract.Other;
//using Wen.TaskManager.DI;
//using Wen.TaskManager.Domain;
//using Wen.TaskManager.Domain.Extend;
//using Wen.TaskManager.WebUI.Infrastructure.Abstract;
//using Wen.TaskManager.WebUI.Infrastructure.Concrete;

//namespace Wen.TaskManager.WebUI.Infrastructure.Filters
//{
//    /// <summary>
//    /// 自定义授权过滤器
//    /// </summary>
//    public class CustomAuthorizeFilterAttribute : AuthorizeAttribute
//    {
//        private static readonly NinjectDependencyResolver Resolver = new NinjectDependencyResolver();
//        private static readonly IPermissionService PermissionService = Resolver.GetService(typeof(IPermissionService)) as IPermissionService;

//        static CustomAuthorizeFilterAttribute()
//        {

//        }

//        /// <summary>
//        /// 在过程请求授权时调用
//        /// </summary>
//        /// <param name="filterContext"></param>
//        public override void OnAuthorization(AuthorizationContext filterContext)
//        {
//            var controllerName = filterContext.ActionDescriptor.ControllerDescriptor.ControllerName;
//            var actionName = filterContext.ActionDescriptor.ActionName;

//            if (!IsNotFilterController(controllerName))
//            {
//                UserExtend user;
//                if (!IsUserExsitSession(filterContext, out user))
//                {
//                    filterContext.Result = new RedirectResult(GenerateLoginUrl(filterContext));
//                    return;
//                }

//                var actionId = 0;
//                var actionIdValue = filterContext.RouteData.Values["actionId"];

//                if (actionIdValue != null)
//                {
//                    int.TryParse(actionIdValue.ToString(), out actionId);
//                }

//                if (!controllerName.IsEqual("Nav") && !IsHasRight(user, controllerName, actionId))
//                {
//                    var response = filterContext.RequestContext.HttpContext.Response;
//                    response.Write("无权访问");
//                    response.End();

//                    return;
//                }
//            }

//            base.OnAuthorization(filterContext);
//        }

//        /// <summary>
//        /// 生成登录 Url
//        /// </summary>
//        /// <param name="filterContext"></param>
//        /// <returns></returns>
//        private string GenerateLoginUrl(ControllerContext filterContext)
//        {
//            var urlHelper = new UrlHelper(filterContext.RequestContext);
//            var url = urlHelper.Action("Login", "Account");
//            return url;
//        }

//        /// <summary>
//        /// 是否登录页面
//        /// </summary>
//        /// <param name="controllerName"></param>
//        /// <param name="actionName"></param>
//        /// <returns></returns>
//        private static bool IsLoginPage(string controllerName, string actionName)
//        {
//            return controllerName.IsEqual("account") && actionName.IsEqual("login");
//        }

//        /// <summary>
//        /// 是否不需要过滤的控制器
//        /// </summary>
//        /// <param name="controllerName"></param>
//        /// <returns></returns>
//        private static bool IsNotFilterController(string controllerName)
//        {
//            return controllerName.IsEqual("account") || controllerName.IsEqual("nav");
//        }

//        /// <summary>
//        /// 用户是否存在于 Session 中
//        /// </summary>
//        /// <param name="filterContext"></param>
//        /// <param name="user"></param>
//        /// <returns></returns>
//        private static bool IsUserExsitSession(ControllerContext filterContext, out UserExtend user)
//        {
//            user = filterContext.HttpContext.Session?["User"] as UserExtend;
//            return user != null;
//        }

//        /// <summary>
//        /// 是否包含权限
//        /// </summary>
//        /// <param name="user"></param>
//        /// <param name="controllerName"></param>
//        /// <param name="actionId"></param>
//        /// <returns></returns>
//        private static bool IsHasRight(UserExtend user, string controllerName, int actionId = 0)
//        {
//            if (!user.Menus.Any())
//            {
//                return false;
//            }

//            var urls = user.Menus.Select(x => x.Url);
//            var result = false;

//            foreach (var url in urls)
//            {
//                result = url.Contains(controllerName);

//                if (result)
//                {
//                    break;
//                }
//            }

//            if (result && actionId > 0)
//            {
//                result = user.Actions.Select(x => x.Id).Contains(actionId);
//            }

//            return result;
//        }
//    }
//}