#region

using System.Collections.Generic;
using Wen.TaskManager.Domain;
using Wen.TaskManager.Domain.Db;

#endregion

namespace Wen.TaskManager.BLL.Abstract
{
    public interface IMenuService : IRepositoryService<Menu>
    {
    }
}