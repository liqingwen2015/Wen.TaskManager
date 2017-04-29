namespace Wen.TaskManager.Domain.Db
{
    /// <summary>
    /// 菜单
    /// </summary>
    public class Menu : BaseModel
    {
        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 父 id
        /// </summary>
        public int ParentId { get; set; }

        /// <summary>
        /// url 路径
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// 排序号
        /// </summary>
        public int SortNum { get; set; }
    }
}
