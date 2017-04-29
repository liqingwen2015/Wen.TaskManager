using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Wen.TaskManager.DAL.Concrete;
using Wen.TaskManager.Domain.Db;

namespace Wen.TaskManager.DAL.UnitTest
{
    [TestClass]
    public class UserDaoTest
    {
        private static readonly UserDao UserDao = new UserDao();

        [TestMethod]
        public void AddUser()
        {
            var user = new User()
            {
                Name = "test",
                Password = "123",
                Email = "408448945@qq.com"
            };

            var result = UserDao.Add(user);
            Assert.AreEqual(1, result);
        }

        [TestMethod]
        public void UpdateUser()
        {
            const int id = 2;
            const string name = "test1";

            var user = UserDao.Get(id);
            user.Name = name;

            UserDao.Update(user);
            user = UserDao.Get(id);

            Assert.AreEqual(name, user.Name);
        }

        [TestMethod]
        public void GetUser()
        {
            const int id = 2;
            var user = UserDao.Get(id);

            Assert.AreEqual(id, user.Id);
        }

        [TestMethod]
        public void DeleteUser()
        {
            const int id = 2;
            var result = UserDao.Delete(id);

            Assert.AreEqual(1, result);
        }

        [TestMethod]
        public void GetAllUser()
        {
            var users = UserDao.GetAll();

            Assert.IsNotNull(users);
        }
    }
}
