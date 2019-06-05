using System;
using System.Collections.Generic;
using System.Text;

namespace JadeFramework.Core.Extensions
{
    /// <summary>
    /// 时间扩展
    /// </summary>
    public static class TimeExtensions
    {

        /// <summary>
        /// 获取当前日期（年-月-日）
        /// </summary>
        /// <param name="date">当前时间</param>
        /// <returns></returns>
        public static DateTime GetNowDate(this DateTime date)
        {
            return Convert.ToDateTime(date.ToString("yyyy-MM-dd"));
        }

        /// <summary>
        /// 获取当前月的第一天
        /// </summary>
        /// <param name="dateTime">当前时间</param>
        /// <returns></returns>
        public static DateTime MonthFirstDay(this DateTime dateTime)
        {
            return new DateTime(dateTime.Year, dateTime.Month, 1);
        }

        /// <summary>
        /// 获取当前月的最后一天时间
        /// </summary>
        /// <param name="dateTime">当前时间</param>
        /// <returns></returns>
        public static DateTime MonthLastDay(this DateTime dateTime)
        {
            return MonthFirstDay(dateTime).AddMonths(1).AddDays(-1);
        }

        /// <summary>
        /// 当前时间（date）(yyyy-MM-dd)
        /// </summary>
        /// <param name="dateTime">当前时间</param>
        /// <returns>string</returns>
        public static string NowDate(this DateTime dateTime)
        {
            return dateTime.ToString("yyyy-MM-dd");
        }

        /// <summary>
        /// 时间转换成时间戳
        /// </summary>
        /// <param name="nowTime">当前时间</param>
        /// <returns></returns>
        public static long ToTimeStamp(this DateTime nowTime)
        {
            TimeSpan ts = nowTime.AddHours(-8) - new DateTime(1970, 1, 1, 0, 0, 0, 0);
            return Convert.ToInt64(ts.TotalSeconds);
        }

        /// <summary>
        /// 时间戳转换成时间
        /// </summary>
        /// <param name="timestamp">时间戳</param>
        /// <returns></returns>
        public static DateTime ToDateTime(this long timestamp)
        {
            DateTime dtStart = new DateTime(1970, 1, 1);
            long lTime = long.Parse(timestamp + "0000000");
            TimeSpan toNow = new TimeSpan(lTime);
            return dtStart.Add(toNow);
        }
    }
}
