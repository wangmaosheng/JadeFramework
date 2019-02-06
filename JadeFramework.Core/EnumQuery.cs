using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace JadeFramework.Core
{
    /// <summary>
    /// 枚举泛型类
    /// </summary>
    /// <typeparam name="T">枚举类型</typeparam>
    public static class Enum<T>
    {
        /// <summary>
        /// 转换成Enumerable
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<T> AsEnumerable()
        {
            return new EnumQuery<T>();
        }
    }

    /// <summary>
    /// Enum查询类
    /// </summary>
    /// <typeparam name="T">枚举类型</typeparam>
    public class EnumQuery<T> : IEnumerable<T>
    {
        /// <summary>
        /// 实现迭代
        /// </summary>
        /// <returns></returns>
        public IEnumerator<T> GetEnumerator()
        {
            Array values = System.Enum.GetValues(typeof(T));
            List<T> list = new List<T>(values.Length);
            list.AddRange(from object value in values select (T)value);
            return list.GetEnumerator();
        }


        #region IEnumerable Members

        /// <summary>
        /// 在转换成List调用迭代器
        /// </summary>
        /// <returns></returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        #endregion
    }
}
