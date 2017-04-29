using System.Collections.Generic;
using Wen.TaskManager.Domain.Db;

namespace Wen.TaskManager.Domain.DbExtend
{
    /// <summary>
    /// 用户
    /// </summary>
    public class UserExtend : User
    {
        /// <summary>
        /// 角色
        /// </summary>
        public IEnumerable<RoleExtend> Roles { get; set; }

        /// <summary>
        /// 菜单
        /// </summary>
        public IEnumerable<MenuExtend> Menus { get; set; }

        /// <summary>
        /// 功能
        /// </summary>
        public IEnumerable<FunctionExtend> Actions { get; set; }

    }
}
