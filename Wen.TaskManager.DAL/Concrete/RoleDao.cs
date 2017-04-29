#region

using Dapper;
using Wen.TaskManager.DAL.Abstract;
using Wen.TaskManager.Domain.Db;

#endregion

namespace Wen.TaskManager.DAL.Concrete
{
    /// <summary>
    /// 用户数据访问
    /// </summary>
    public class RoleDao : RepositoryDao<Role>, IRoleDao
    {
        public override string TableName => $"{nameof(Role)}";


        public override int Add(Role entity)
        {
            const string sql = @"INSERT INTO dbo.Role(Name)VALUES(@Name); SELECT @@IDENTITY";
            return DbConnection.ExecuteScalar<int>(sql, entity);
        }

        public override int Update(Role entity)
        {
            const string sql = @"UPDATE dbo.Role SET Name = @Name, EditTime = GETDATE() WHERE Id = @id";
            return DbConnection.Execute(sql, entity);
        }
    }
}