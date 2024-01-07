using Microsoft.AspNetCore.Mvc;
using StudentLogin.Models;
using System.Diagnostics;

namespace StudentLogin.Controllers
{
    public class HomeController : Controller
    {
        private readonly MyDBContext context;

        public HomeController(MyDBContext context)
        {
            this.context = context;
        }

        public IActionResult Index()
        {
            return View();
        }


        public IActionResult Login()
        {
            if (HttpContext.Session.GetString("UserSession") != null)
            {
                return RedirectToAction("Profile");
            }
            return View();
        }

        [HttpPost]
        public IActionResult Login(Std user)
        {
            var myUser = context.Stds.Where(x => x.Email == user.Email && x.Password == user.Password).FirstOrDefault();
            if (myUser != null)
            {
                HttpContext.Session.SetString("UserSession",myUser.Email);
                return RedirectToAction("Profile");
            }
            else
            {
                ViewBag.Message = "Login Failed..";
            }
            return View();
        }

        public IActionResult Profile()
        {
            if (HttpContext.Session.GetString("UserSession") != null)
            {
                ViewBag.MySession = HttpContext.Session.GetString("UserSession").ToString();
            }
            else
            {
                return RedirectToAction("Login");
            }
            return View();
        }

        public IActionResult Logout()
        {
            if (HttpContext.Session.GetString("UserSession") != null)
            {
                HttpContext.Session.Remove("UserSession");
                return RedirectToAction("Login");
            }
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(Std user)
        {
            if (ModelState.IsValid)
            {
                await context.Stds.AddAsync(user);
                await context.SaveChangesAsync();
                TempData["Succees"] = "Registered Successfully";
                return RedirectToAction("Login");
            }
            return View();
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
