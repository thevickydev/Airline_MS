using Microsoft.AspNetCore.Mvc;
using ARS.Models;
using System.Linq;
using Microsoft.AspNetCore.Http;

namespace ARS.Controllers
{
    public class AdminController : Controller
    {
        private readonly ContextCS c;

        public AdminController(ContextCS context)
        {
            c = context;
        }

       

        // Load Login Page
        public IActionResult AdminLogin()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AdminLogin(AdminPanel model)
        {
            if (ModelState.IsValid)
            {
                var admin = c.AdminPanels.FirstOrDefault(a => a.AdName == model.AdName && a.Password == model.Password);

                if (admin != null)
                {
                    HttpContext.Session.SetString("AdminUser", admin.AdName);
                    return RedirectToAction("Dashboard");
                }
                else
                {
                    ViewBag.m = "Wrong Username or Password";
                }
            }
            return View(model);
        }

        // Admin Dashboard
        public ActionResult Dashboard()
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("AdminUser")))
            {
                return RedirectToAction("AdminLogin");
            }
            return View();
        }

        // Logout
        public ActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("AdminLogin");
        }
    }
}
