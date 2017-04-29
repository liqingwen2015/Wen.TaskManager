using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wen.TaskManager.BLL.Abstract
{
    /// <summary>
    /// 仓库服务层
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IRepositoryService<T>
    {
        IEnumerable<T> GetAll();

        T Get(int id);

        int Save(T entity);
    }
}
