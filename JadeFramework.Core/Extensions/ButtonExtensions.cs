using JadeFramework.Core.Domain.Enum;

namespace JadeFramework.Core.Extensions
{
    /// <summary>
    /// 按钮扩展
    /// </summary>
    public static class ButtonExtension
    {
        /// <summary>
        /// 根据菜单类型获取菜单图标
        /// </summary>
        /// <param name="buttonType"></param>
        /// <returns></returns>
        public static string ToClass(this ButtonType buttonType)
        {
            string cls = "";
            switch (buttonType)
            {
                case ButtonType.View:
                    cls = "fa fa-search";
                    break;
                case ButtonType.Add:
                    cls = "fa fa-plus";
                    break;
                case ButtonType.Edit:
                    cls = "fa fa-edit";
                    break;
                case ButtonType.Delete:
                    cls = "fa fa-trash";
                    break;
                case ButtonType.Print:
                    cls = "fa fa-print";
                    break;
                case ButtonType.Check:
                    cls = "fa fa-check";
                    break;
                case ButtonType.Cancle:
                    cls = "";
                    break;
                case ButtonType.Finish:
                    cls = "";
                    break;
                case ButtonType.Extend:
                    cls = "";
                    break;
                default:
                    break;
            }
            return cls;
        }
    }

}
