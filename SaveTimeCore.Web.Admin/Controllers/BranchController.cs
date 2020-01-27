using System.Net.Http;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SaveTimeCore.Web.Admin.Models;

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
        [HttpPost]
        public IActionResult Create(BranchCreateViewModel branchCreateViewModel)
        {
            var json = JsonConvert.SerializeObject(branchCreateViewModel);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            var result = _client.PostAsync("api/branches", data).Result;

            if(result.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return Redirect("/site/vertical/table-branch.html");
            }

            return Redirect("/site/vertical/create-branch.html");
        }
        public IActionResult Delete(int id)
        {
            var result = _client.DeleteAsync("api/branches/" + id).Result;

            return Redirect("/site/vertical/table-branch.html");
        }
    }
}