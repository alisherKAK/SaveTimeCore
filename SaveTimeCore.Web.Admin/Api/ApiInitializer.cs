using System;
using System.Net.Http;

namespace SaveTimeCore.Web.Admin.Api
{
    public class ApiInitializer
    {
        public static HttpClient Initialize()
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:12782/");
            return client;
        }
    }
}
