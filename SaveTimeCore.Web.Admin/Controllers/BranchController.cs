using System.Net.Http;
using Microsoft.AspNetCore.Mvc;

namespace SaveTimeCore.Web.Admin.Controllers
{
    public class BranchController : Controller
    {
        private readonly HttpClient _client;
        public BranchController(HttpClient client)
        {
            _client = client;
        }

        public string GetAll()
        {
            var result = _client.GetStringAsync("api/branches").Result;
            return result;
        }
    }
}