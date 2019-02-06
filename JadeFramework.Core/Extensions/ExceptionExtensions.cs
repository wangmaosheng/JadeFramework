using System;
using System.Text;

namespace JadeFramework.Core.Extensions
{
    /// <summary>
    /// 异常 扩展
    /// </summary>
    public static class ExceptionExtensions
    {
        /// <summary>
        /// 转换成日志相关信息
        /// </summary>
        /// <param name="exception">异常</param>
        /// <returns></returns>
        public static string ToLogMessage(this Exception exception)
        {
            return CreateExceptionString(exception);
        }

        private static string CreateExceptionString(Exception e)
        {
            StringBuilder sb = new StringBuilder();
            CreateExceptionString(sb, e, String.Empty);
            return sb.ToString();
        }

        private static void CreateExceptionString(StringBuilder sb, Exception e, string indent)
        {
            if (indent == null)
            {
                indent = String.Empty;
            }
            else if (indent.Length > 0)
            {
                sb.AppendFormat("{0}Inner ", indent);
            }
            sb.AppendFormat("Exception Found:\n{0}Type: {1}", indent, e.GetType().FullName);
            sb.AppendFormat("\n{0}Message: {1}", indent, e.Message);
            sb.AppendFormat("\n{0}Source: {1}", indent, e.Source);
            sb.AppendFormat("\n{0}Stacktrace: {1}", indent, e.StackTrace);

            if (e.InnerException != null)
            {
                sb.Append("\n");
                CreateExceptionString(sb, e.InnerException, indent + "  ");
            }
        }
    }
}
