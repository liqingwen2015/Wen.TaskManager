//#region

//using System.Collections.Generic;
//using System.Linq;
//using Wen.TaskManager.BLL.Abstract;
//using Wen.TaskManager.DAL.Abstract;
//using Wen.TaskManager.DAL.Abstract.Relation;
//using Wen.TaskManager.Domain;
//using Wen.TaskManager.Domain.Relation;

//#endregion

//namespace Wen.TaskManager.BLL.Concrete
//{
//    /// <summary>
//    /// 角色服务
//    /// </summary>
//    public class RoleService : IRoleService
//    {
//        private readonly IRoleDao _roleDao;
//        private readonly IRoleMenuRelationDao _roleMenuRelationDao;

//        /// <summary>
//        /// 角色服务
//        /// </summary>
//        /// <param name="roleDao"></param>
//        /// <param name="roleMenuRelationDao"></param>
//        public RoleService(IRoleDao roleDao, IRoleMenuRelationDao roleMenuRelationDao)
//        {
//            _roleDao = roleDao;
//            _roleMenuRelationDao = roleMenuRelationDao;
//        }

//        /// <summary>
//        /// 获取角色
//        /// </summary>
//        /// <returns></returns>
//        public IEnumerable<Role> GetRoles()
//        {
//            return _roleDao.GetAll();
//        }

//        /// <summary>
//        /// 获取角色
//        /// </summary>
//        /// <param name="id"></param>
//        /// <returns></returns>
//        public Role GetRole(int id)
//        {
//            return _roleDao.Get(id);
//        }

//        /// <summary>
//        /// 保存角色
//        /// </summary>
//        /// <param name="role"></param>
//        /// <returns></returns>
//        public int SaveRole(Role role)
//        {
//            if (role.Id < 0)
//                return 0;

//            if (role.Id == 0)
//                return AddRole(role);

//            if (role.Id > 0)
//                DeleteRoleRelation(role.Id);

//            var result = UpdateRole(role);
//            return result;
//        }

//        #region private method

//        /// <summary>
//        /// 更新角色
//        /// </summary>
//        /// <returns></returns>
//        private int UpdateRole(Role role)
//        {
//            var model = GetRole(role.Id);

//            if (model == null)
//            {
//                return 0;
//            }

//            model.Name = role.Name;

//            if (!role.RoleMenuRelations.Any())
//                return _roleDao.Update(role);

//            model.RoleMenuRelations = role.RoleMenuRelations;
//            AddRoleMenuRelations(model);

//            return _roleDao.Update(role);
//        }

//        /// <summary>
//        /// 新增角色
//        /// </summary>
//        /// <param name="role"></param>
//        /// <returns></returns>
//        private int AddRole(Role role)
//        {
//            var id = _roleDao.Add(role);
//            role.Id = id;

//            AddRoleMenuRelations(role);

//            return id;
//        }

//        /// <summary>
//        /// 添加角色菜单关系
//        /// </summary>
//        /// <param name="role"></param>
//        /// <returns></returns>
//        private int AddRoleMenuRelations(Role role)
//        {
//            var relations = role.RoleMenuRelations;
//            role.RoleMenuRelations = relations.Select(x => new RoleMenuRelation
//            {
//                MenuId = x.MenuId,
//                RoleId = role.Id
//            });

//            //TODO:需要批量添加
//            var i = 0;
//            foreach (var roleMenuRelation in role.RoleMenuRelations)
//            {
//                _roleMenuRelationDao.Add(roleMenuRelation);
//                i++;
//            }

//            return i;
//        }

//        /// <summary>
//        /// 删除角色关系
//        /// </summary>
//        /// <param name="roleId"></param>
//        /// <returns></returns>
//        private int DeleteRoleRelation(int roleId)
//        {
//            //删除角色菜单的旧关系
//            var result = _roleMenuRelationDao.Delete(new RoleMenuRelation
//            {
//                RoleId = roleId
//            });

//            return result;
//        }

//        #endregion private method


//    }
//}