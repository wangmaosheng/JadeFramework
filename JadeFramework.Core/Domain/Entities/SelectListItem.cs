namespace JadeFramework.Core.Domain.Entities
{
    /// <summary>
    /// 下拉控件实体
    /// </summary>
    public class SelectListItem
    {
        /// <summary>
        /// 是否禁用
        /// </summary>
        public bool Disabled { get; set; }

        /// <summary>
        /// 是否选中
        /// </summary>
        public bool Selected { get; set; }

        /// <summary>
        /// 文本值
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// 值
        /// </summary>
        public string Value { get; set; }
    }
}
