using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Ninject;
using Wen.TaskManager.BLL.Abstract;
using Wen.TaskManager.BLL.Concrete;
using Wen.TaskManager.DAL.Abstract;
using Wen.TaskManager.DAL.Concrete;

namespace Wen.TaskManager.DI
{

    /// <summary>
    /// Ninject 依赖注入容器
    /// </summary>
    public class NinjectDependencyResolver : IDependencyResolver
    {
        private readonly IKernel _kernel = new StandardKernel();

        public NinjectDependencyResolver()
        {
            AddBingdings();
        }

        /// <summary>
        /// 添加绑定
        /// </summary>
        public void AddBingdings()
        {
            _kernel.Bind<IDemoService>().To<DemoService>();
            _kernel.Bind<IMenuService>().To<MenuService>();
            _kernel.Bind<IMenuDao>().To<MenuDao>();
            _kernel.Bind<IRoleDao>().To<RoleDao>();
            _kernel.Bind<IUserDao>().To<UserDao>();
        }

        public object GetService(Type serviceType)
        {
            return _kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return _kernel.GetAll(serviceType);
        }
    }

}
