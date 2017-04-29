using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Wen.TaskManager.BLL.Abstract;
using Wen.TaskManager.Domain.DbExtend;
using Wen.TaskManager.WebUI.Models;

namespace Wen.TaskManager.WebUI.Controllers
{
    public class NavController : BaseController
    {
        private readonly IMenuService _menuService;

        public NavController(IMenuService menuService)
        {
            _menuService = menuService;
        }

        public PartialViewResult Sidebar()
        {
            //var user = Session["user"] as UserExtend;
            //if (user == null)
            //{
            //    return PartialView(null);
            //}

            var menus = _menuService.GetAll();//.Where(menu => user.Menus.Select(x => x.Id).Contains(menu.Id)).ToList();
            var model = new NavSidebarViewModel
            {
                Menus = menus
            };

            return PartialView(model);
        }

        public PartialViewResult Header()
        {
            return PartialView();
        }
    }
}