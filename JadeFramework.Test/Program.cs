using System;
using JadeFramework.Core.Extensions;

namespace JadeFramework.Test
{
    class Program
    {
        static void Main(string[] args)
        {

            string ts = DateTime.Now.ToCstTime().ToTimeStamp().ToString();
            Console.WriteLine("ts:" + ts);

            DateTime time = Convert.ToInt64(ts).ToDateTime();

            Console.WriteLine("time:" + time);

            Console.ReadLine();
            
        }
    }
}
