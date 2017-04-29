using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Wen.TaskManager.DAL.Concrete;
using Wen.TaskManager.Domain.Db;

namespace Wen.TaskManager.DAL.UnitTest
{
    [TestClass]
    public class FunctionDaoTest
    {
        private static readonly FunctionDao FunctionDao = new FunctionDao();

        [TestMethod]
        public void Add()
        {
            var model = new Function()
            {
                Name = "下载",
                TypeValue = 1
            };

            var result = FunctionDao.Add(model);
            Assert.AreEqual(1, result);
        }

        [TestMethod]
        public void Update()
        {
            const int id = 1;
            const string name = "test";
            const int typeValue = 0;

            var model = FunctionDao.Get(id);
            model.Name = name;
            model.TypeValue = typeValue;

            var result = FunctionDao.Update(model);
            Assert.AreEqual(1, result);
        }

        [TestMethod]

        public void Get()
        {
            const int id = 2;
            var model = FunctionDao.Get(id);

            Assert.IsNotNull(model);
        }

        [TestMethod]
        public void Delete()
        {
            const int id = 2;
            var model = FunctionDao.Delete(id);

            Assert.IsNotNull(model);
        }

        [TestMethod]
        public void GetAll()
        {
            var models = FunctionDao.GetAll();

            Assert.IsNotNull(models);
        }
    }
}
