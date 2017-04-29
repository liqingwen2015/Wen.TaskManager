#region

using System.Collections.Generic;

#endregion

namespace Wen.TaskManager.DAL.Abstract
{
    /// <summary>
    /// 仓库
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IRepositoryDao<T>
    {
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        int Add(T entity);

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        int Delete(int id);

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        int Update(T entity);

        /// <summary>
        /// 获取
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        T Get(int id);

        /// <summary>
        /// 获取所有
        /// </summary>
        /// <returns></returns>
        IEnumerable<T> GetAll();
    }
}