using CapMobileWebApp.DAL.Model;
using CapMobileWebApp.Models;
using CapMobileWebApp.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace CapMobileWebApp.Controllers
{
    public class AccountController : Controller
    {
        private readonly ILogger<AccountController> _logger;
        private readonly UserService _userService;
        public string ReturnUrl { get; set; }
        public AccountController(
            ILogger<AccountController> logger,
            UserService userService)
        {
            _logger = logger;
            _userService = userService;
        }
        [HttpGet]
        public IActionResult Login()
         {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            else
            {
                // This doesn't count login failures towards account lockout
                // To enable password failures to trigger account lockout, set lockoutOnFailure: true
                var user = _userService.GetUserInfo(model.Email, model.Password);
                //var user = await _userManager.FindByNameAsync(model.Email) ?? await _userManager.FindByEmailAsync(model.Email);
                if (user != null)
                {
                    //var result = await _signInManager.PasswordSignInAsync(user, model.Password, true, false);
                    //if (result.Succeeded)
                    //{
                        if (user.RoleId == 3 || user.RoleId == 6 || user.RoleId == 9)
                        {
                            var claims = new List<Claim> {
                                        new Claim(ClaimTypes.Name, user.Username),
                                        new Claim("FullName", user.EmployeeName),
                                        new Claim("UserId", user.UserId.ToString()),
                                        new Claim(ClaimTypes.Role, user.RoleId.ToString()),
                                        new Claim("Designation", user.Designation.ToString()),
                                    };

                            var claimsIdentity = new ClaimsIdentity(
                                claims, CookieAuthenticationDefaults.AuthenticationScheme);

                            var authProperties = new AuthenticationProperties
                            {
                                //AllowRefresh = <bool>,
                                // Refreshing the authentication session should be allowed.

                                //ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(10),
                                // The time at which the authentication ticket expires. A 
                                // value set here overrides the ExpireTimeSpan option of 
                                // CookieAuthenticationOptions set with AddCookie.

                                //IsPersistent = true,
                                // Whether the authentication session is persisted across 
                                // multiple requests. When used with cookies, controls
                                // whether the cookie's lifetime is absolute (matching the
                                // lifetime of the authentication ticket) or session-based.

                                //IssuedUtc = <DateTimeOffset>,
                                // The time at which the authentication ticket was issued.

                                //RedirectUri = <string>
                                // The full path or absolute URI to be used as an http 
                                // redirect response value.
                            };

                            await HttpContext.SignInAsync(
                                CookieAuthenticationDefaults.AuthenticationScheme,
                                new ClaimsPrincipal(claimsIdentity),
                                authProperties);
                            return Redirect("/home/index");
                        }

                    //}
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Username or email invalid.");
                    return View(model);
                }
            }
            ModelState.AddModelError(string.Empty, "Invalid login attempt.");
            return View();


        }
        public async Task<IActionResult> Logout(string returnUrl = null)
        {
            
            await HttpContext.SignOutAsync(
                CookieAuthenticationDefaults.AuthenticationScheme);
            _logger.LogInformation("User logged out.");
            if (returnUrl != null)
            {
                return LocalRedirect(returnUrl);
            }
            else
            {
                return RedirectToAction("login");
            }
        }
    }
}
