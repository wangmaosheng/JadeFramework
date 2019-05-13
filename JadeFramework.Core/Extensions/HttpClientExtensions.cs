using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace JadeFramework.Core.Extensions
{
    /// <summary>
    /// HttpClient 扩展
    /// </summary>
    public static class HttpClientExtensions
    {
        /// <summary>
        /// 返回值必须是bool类型的请求
        /// </summary>
        /// <param name="httpClient"></param>
        /// <param name="uri"></param>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static async Task<bool> PostBooleanAsync(this HttpClient httpClient, string uri, object entity)
        {
            try
            {
                var content = new StringContent(JsonConvert.SerializeObject(entity), System.Text.Encoding.UTF8, "application/json");
                var response = await httpClient.PostAsync(uri, content);
                response.EnsureSuccessStatusCode();
                string res = await response.Content.ReadAsStringAsync();
                return res.ToLower() == bool.TrueString.ToLower();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// 获取对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="httpClient"></param>
        /// <param name="uri"></param>
        /// <returns></returns>
        public static async Task<T> GetObjectAsync<T>(this HttpClient httpClient, string uri) where T : class
        {
            try
            {
                var responseString = await httpClient.GetStringAsync(uri);
                return responseString.ToObject<T>();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
