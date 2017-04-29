using System.Collections.Generic;
using Wen.TaskManager.Domain.Db;

namespace Wen.TaskManager.Domain.DbExtend
{
    public class RoleExtend:Role
    {
        public IEnumerable<MenuExtend> Menus { get; set; }
    }
}
