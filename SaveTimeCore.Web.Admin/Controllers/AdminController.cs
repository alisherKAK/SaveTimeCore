using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SaveTimeCore.Web.Admin.Models;

namespace SaveTimeCore.Web.Admin.Controllers
{
    public class AdminController : Controller
    {
        private readonly HttpClient _client;
        public AdminController(HttpClient client)
        {
            _client = client;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult SignUp()
        {
            return View();
        }
        [HttpPost]
        public IActionResult SignUp(AccountCreateViewModel accountCreateViewModel)
        {
            var accountJson = JsonConvert.SerializeObject(accountCreateViewModel);
            var content = new StringContent(accountJson, Encoding.UTF8, "application/json");
            var result = _client.PostAsync("api/accounts", content).Result;

            return RedirectToAction("SignUp");
        }
    }
}