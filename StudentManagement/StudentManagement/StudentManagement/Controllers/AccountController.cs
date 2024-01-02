using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using StudentManagement.Models;
using StudentManagement.ViewModel;

namespace StudentManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController(SignInManager<AppUser> signInManager, UserManager<AppUser> userManager)
        : ControllerBase
    {
        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginVm loginVm)
        {
            if (ModelState.IsValid)
            {
                var result = await signInManager.PasswordSignInAsync(loginVm.UserName!, loginVm.Password!, loginVm.RememberMe, false);
                if (result.Succeeded)
                {
                    return Ok(new { message = "Login successful" });
                }
                return Unauthorized(new { message = "Invalid login attempt." });
            }
            return BadRequest(ModelState);
        }

        [HttpPost("register")]
        [AllowAnonymous]
        public async Task<IActionResult> Register(RegistrarVm registrar)
        {
            if (ModelState.IsValid)
            {
                AppUser appUser = new()
                {
                    UserName = registrar.Email,
                    Name = registrar.Name,
                    Email = registrar.Email,
                    Address = registrar.Address
                };

                var result = await userManager.CreateAsync(appUser, registrar.Password!);
                if (result.Succeeded)
                {
                    await signInManager.SignInAsync(appUser, false);
                    return Ok(new { message = "Registration successful" });
                }

                return BadRequest(new { errors = result.Errors });
            }

            return BadRequest(ModelState);
        }

        [HttpPost("logout")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return Ok(new { message = "Logout successful" });
        }
    }
}

