using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Scripting;
using Org.BouncyCastle.Crypto.Generators;
using System.Security.Claims;
using Voting_System.Models;
using Voting_System.Service;
using Voting_System.ViewModels;


namespace Voting_System.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountService _accountService;
        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = _accountService.All().Where(x => x.UserName == model.UserName).FirstOrDefault();
                if (user != null)
                {
                    bool verified = BCrypt.Net.BCrypt.Verify(model.Password, user.Password);

                    if (verified)
                    {
                        var identity = new ClaimsIdentity(new[] {
                           
                            new Claim(ClaimTypes.Email, user.UserName),
							 new Claim(ClaimTypes.Role,user.User_type),

						}, CookieAuthenticationDefaults.AuthenticationScheme);
                        var principal = new ClaimsPrincipal(identity);
                        HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
                        HttpContext.Session.SetString("UserName", user.UserName);
                       
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        TempData["Message"] = "Invalid Password";
                        return RedirectToAction("Login", "Account");
                    }
                }
                else
                {
                    TempData["Message"] = "Sorry Uesr not found";
                    return RedirectToAction("Login", "Account");
                }
            }
            return View();
        }


        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(CreateUserViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var userNameExists = _accountService.All().Any(x => x.UserName == model.UserName);
                    if (userNameExists)
                    {
                        ModelState.AddModelError(string.Empty, model.UserName + "Alrready exists");
                    }


                    var data = new CreateUser
                    {
                        UserName = model.UserName,
                        Email = model.Email,
                        Password = BCrypt.Net.BCrypt.HashPassword(model.Password),
                        Gender = model.Gender,
                        PhoneNumber = model.PhoneNumber,
                        FirstName = model.FirstName,
                        LastName = model.LastName,
                        User_type="User"
                    };
                    await _accountService.InsertAsync(data);
					return RedirectToAction("Login", "Account");
				}
                return View();
            }
            catch
            {
                return View(model);
            }
           

        }

    }
}
