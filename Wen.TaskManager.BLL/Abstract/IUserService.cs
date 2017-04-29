#region

using System.Collections.Generic;
using Wen.TaskManager.Domain;
using Wen.TaskManager.Domain.DbExtend;

#endregion

namespace Wen.TaskManager.BLL.Abstract
{
    /// <summary>
    /// 用户服务层
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IUserService<T> : IRepositoryService<T>
    {

        bool IsValid(string userName, string password, out UserExtend user);
    }
}