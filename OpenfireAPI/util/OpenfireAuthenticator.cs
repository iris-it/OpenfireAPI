using RestSharp.Authenticators;
using System;
using System.Linq;
using System.Text;
using RestSharp;

namespace OpenfireAPI.util
{
    public class OpenfireAuthenticator : IAuthenticator
    {
        private readonly string _sharedKey;
        private readonly string authHeader;
        public AuthenticationMode Mode { get; private set; }

        public OpenfireAuthenticator(string sharedKey)
        {
            _sharedKey = sharedKey;
            Mode = AuthenticationMode.SHARED_SECRET_KEY;
        }

        public OpenfireAuthenticator(string username, string password)
        {
            var token = Convert.ToBase64String(Encoding.UTF8.GetBytes(string.Format("{0}:{1}", username, password)));
            authHeader = string.Format("Basic {0}", token);
            Mode = AuthenticationMode.BASIC_AUTH;
        }

        public void Authenticate(IRestClient client, IRestRequest request)
        {
            if (Mode == AuthenticationMode.SHARED_SECRET_KEY)
                request.AddHeader("Authorization", _sharedKey);
            else
            {
                if (!request.Parameters.Any(p => p.Name.Equals("Authorization", StringComparison.OrdinalIgnoreCase)))
                {
                    request.AddParameter("Authorization", this.authHeader, ParameterType.HttpHeader);
                }
            }
        }
    }
}