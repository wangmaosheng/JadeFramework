using JadeFramework.Core.Domain.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace JadeFramework.Core.Extensions
{
    /// <summary>
    /// Enumerable集合扩展
    /// </summary>
    public static class EnumerableExtensions
    {
        /// <summary>
        /// 区分去重
        /// </summary>
        /// <typeparam name="TSource">实体类型</typeparam>
        /// <typeparam name="TKey">去重返回值类型</typeparam>
        /// <param name="source">要去重的集合</param>
        /// <param name="keySelector">去重表达</param>
        /// <returns></returns>
        public static IEnumerable<TSource> DistinctBy<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector)
        {
            HashSet<TKey> hash = new HashSet<TKey>();
            return
                from p in source
                where hash.Add(keySelector(p))
                select p;
        }

        /// <summary>
        /// 随机取IEnumerable中的一个对象
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        /// <param name="source">IEnumerable</param>
        /// <returns></returns>
        public static T Random<T>(this IEnumerable<T> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            Random random = new Random();
            if (source is ICollection)
            {
                ICollection collection = source as ICollection;
                int count = collection.Count;
                if (count == 0)
                {
                    throw new Exception("IEnumerable没有数据");
                }
                int index = random.Next(count);
                return source.ElementAt(index);
            }
            using (IEnumerator<T> iterator = source.GetEnumerator())
            {
                if (!iterator.MoveNext())
                {
                    throw new Exception("IEnumerable没有数据");
                }
                int count = 1;
                T current = iterator.Current;
                while (iterator.MoveNext())
                {
                    count++;
                    if (random.Next(count) == 0)
                    {
                        current = iterator.Current;
                    }
                }
                return current;
            }
        }

        /// <summary>
        /// 随机取IEnumerable中的一个对象
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        /// <param name="source">IEnumerable</param>
        /// <param name="random">随机对象</param>
        /// <returns></returns>
        public static T Random<T>(this IEnumerable<T> source, Random random)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            if (random == null)
            {
                throw new ArgumentNullException("random");
            }
            if (source is ICollection)
            {
                ICollection collection = source as ICollection;
                int count = collection.Count;
                if (count == 0)
                {
                    throw new Exception("IEnumerable没有数据");
                }
                int index = random.Next(count);
                return source.ElementAt(index);
            }
            using (IEnumerator<T> iterator = source.GetEnumerator())
            {
                if (!iterator.MoveNext())
                {
                    throw new Exception("IEnumerable没有数据");
                }
                int count = 1;
                T current = iterator.Current;
                while (iterator.MoveNext())
                {
                    count++;
                    if (random.Next(count) == 0)
                    {
                        current = iterator.Current;
                    }
                }
                return current;
            }
        }

        /// <summary>
        /// IEnumerable集合中加入分隔符
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="values"></param>
        /// <param name="separator">分隔符默认 ,</param>
        /// <returns></returns>
        public static string Join<T>(this IEnumerable<T> values, string separator = ",")
        {
            if (values == null || !values.Any())
            {
                return string.Empty;
            }
            if (separator.IsNull())
            {
                separator = string.Empty;
            }
            return string.Join(separator, values);
        }

        /// <summary>
        /// 判断IEnumerable是否有元素
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="values"></param>
        /// <returns></returns>
        public static bool HasItems<T>(this IEnumerable<T> values)
        {
            return values.IsNotNull() && values.Any();
        }

        /// <summary>
        /// <see cref="IEnumerable"/>转换成<see cref="SelectListItem"/>集合类型
        /// </summary>
        /// <typeparam name="TSource">数据元素类型</typeparam>
        /// <typeparam name="TValue"><see cref="SelectListItem"/>值类型</typeparam>
        /// <typeparam name="TText"><see cref="SelectListItem"/>显示文本类型</typeparam>
        /// <param name="source">数据</param>
        /// <param name="valueSelector">用于从每个元素中提取值的函数</param>
        /// <param name="textSelector">用于从每个元素中提取文本的函数</param>
        /// <returns></returns>
        public static List<SelectListItem> ToSelectListItem<TSource,TValue,TText>(this IEnumerable<TSource> source,
            Func<TSource, TValue> valueSelector,Func<TSource,TText> textSelector)
        {
            if (source==null)
            {
                throw new ArgumentException(nameof(source));
            }
            if (valueSelector == null)
            {
                throw new ArgumentException(nameof(valueSelector));
            }
            if (textSelector == null)
            {
                throw new ArgumentException(nameof(textSelector));
            }
            List<SelectListItem> items = source.Select(s => new SelectListItem()
            {
                Value = valueSelector(s).ToString(),
                Text = textSelector(s).ToString()
            }).ToList();
            return items;
        }
    }
}
