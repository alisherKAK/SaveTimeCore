using System.Net.Http;
using Microsoft.AspNetCore.Mvc;

namespace SaveTimeCore.Web.Admin.Controllers
{
    public class RecordController : Controller
    {
        private readonly HttpClient _client;
        public RecordController(HttpClient client)
        {
            _client = client;
        }

        public string GetAll()
        {
            var result = _client.GetStringAsync("api/records").Result;
            return result;
        }

        public IActionResult Delete(int id)
        {
            var result = _client.DeleteAsync("api/records/" + id).Result;
            return Redirect("/site/vertical/table-record.html");
        }
    }
}