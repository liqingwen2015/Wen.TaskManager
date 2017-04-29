using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Wen.TaskManager.BLL.Abstract;
using Wen.TaskManager.BLL.Concrete;
using Wen.TaskManager.DAL.Abstract;
using Wen.TaskManager.DAL.Concrete;
using Wen.TaskManager.Domain.Db;

namespace Wen.TaskManager.BLL.UnitTest
{
    [TestClass]
    public class MenuServiceTest
    {
        private static readonly IMenuDao MenuDao = new MenuDao();
        private static readonly IMenuService MenuService = new MenuService(MenuDao);

        [TestMethod]
        public void Get()
        {
            var menu = MenuService.Get(3);
            Console.WriteLine(menu.Name);

            Assert.IsNotNull(menu);
        }

        [TestMethod]
        public void Save()
        {
            var result = MenuService.Save(new Menu());

            Assert.AreNotEqual(0, result);
        }
    }
}
