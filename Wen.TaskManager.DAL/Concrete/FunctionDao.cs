#region

using Dapper;
using Wen.TaskManager.DAL.Abstract;
using Wen.TaskManager.Domain.Db;

#endregion

namespace Wen.TaskManager.DAL.Concrete
{
    /// <summary>
    /// 功能
    /// </summary>
    public class FunctionDao : RepositoryDao<Function>, IFuctionDao
    {
        public override string TableName => $"{nameof(Function)}";


        public override int Add(Function entity)
        {
            const string sql =
                @"INSERT INTO dbo.[Function](Name, TypeValue)VALUES(@Name, @TypeValue); SELECT @@IDENTITY";
            return DbConnection.Execute(sql, entity);
        }

        public override int Update(Function entity)
        {
            const string sql =
                @"UPDATE dbo.[Function] SET Name = @Name, TypeValue = @TypeValue, EditTime = GETDATE() WHERE Id = @id";
            return DbConnection.Execute(sql, entity);
        }
    }
}