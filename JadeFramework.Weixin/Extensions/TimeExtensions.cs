using System;

namespace JadeFramework.Weixin.Extensions
{
    public static class TimeExtensions
    {
        /// <summary>
        /// 时间转换成时间戳
        /// </summary>
        /// <param name="nowTime">当前时间</param>
        /// <returns></returns>
        public static long ToTimeStamp(this DateTime nowTime)
        {
            TimeSpan ts = DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0);
            return System.Convert.ToInt64(ts.TotalSeconds);
        }
    }
}
