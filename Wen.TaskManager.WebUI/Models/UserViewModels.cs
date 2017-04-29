#region

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Wen.TaskManager.Domain.Db;

#endregion

namespace Wen.TaskManager.WebUI.Models
{
    public abstract class BaseUserViewModel
    {
        public int UserId { get; set; }

        [Required(ErrorMessage = "姓名不能为空")]
        public string Name { get; set; }
    }

    public class UserEditViewModel : BaseUserViewModel
    {
        public int RoleId { get; set; }

        public IEnumerable<Role> Roles { get; set; }

        public int[] RoleIds { get; set; }
    }

    public class UserIndexViewModel
    {
        public IEnumerable<User> Users { get; set; }
    }
}