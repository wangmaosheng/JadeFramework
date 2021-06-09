using System;
using JadeFramework.Core.Extensions;

namespace JadeFramework.Test
{
    class Program
    {
        static void Main(string[] args)
        {

            //当月第一天
            DateTimeOffset time = new DateTimeOffset(new DateTime(DateTimeOffset.UtcNow.Year, DateTimeOffset.UtcNow.Month, 1));
            //当月开始时间时间戳
            long monthStartTime = time.ToUnixTimeSeconds();
            //当月结束时间时间戳
            DateTimeOffset time2 = new DateTimeOffset(DateTimeOffset.UtcNow.AddDays(1 - DateTimeOffset.UtcNow.Day).Date.AddMonths(1).AddSeconds(-1));
            long monthEndTime = time2.ToUnixTimeSeconds();
            Console.WriteLine("ts1:" + monthStartTime);
            Console.WriteLine("ts2:" + monthEndTime);

            //long ts1 = DateTime.Now.ToTimeStamp();
            //Console.WriteLine("ts1:" + ts1);
            //long ts2 = DateTime.Now.ToCstTime().ToTimeStamp();
            //Console.WriteLine("ts2:" + ts2);
            //long ts3 = DateTimeOffset.Now.ToUnixTimeSeconds();
            //Console.WriteLine("ts3:" + ts3);

            //DateTimeOffset time4 = new DateTimeOffset(DateTimeOffset.UtcNow.Year, DateTimeOffset.UtcNow.Month, 1, 0, 0, 0, TimeSpan.Zero);
            //Console.WriteLine("ts4:" + time4.ToUnixTimeSeconds());



            //string ts = DateTime.Now.ToCstTime().ToTimeStamp().ToString();
            //Console.WriteLine("ts:" + ts);

            //DateTime time = Convert.ToInt64(ts).ToDateTime();

            //Console.WriteLine("time:" + time);


            //DateTime dt = DateTime.Now.ToCstTime();

            //long fts = DateTime.Now.MonthFirstDay().ToTimeStamp();
            //Console.WriteLine("time1111:" + fts);


            ////当月第一天
            //DateTimeOffset time2 = new DateTimeOffset(DateTimeOffset.UtcNow.Year, DateTimeOffset.UtcNow.Month, 1, 0, 0, 0, TimeSpan.Zero);
            ////当月开始时间时间戳
            //long monthStartTime = time2.ToUnixTimeSeconds();
            //////当月结束时间时间戳
            ////long monthEndTime = time2.AddMonths(1).AddDays(-1).ToUnixTimeSeconds();

            //Console.WriteLine("time2222:" + monthStartTime);



            Console.ReadLine();

        }
    }
}
