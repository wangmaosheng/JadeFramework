using System.Collections.Generic;

namespace JadeFramework.Core.Domain.Container
{
    /// <summary>
    /// 缓存容器接口
    /// </summary>
    public interface ICacheContainer
    {
        /// <summary>
        /// 获取
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key">key</param>
        /// <returns></returns>
        T Get<T>(string key) where T : class;
        /// <summary>
        /// 设置
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key">key</param>
        /// <param name="t">数据</param>
        /// <param name="timeout">过期时间</param>
        /// <returns></returns>
        bool Set<T>(string key, T t, int timeout);

        /// <summary>
        /// 获取集合
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key">KEY</param>
        /// <returns></returns>
        IList<T> GetList<T>(string key);

        /// <summary>
        /// 设置集合
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key">KEY</param>
        /// <param name="list">数据</param>
        void SetList<T>(string key, IList<T> list);

        /// <summary>
        /// 设置集合
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key">KEY</param>
        /// <param name="list">数据</param>
        /// <param name="timeout">过期时间</param>
        void SetList<T>(string key, IList<T> list, int timeout);

        /// <summary>
        /// 移除数据
        /// </summary>
        /// <param name="key">KEY</param>
        /// <returns></returns>
        bool Remove(string key);
    }
}
