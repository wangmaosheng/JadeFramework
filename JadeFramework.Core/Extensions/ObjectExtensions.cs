using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;

namespace JadeFramework.Core.Extensions
{
    /// <summary>
    /// object类型扩展
    /// </summary>
    public static class ObjectExtensions
    {

        /// <summary>
        /// 将对象序列化成url参数形式
        /// </summary>
        /// <param name="obj">对象</param>
        /// <returns></returns>
        public static string ToUrlParam(this object obj)
        {
            Type type = obj.GetType();
            PropertyInfo[] infos = type.GetProperties();
            StringBuilder sb = new StringBuilder();
            foreach (PropertyInfo item in infos)
            {
                string name = item.Name;
                object val = item.GetValue(obj, null);
                if (val != null)
                {
                    sb.AppendFormat("{0}={1}&", name, val.ToString());
                }
            }
            return sb.ToString();
        }

        /// <summary>
        /// 判断对象是否为空
        /// </summary>
        /// <param name="obj">对象</param>
        /// <returns></returns>
        public static bool IsNull(this object obj)
        {
            return obj == null;
        }

        /// <summary>
        /// 判断对象不是空
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static bool IsNotNull(this object obj)
        {
            return obj != null;
        }

        /// <summary>
        /// 是否存在<see cref="T"/>集合中
        /// </summary>
        /// <typeparam name="T">集合类型</typeparam>
        /// <param name="value">要判断的值</param>
        /// <param name="list">集合</param>
        /// <returns></returns>
        public static bool In<T>(this T value, IEnumerable<T> list)
        {
            return list.Contains(value);
        }


        /// <summary>
        /// Returns the result of <paramref name="func"/> if <paramref name="obj"/> is not null.
        /// <example>
        /// <code>
        /// Request.Url.ReadValue(x => x.Query)
        /// </code>
        /// </example>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TResult">The type of the result.</typeparam>
        /// <param name="obj">The obj.</param>
        /// <param name="func">The func.</param>
        /// <returns></returns>
        public static TResult ReadValue<T, TResult>(this T obj, Func<T, TResult> func) where T : class
        {
            return ReadValue(obj, func, default(TResult));
        }

        /// <summary>
        /// Returns the result of <paramref name="func"/> if <paramref name="obj"/> is not null.
        /// Otherwise, <paramref name="defaultValue"/> is returned.
        /// <example>
        /// <code>
        /// Request.Url.ReadValue(x => x.Query, "default")
        /// </code>
        /// </example>
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="obj"></param>
        /// <param name="func"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static TResult ReadValue<T, TResult>(this T obj, Func<T, TResult> func, TResult defaultValue) where T : class
        {
            return obj != null ? func(obj) : defaultValue;
        }

        /// <summary>
        /// Executes an action if <paramref name="obj"/> is not null, otherwise does nothing
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <param name="action"></param>
        public static void ExecuteAction<T>(this T obj, Action<T> action) where T : class
        {
            if (obj != null)
            {
                action(obj);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="obj"></param>
        /// <param name="func"></param>
        /// <returns></returns>
        public static TResult ReadNullableValue<T, TResult>(this T? obj, Func<T, TResult> func)
            where T : struct
        {
            return ReadNullableValue(obj, func, default(TResult));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="obj"></param>
        /// <param name="func"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static TResult ReadNullableValue<T, TResult>(this T? obj, Func<T, TResult> func, TResult defaultValue)
            where T : struct
        {
            return obj.HasValue ? func(obj.Value) : defaultValue;
        }
    }
}