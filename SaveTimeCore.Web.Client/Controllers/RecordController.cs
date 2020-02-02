using System.Net.Http;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SaveTimeCore.Web.Client.Models;

namespace SaveTimeCore.Web.Client.Controllers
{
    public class RecordController : Controller
    {
        private readonly HttpClient _client;
        public RecordController(HttpClient client)
        {
            _client = client;
        }
 
        public string GetAllBarbers()
        {
            var result = _client.GetStringAsync("api/barbers").Result;
            return result;
        }

        [HttpPost]
        public IActionResult Create(RecordCreateViewModel recordCreateViewModel)
        {
            string clientId;
            if(Request.Cookies.TryGetValue("clientId", out clientId))
            {
                recordCreateViewModel.ClientId = int.Parse(clientId);
            }

            var json = JsonConvert.SerializeObject(recordCreateViewModel);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            var result = _client.PostAsync("api/records", data).Result;

            if(result.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return Redirect("/site/vertical/index.html");
            }

            return Redirect("/site/vertical/create-record.html");
        }
        public IActionResult Delete(int id)
        {
            var result = _client.DeleteAsync("api/records/" + id);
            return Redirect("/site/vertical/index.html");
        }
    }
}