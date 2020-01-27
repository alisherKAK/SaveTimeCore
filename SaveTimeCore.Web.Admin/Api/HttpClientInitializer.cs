using System;
using System.Net.Http;

namespace SaveTimeCore.Web.Admin.Api
{
    public class HttpClientInitializer
    {
        public static HttpClient Initialize()
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:12782/");
            return client;
        }
    }
}
