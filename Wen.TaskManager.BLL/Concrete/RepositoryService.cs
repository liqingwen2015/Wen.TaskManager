using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wen.TaskManager.BLL.Abstract;
using Wen.TaskManager.DAL.Abstract;

namespace Wen.TaskManager.BLL.Concrete
{
    public abstract class RepositoryService<T> : IRepositoryService<T>
    {
        private readonly IRepositoryDao<T> _repositoryDao;

        protected RepositoryService(IRepositoryDao<T> repositoryDao)
        {
            _repositoryDao = repositoryDao;
        }

        public virtual IEnumerable<T> GetAll()
        {
            return _repositoryDao.GetAll();
        }

        public virtual T Get(int id)
        {
            return _repositoryDao.Get(id);
        }

        public abstract int Save(T entity);
    }
}
