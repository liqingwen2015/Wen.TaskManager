#region

using Dapper;
using Wen.TaskManager.DAL.Abstract;
using Wen.TaskManager.Domain.Db;

#endregion

namespace Wen.TaskManager.DAL.Concrete
{
    /// <summary>
    /// 菜单访问层
    /// </summary>
    public class MenuDao : RepositoryDao<Menu>, IMenuDao
    {
        public override string TableName => $"{nameof(Menu)}";


        public override int Add(Menu entity)
        {
            const string sql =
                @"INSERT INTO dbo.Menu(Name, ParentId, Url, SortNum)VALUES(@Name, @ParentId, @Url, @SortNum); SELECT @@IDENTITY";
            return DbConnection.Execute(sql, entity);
        }

        public override int Update(Menu entity)
        {
            const string sql =
                @"UPDATE dbo.Menu SET Name = @Name, EditTime = GETDATE(), ParentId = @ParentId, Url = @Url, SortNum = @SortNum WHERE Id = @id";
            return DbConnection.Execute(sql, entity);
        }
    }
}