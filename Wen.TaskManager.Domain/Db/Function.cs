namespace Wen.TaskManager.Domain.Db
{
    /// <summary>
    /// 功能
    /// </summary>
    public class Function : BaseModel
    {
        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 类型值
        /// </summary>
        public int TypeValue { get; set; }
    }
}
