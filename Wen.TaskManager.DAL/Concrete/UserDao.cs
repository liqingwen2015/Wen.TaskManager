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
    public class UserDao : RepositoryDao<User>, IUserDao
    {
        public override string TableName => $"{nameof(User)}";


        public override int Add(User entity)
        {
            const string sql = @"INSERT INTO dbo.[User](Name, Password, Email)VALUES(@name, @password, @email)";
            return DbConnection.Execute(sql, entity);
        }

        public override int Update(User entity)
        {
            const string sql =
                @"UPDATE dbo.[User] SET Name = @Name, EditTime = GETDATE(), Password = @Password WHERE Id = @id";
            return DbConnection.Execute(sql, entity);
        }
    }
}