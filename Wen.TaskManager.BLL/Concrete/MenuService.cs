#region

using System;
using System.Collections.Generic;
using Wen.TaskManager.BLL.Abstract;
using Wen.TaskManager.DAL.Abstract;
using Wen.TaskManager.Domain;
using Wen.TaskManager.Domain.Db;

#endregion

namespace Wen.TaskManager.BLL.Concrete
{
    public class MenuService : RepositoryService<Menu>, IMenuService
    {
        private readonly IMenuDao _menuDao;

        public MenuService(IMenuDao menuDao) : base(menuDao)
        {
            _menuDao = menuDao;
        }

        public override int Save(Menu entity)
        {
            Console.WriteLine("save ok!");
            return 1;
        }
    }


}