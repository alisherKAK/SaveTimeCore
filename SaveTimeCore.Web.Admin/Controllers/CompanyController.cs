using System.Net.Http;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SaveTimeCore.Web.Admin.Models;

namespace SaveTimeCore.Web.Admin.Controllers
{
    public class CompanyController : Controller
    {
        private readonly HttpClient _client;
        public CompanyController(HttpClient client)
        {
            _client = client;
        }

        public string GetAll()
        {
            var result = _client.GetStringAsync("api/companies").Result;
            return result;
        }

        [HttpPost]
        public IActionResult Create(CompanyCreateViewModel companyCreateViewModel)
        {
            var json = JsonConvert.SerializeObject(companyCreateViewModel);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            var result = _client.PostAsync("api/companies", data).Result;

            if(result.StatusCode == System.Net.HttpStatusCode.OK)
            { 
                return Redirect("/site/vertical/table-company.html");
            }

            return Redirect("/site/vertical/create-company.html");
        }
    }
}