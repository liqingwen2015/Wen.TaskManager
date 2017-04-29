using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Wen.TaskManager.DAL.Concrete;
using Wen.TaskManager.Domain.Db;

namespace Wen.TaskManager.DAL.UnitTest
{
    [TestClass]
    public class RoleDaoTest
    {
        private static readonly RoleDao RoleDao = new RoleDao();

        [TestMethod]
        public void Add()
        {
            var model = new Role()
            {
                Name = "管理员"
            };

            var result = RoleDao.Add(model);
            Assert.AreNotEqual(0, result);
        }

        [TestMethod]
        public void Update()
        {
            const int id = 1;
            const string name = "test";
            var model = RoleDao.Get(id);
            model.Name = name;

            var result = RoleDao.Update(model);
            Assert.AreEqual(1, result);
        }

        [TestMethod]
        public void Get()
        {
            const int id = 1;
            var model = RoleDao.Get(id);

            Assert.IsNotNull(model);
        }

        [TestMethod]
        public void Delete()
        {
            const int id = 1;
            var model = RoleDao.Delete(id);

            Assert.IsNotNull(model);
        }

        [TestMethod]
        public void GetAll()
        {
            var models = RoleDao.GetAll();

            Assert.IsNotNull(models);
        }
    }
}
