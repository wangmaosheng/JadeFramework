using JadeFramework.Core.Extensions;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;

namespace JadeFramework.Core.Domain.Authorization
{
    /// <summary>
    /// 
    /// </summary>
    public class AuthorizationHttpClientHandler : HttpClientHandler
    {
        private readonly string _authorizationCode;
        private readonly Func<Task<string>> _getToken;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="authorizationCode"></param>
        public AuthorizationHttpClientHandler(string authorizationCode)
        {
            _authorizationCode = authorizationCode;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="getToken"></param>
        public AuthorizationHttpClientHandler(Func<Task<string>> getToken)
        {
            if (getToken == null)
                throw new ArgumentNullException("getToken");
            _getToken = getToken;
        }
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            // See if the request has an authorize header
            var auth = request.Headers.Authorization;
            if (auth != null)
            {
                if (_authorizationCode.IsNullOrEmpty())
                {
                    var token = await _getToken().ConfigureAwait(false);
                    request.Headers.Authorization = new AuthenticationHeaderValue(auth.Scheme, token);
                }
                else
                {
                    request.Headers.Authorization = new AuthenticationHeaderValue(auth.Scheme, _authorizationCode);
                }
            }
            return await base.SendAsync(request, cancellationToken).ConfigureAwait(false);
        }
    }
}
