using System;

namespace JadeFramework.Core.Extensions
{
    /// <summary>
    /// 整型扩展
    /// </summary>
    public static class IntegerExtensions
    {

        /// <summary>
        /// 是否为空
        /// </summary>
        /// <param name="val"></param>
        /// <returns></returns>
        public static bool IsNull(this Byte? val)
        {
            return val == null;
        }

        /// <summary>
        /// 是否为空
        /// </summary>
        /// <param name="val"></param>
        /// <returns></returns>
        public static bool IsNull(this SByte? val)
        {
            return val == null;
        }

        /// <summary>
        /// 是否为空
        /// </summary>
        /// <param name="val"></param>
        /// <returns></returns>
        public static bool IsNull(this Int16? val)
        {
            return val == null;
        }

        /// <summary>
        /// 是否为空
        /// </summary>
        /// <param name="val"></param>
        /// <returns></returns>
        public static bool IsNull(this Int32? val)
        {
            return val == null;
        }

        /// <summary>
        /// 是否为空
        /// </summary>
        /// <param name="val"></param>
        /// <returns></returns>
        public static bool IsNull(this Int64? val)
        {
            return val == null;
        }
    }
}
