using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Wen.TaskManager.Domain;
using Wen.TaskManager.Domain.Db;

namespace Wen.TaskManager.WebUI.Models
{
    public abstract class BaseMenuViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Url { get; set; }

        public int ParentId { get; set; }

        public int SortNum { get; set; }
    }

    public class MenuEditViewModel : BaseMenuViewModel
    {
        public int[] MenuIds { get; set; }
    }

    public class MenuIndexViewModel 
    {
        public IEnumerable<Menu> Menus { get; set; }

    }
}