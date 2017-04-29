//#region

//using System.Collections.Generic;
//using System.Configuration;
//using System.Linq;
//using Wen.Helpers.Common.Extend;
//using Wen.TaskManager.BLL.Abstract;
//using Wen.TaskManager.DAL.Abstract;
//using Wen.TaskManager.DAL.Abstract.Relation;
//using Wen.TaskManager.Domain;
//using Wen.TaskManager.Domain.Extend;
//using Wen.TaskManager.Domain.Relation;

//#endregion

//namespace Wen.TaskManager.BLL.Concrete
//{
//    /// <summary>
//    /// 用户服务
//    /// </summary>
//    public class UserService : IUserService
//    {
//        private readonly IUserDao _userDao;
//        private readonly IUserRoleRelationDao _userRoleRelationDao;
//        private static readonly string UserKey = ConfigurationManager.AppSettings["Security.UserKey"].ToString();

//        public UserService(IUserDao userDao, IUserRoleRelationDao useruserRelationDao)
//        {
//            _userDao = userDao;
//            _userRoleRelationDao = useruserRelationDao;
//        }

//        /// <summary>
//        /// 获取所有用户
//        /// </summary>
//        /// <returns></returns>
//        public IEnumerable<User> GetAllUsers()
//        {
//            return _userDao.GetAll();
//        }

//        /// <summary>
//        /// 获取用户
//        /// </summary>
//        /// <param name="id"></param>
//        /// <returns></returns>
//        public User GetUser(int id)
//        {
//            return _userDao.Get(id);
//        }

//        /// <summary>
//        /// 保存用户信息
//        /// </summary>
//        /// <param name="user"></param>
//        /// <returns></returns>
//        public int SaveUser(User user)
//        {
//            if (user.Id < 0)
//                return 0;

//            if (user.Id == 0)
//                return AddUser(user);

//            if (user.Id > 0)
//                DeleteUserRelation(user.Id);

//            var result = UpdateUser(user);
//            return result;
//        }

//        /// <summary>
//        /// 是否有效用户
//        /// </summary>
//        /// <returns></returns>
//        public bool IsValid(string userName, string password, out UserExtend user)
//        {
//            if (string.IsNullOrEmpty(userName) || string.IsNullOrEmpty(password))
//            {
//                user = null;
//                return false;
//            }

//            password = (password + UserKey).ToSha256();
//            user = (UserExtend)_userDao.Get(userName);

//            return user.Password.IsEqual(password);
//        }

//        #region private method

//        /// <summary>
//        /// 更新用户
//        /// </summary>
//        /// <returns></returns>
//        private int UpdateUser(User user)
//        {
//            var model = GetUser(user.Id);

//            if (model == null)
//            {
//                return 0;
//            }

//            model.Name = user.Name;

//            if (!user.UserRoleRelations.Any())
//                return _userDao.Update(user);

//            model.UserRoleRelations = user.UserRoleRelations;
//            AddUserRoleRelations(model);

//            return _userDao.Update(user);
//        }

//        /// <summary>
//        /// 新增用户
//        /// </summary>
//        /// <returns></returns>
//        private int AddUser(User user)
//        {
//            var id = _userDao.Add(user);
//            user.Id = id;

//            AddUserRoleRelations(user);

//            return id;
//        }

//        /// <summary>
//        /// 添加用户角色关系
//        /// </summary>
//        /// <param name="user"></param>
//        /// <returns></returns>
//        private int AddUserRoleRelations(User user)
//        {
//            var relations = user.UserRoleRelations;
//            user.UserRoleRelations = relations.Select(x => new UserRoleRelation()
//            {
//                UserId = user.Id,
//                RoleId = x.RoleId
//            });

//            //TODO:需要批量添加
//            var i = 0;
//            foreach (var userRoleRelation in user.UserRoleRelations)
//            {
//                _userRoleRelationDao.Add(userRoleRelation);
//                i++;
//            }

//            return i;
//        }

//        /// <summary>
//        /// 删除用户关系
//        /// </summary>
//        /// <param name="userId"></param>
//        /// <returns></returns>
//        private int DeleteUserRelation(int userId)
//        {
//            //删除角色菜单的旧关系
//            var result = _userRoleRelationDao.Delete(new UserRoleRelation()
//            {
//                UserId = userId
//            });

//            return result;
//        }

//        #endregion private method
//    }
//}