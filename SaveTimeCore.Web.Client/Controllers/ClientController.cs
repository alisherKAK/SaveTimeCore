using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SaveTimeCore.AbstractModels;
using SaveTimeCore.Domain.Resources;
using SaveTimeCore.Web.Client.Models;

namespace SaveTimeCore.Web.Client.Controllers
{
    public class ClientController : Controller
    {
        private readonly HttpClient _client;
        private readonly IEncrypter _encrypter;
        public ClientController(HttpClient client, IEncrypter encrypter)
        {
            _client = client;
            _encrypter = encrypter;
        }

        public IActionResult SignUp()
        {
            return Redirect("/site/vertical/pages-register.html");
        }
        [HttpPost]
        public IActionResult SignUp(ClientCreateViewModel clientCreateViewModel)
        {
            var account = new AccountResource()
            {
                Login = clientCreateViewModel.Login,
                Phone = clientCreateViewModel.Phone,
                Email = clientCreateViewModel.Email,
                Password = clientCreateViewModel.Password
            };
            var json = JsonConvert.SerializeObject(account);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            var result = _client.PostAsync("api/accounts", data).Result;

            if(result.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var accountsJson = _client.GetStringAsync("api/accounts").Result;
                var accounts = JsonConvert.DeserializeObject<List<AccountResource>>(accountsJson);
                var accountGet = accounts.Where(a => a.Login == clientCreateViewModel.Login && a.Phone == clientCreateViewModel.Phone && a.Email == clientCreateViewModel.Email).FirstOrDefault();

                var client = new ClientResource()
                {
                    AccountId = accountGet.Id,
                    Name = clientCreateViewModel.Name
                };
                var clientJson = JsonConvert.SerializeObject(client);
                var clientData = new StringContent(clientJson, Encoding.UTF8, "application/json");
                var clientResult = _client.PostAsync("api/clients", clientData).Result;

                if(clientResult.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    return Redirect("/site/vertical/pages-login.html");
                }
            }

            return Redirect("/site/vertical/pages-register.html");
        }
        public IActionResult SignIn()
        {
            return Redirect("/site/vertical/pages-login.html");
        }
        [HttpPost]
        public IActionResult SignIn(ClientEnterViewModel clientEnterViewModel)
        {
            var result = _client.GetStringAsync("api/accounts").Result;
            var accounts = JsonConvert.DeserializeObject<List<AccountResource>>(result);
            var account = accounts.Where(a => a.Login == clientEnterViewModel.Login).FirstOrDefault();

            if(_encrypter.ValidatePassword(clientEnterViewModel.Password, account.Password))
            {
                return Redirect("/site/vertical/index.html");
            }

            return Redirect("/site/vertical/pages-login.html");
        }
    }
}