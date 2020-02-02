using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SaveTimeCore.AbstractModels;
using SaveTimeCore.Web.Admin.Models;

namespace SaveTimeCore.Web.Admin.Controllers
{
    public class AccountController : Controller
    {
        private readonly HttpClient _client;
        private readonly IEncrypter _encrypter;
        public AccountController(HttpClient client, IEncrypter encrypter)
        {
            _client = client;
            _encrypter = encrypter;
        }
        
        public string GetAll()
        {
            var result = _client.GetStringAsync("api/accounts").Result;

            return result;
        }
        public IActionResult SignIn()
        {
            return Redirect("/site/vertical/pages-login.html");
        }
        [HttpPost]
        public IActionResult SignIn(AccountSignInViewModel accountSignInViewModel)
        {
            var result = _client.GetStringAsync("api/accounts").Result;
            var accounts = JsonConvert.DeserializeObject<List<AccountSignInViewModel>>(result);
            var account = accounts.FirstOrDefault(a => a.Login == accountSignInViewModel.Login);

            if(account == null)
            {
                return Redirect("/site/vertical/pages-login.html");
            }
            
            if(_encrypter.ValidatePassword(accountSignInViewModel.Password, account.Password))
            {
                return Redirect("/site/vertical/table-company.html");
            }

            return Redirect("/site/vertical/pages-login.html");
        }
        public IActionResult SignUp()
        {
            return Redirect("/site/vertical/pages-register.html");
        }
        [HttpPost]
        public IActionResult SignUp(AccountSignUpViewModel accountSignUpViewModel)
        {
            if(!ModelState.IsValid)
            {
                return Redirect("/site/vertical/pages-register.html");
            }

            var json = JsonConvert.SerializeObject(accountSignUpViewModel);
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            var result = _client.PostAsync("api/accounts", data).Result;

            if(result.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return Redirect("/site/vertical/pages-login.html");
            }

            return Redirect("/site/vertical/pages-register.html");
        }
    }
}