using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Wen.TaskManager.DAL.Concrete;
using Wen.TaskManager.Domain.Db;

namespace Wen.TaskManager.DAL.UnitTest
{
    [TestClass]
    public class MenuDaoTest
    {
        private static readonly MenuDao MenuDao = new MenuDao();

        [TestMethod]
        public void Add()
        {
            var model = new Menu()
            {
                Name = "首页",
                ParentId = 0,
                SortNum = 1,
                Url = "/home/index"
            };

            var result = MenuDao.Add(model);
            Assert.AreEqual(1, result);
        }

        [TestMethod]
        public void Update()
        {
            const int id = 1;
            const string name = "首页";
            var model = MenuDao.Get(id);
            model.Name = name;

            var result = MenuDao.Update(model);
            Assert.AreEqual(1, result);
        }

        [TestMethod]
        public void Get()
        {
            const int id = 1;
            var model = MenuDao.Get(id);

            Assert.IsNotNull(model);
        }

        [TestMethod]
        public void Delete()
        {
            const int id = 1;
            var model = MenuDao.Delete(id);

            Assert.IsNotNull(model);
        }

        [TestMethod]
        public void GetAll()
        {
            var models = MenuDao.GetAll();

            Assert.IsNotNull(models);
        }
    }
}
