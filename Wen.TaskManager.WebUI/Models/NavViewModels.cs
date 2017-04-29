using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Wen.TaskManager.Domain;
using Wen.TaskManager.Domain.Db;

namespace Wen.TaskManager.WebUI.Models
{
    public class NavSidebarViewModel
    {
        public IEnumerable<Menu> Menus { get; set; }
    }
}