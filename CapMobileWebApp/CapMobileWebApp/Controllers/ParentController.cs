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
    public class ParentController : Controller
    {
        protected readonly UserService _userService;
        protected UserInfo userInfo { get; set; }
        public ParentController(UserService userService)
        {
            _userService = userService;
        }
        public ParentController()
        {
        }
    }
}
