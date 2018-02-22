using System.Collections.Generic;
using Newtonsoft.Json;
using RestSharp;
using AuthenticationServer.RestLibrary.Interfaces;

namespace AuthenticationServer.RestLibrary.Security
{
    public class SecurityService : ISecurityService
    {
        private readonly RestClient _restClient;
        public string AuthTokenName { get; set; }

        public SecurityService()
        {
            _restClient = ApiFactory.GetClient();
        }
        public string GetToken(string userName, string password)
        {
            var requestUrl = string.Format("token");

            var request = new RestRequest(requestUrl, Method.POST);
            request.AddHeader("Accept", "application/json");
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
            request.AddParameter("username", userName);
            request.AddParameter("password", password);
            request.AddParameter("grant_type", "password");
            var tResponse = _restClient.Execute(request);
            var responseJson = tResponse.Content;
            var token = JsonConvert.DeserializeObject<Dictionary<string, object>>(responseJson)["access_token"].ToString();
            return token.Length > 0 ? token : null;
        }


        public string TestForAuthorizedUsers(string token)
        {
           
            var request = new RestRequest("api/data/authorize", Method.GET)
            {
                RequestFormat = DataFormat.Json
            };

            request.AddHeader("Authorization", string.Format("bearer {0}", token));
            request.AddHeader("Accept", "application/json");
            var result = _restClient.Execute(request);

            return result.Content;

        }


        public string TestAuthenticatedUsers(string token)
        {
            var request = new RestRequest("api/data/foraauthenticated", Method.GET)
            {
                RequestFormat = DataFormat.Json
            };

            request.AddHeader("Authorization", string.Format("bearer {0}", token));
            request.AddHeader("Accept", "application/json");
           
            var result = _restClient.Execute(request);
            
            return result.Content;
        }

        public string TestAutheorizationForUserWithUnauthorizedRole(string token)
        {
            var request = new RestRequest("api/data/authenticate", Method.GET)
            {
                RequestFormat = DataFormat.Json
            };

            request.AddHeader("Authorization", string.Format("bearer {0}", token));
            request.AddHeader("Accept", "application/json");

            var result = _restClient.Execute(request);

            return result.StatusCode.ToString();
        }
    }
}