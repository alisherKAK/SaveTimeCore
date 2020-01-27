using System.Net.Http;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SaveTimeCore.Web.Admin.Models;

namespace SaveTimeCore.Web.Admin.Controllers
{
    public class ServiceController : Controller
    {
        private readonly HttpClient _client;
        public ServiceController(HttpClient client)
        {
            _client = client;
        }

        public string GetAll()
        {
            var result = _client.GetStringAsync("api/services").Result;
            return result;
        }
        [HttpPost]
        public IActionResult Create(ServiceCreateViewModel serviceCreateViewModel)
        {
            var json = JsonConvert.SerializeObject(serviceCreateViewModel);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            var result = _client.PostAsync("api/services", data).Result;

            if (result.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return Redirect("/site/vertical/table-service.html");
            }

            return Redirect("/site/vertical/create-service.html");
        }
        public IActionResult Delete(int id)
        {
            var result = _client.DeleteAsync("api/services/" + id).Result;

            return Redirect("/site/vertical/table-service.html");
        }
    }
}