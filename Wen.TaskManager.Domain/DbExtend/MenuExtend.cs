using System.Collections.Generic;
using Wen.TaskManager.Domain.Db;

namespace Wen.TaskManager.Domain.DbExtend
{
    public class MenuExtend : Menu
    {
        public IEnumerable<FunctionExtend> Actions { get; set; }
    }
}
