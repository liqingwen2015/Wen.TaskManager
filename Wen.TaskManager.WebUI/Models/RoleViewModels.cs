using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Wen.TaskManager.Domain;
using Wen.TaskManager.Domain.Db;

namespace Wen.TaskManager.WebUI.Models
{
    public abstract class BaseRoleViewModel
    {
        public int RoleId { get; set; }

        public string Name { get; set; }

    }

    public class RoleEditViewModel : BaseRoleViewModel
    {
        public IEnumerable<Menu> Menus { get; set; }

        public int[] MenuIds { get; set; }
    }

    public class RoleIndexViewModel
    {
        public IEnumerable<Role> Roles { get; set; }

    }
}