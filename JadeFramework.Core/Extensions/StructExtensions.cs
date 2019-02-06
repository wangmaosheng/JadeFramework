namespace JadeFramework.Core.Extensions
{
    /// <summary>
    /// 结构类型扩展
    /// </summary>
    public static class StructExtensions
    {
        #region 是否是默认值判断

        /// <summary>
        /// 是否是默认值
        /// </summary>
        /// <param name="val"></param>
        /// <returns></returns>
        public static bool IsDefault(this byte val)
        {
            return val == default(byte);
        }

        /// <summary>
        /// 是否是默认值
        /// </summary>
        /// <param name="val"></param>
        /// <returns></returns>
        public static bool IsDefault(this byte? val)
        {
            return val == default(byte?);
        }

        /// <summary>
        /// 是否是默认值
        /// </summary>
        /// <param name="val"></param>
        /// <returns></returns>
        public static bool IsDefault(this sbyte val)
        {
            return val == default(byte);
        }

        /// <summary>
        /// 是否是默认值
        /// </summary>
        /// <param name="val"></param>
        /// <returns></returns>
        public static bool IsDefault(this sbyte? val)
        {
            return val == default(byte?);
        }

        /// <summary>
        /// 是否是默认值
        /// </summary>
        /// <param name="val"></param>
        /// <returns></returns>
        public static bool IsDefault(this int val)
        {
            return val == default(int);
        }
        /// <summary>
        /// 是否是默认值
        /// </summary>
        /// <param name="val"></param>
        /// <returns></returns>
        public static bool IsDefault(this int? val)
        {
            return val == default(int?);
        }
        /// <summary>
        /// 是否是默认值
        /// </summary>
        /// <param name="val"></param>
        /// <returns></returns>
        public static bool IsDefault(this long val)
        {
            return val == default(long);
        }
        /// <summary>
        /// 是否是默认值
        /// </summary>
        /// <param name="val"></param>
        /// <returns></returns>
        public static bool IsDefault(this long? val)
        {
            return val == default(long?);
        }
        /// <summary>
        /// 是否是默认值
        /// </summary>
        /// <param name="val"></param>
        /// <returns></returns>
        public static bool IsDefault(this string val)
        {
            return val == default(string);
        }
        /// <summary>
        /// 是否是默认值
        /// </summary>
        /// <param name="val"></param>
        /// <returns></returns>
        public static bool IsDefault(this decimal val)
        {
            return val == default(decimal);
        }
        /// <summary>
        /// 是否是默认值
        /// </summary>
        /// <param name="val"></param>
        /// <returns></returns>
        public static bool IsDefault(this decimal? val)
        {
            return val == default(decimal?);
        }

        #endregion

    }
}
