using System.Net.Http;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SaveTimeCore.Web.Admin.Models;

namespace SaveTimeCore.Web.Admin.Controllers
{
    public class SystemAdminController : Controller
    {
        private readonly HttpClient _client;
        public SystemAdminController(HttpClient client)
        {
            _client = client;
        }

        public string GetAll()
        {
            var result = _client.GetStringAsync("api/systemAdmins").Result;
            return result;
        }
        [HttpPost]
        public IActionResult Create(SystemAdminCreateViewModel systemAdminCreateViewModel)
        {
            var json = JsonConvert.SerializeObject(systemAdminCreateViewModel);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            var result = _client.PostAsync("api/systemAdmins", data).Result;

            if (result.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return Redirect("/site/vertical/table-systemAdmin.html");
            }

            return Redirect("/site/vertical/create-systemAdmin.html");
        }
        public IActionResult Delete(int id)
        {
            var result = _client.DeleteAsync("api/systemAdmins/" + id).Result;

            return Redirect("/site/vertical/table-systemAdmin.html");
        }
    }
}