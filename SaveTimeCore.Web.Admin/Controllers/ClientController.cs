using System.Net.Http;
using Microsoft.AspNetCore.Mvc;

namespace SaveTimeCore.Web.Admin.Controllers
{
    public class ClientController : Controller
    {
        private readonly HttpClient _client;
        public ClientController(HttpClient client)
        {
            _client = client;
        }

        public string GetAll()
        {
            var result = _client.GetStringAsync("api/clients").Result;
            return result;
        }

        public IActionResult Delete(int id)
        {
            var result = _client.DeleteAsync("api/clients/" + id).Result;
            return Redirect("/site/vertical/table-client.html");
        }
    }
}