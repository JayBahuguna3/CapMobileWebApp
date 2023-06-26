using CapMobileWebApp.DAL.Context;
using CapMobileWebApp.Models;
using CapMobileWebApp.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CapMobileWebApp.Controllers
{
    [Authorize]
    public class HomeController : ParentController
    {
        private readonly ILogger<HomeController> _logger;

        private readonly CapRetailContext _context;
        public HomeController(ILogger<HomeController> logger, UserService userService, CapRetailContext context) : base(userService)
        {
            _context = context;
            _logger = logger;
        }

        public IActionResult Index()
        {

            this.userInfo = _userService.GetUserInfo(User);
            var cus = _context.Customer.Where(e => e.CreatedBy == userInfo.UserId).ToList();
            return View(cus);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}