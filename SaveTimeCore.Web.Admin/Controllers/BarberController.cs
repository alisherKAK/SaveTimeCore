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
    public class BarberController : Controller
    {
        private readonly HttpClient _client;
        public BarberController(HttpClient client)
        {
            _client = client;
        }

        public string GetAll()
        {
            var result = _client.GetStringAsync("api/barbers").Result;
            return result;
        }
        [HttpPost]
        public IActionResult Create(BarberCreateViewModel barberCreateViewModel)
        {
            var json = JsonConvert.SerializeObject(barberCreateViewModel);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            var result = _client.PostAsync("api/barbers", data).Result;

            if (result.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return Redirect("/site/vertical/table-barber.html");
            }

            return Redirect("/site/vertical/create-barber.html");
        }
        public IActionResult Delete(int id)
        {
            var result = _client.DeleteAsync("api/barbers/" + id).Result;

            return Redirect("/site/vertical/table-barber.html");
        }
    }
}