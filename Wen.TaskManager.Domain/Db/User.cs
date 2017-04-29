using System.Collections.Generic;

namespace Wen.TaskManager.Domain.Db
{
    /// <summary>
    /// 用户
    /// </summary>
    public partial class User : BaseModel
    {
        /// <summary>
        /// 密码
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// 邮箱
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }
    }
}
