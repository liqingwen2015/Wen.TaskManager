#region

using System.Collections.Generic;
using System.Data;
using Dapper;
using Wen.TaskManager.DAL.Abstract;

#endregion

namespace Wen.TaskManager.DAL.Concrete
{
    /// <summary>
    /// 仓库
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class RepositoryDao<T> : IRepositoryDao<T>
    {
        #region private field

        private static readonly IDbConnection Conn = DbConnectionFactory.CreateDbConnection();

        #endregion private field

        #region prop

        /// <summary>
        /// 数据库连接对象
        /// </summary>
        protected IDbConnection DbConnection => Conn;

        /// <summary>
        /// 表名
        /// </summary>
        public abstract string TableName { get; }

        #endregion prop

        #region abstract method

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public abstract int Add(T entity);

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public abstract int Update(T entity);

        #endregion abstract method

        #region virtual method

        /// <summary>
        /// 获取
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public virtual T Get(int id)
        {
            var sql = $@"SELECT * FROM dbo.[{TableName}] (NOLOCK) WHERE IsDel = 0 AND Id = @id;";
            return Conn.QueryFirstOrDefault<T>(sql, new {id});
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public virtual int Delete(int id)
        {
            var sql = $@"UPDATE dbo.[{TableName}] SET IsDel = 1, EditTime = GETDATE() WHERE Id = @id";
            return Conn.Execute(sql, new {id});
        }

        /// <summary>
        /// 获取所有
        /// </summary>
        /// <returns></returns>
        public virtual IEnumerable<T> GetAll()
        {
            var sql = $@"SELECT * FROM dbo.[{TableName}] (NOLOCK) WHERE IsDel = 0;";
            return Conn.Query<T>(sql);
        }

        #endregion virtual method
    }
}