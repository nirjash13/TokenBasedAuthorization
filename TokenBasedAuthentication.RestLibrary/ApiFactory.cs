using System.Configuration;
using RestSharp;

namespace TokenBasedAuthentication.RestLibrary
{
    public static class ApiFactory
    {
        public static RestClient GetClient()
        {
            var baseUrl = ConfigurationManager.AppSettings["InternalApiBaseUrl"];
            var client = new RestClient(baseUrl);

            return client;
        }
    }
}