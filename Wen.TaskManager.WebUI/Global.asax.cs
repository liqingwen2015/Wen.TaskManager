#region

using System;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using log4net.Config;
using Wen.TaskManager.DI;
using Wen.TaskManager.WebUI.Infrastructure.Configs;

#endregion

namespace Wen.TaskManager.WebUI
{
    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            DependencyResolver.SetResolver(new NinjectDependencyResolver());
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
        }

        /// <summary>
        /// 初始化 log4net 配置信息
        /// </summary>
        private static void InitLog4Net()
        {
            var logCfg = new FileInfo(AppDomain.CurrentDomain.BaseDirectory + "log4net.config");
            XmlConfigurator.ConfigureAndWatch(logCfg);
        }

        /// <summary>
        /// 移除 Web Form视图引擎
        /// </summary>
        private static void RemoveWebFormEngines()
        {
            var engines = ViewEngines.Engines;
            var webFormEngines = engines.OfType<WebFormViewEngine>().FirstOrDefault();

            if (webFormEngines != null)
                engines.Remove(webFormEngines);
        }
    }
}