using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wen.TaskManager.Domain
{
    /// <summary>
    /// 基础模型
    /// </summary>
    public abstract class BaseModel
    {
        /// <summary>
        /// 标识
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime? CreateTime { get; set; }

        /// <summary>
        /// 编辑时间
        /// </summary>
        public DateTime? EditTime { get; set; }

        /// <summary>
        /// 删除标识
        /// </summary>
        public bool IsDel { get; set; }
    }
}
