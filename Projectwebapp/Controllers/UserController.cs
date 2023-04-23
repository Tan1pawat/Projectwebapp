using Microsoft.AspNetCore.Mvc;
using Projectwebapp.Data;
using Projectwebapp.Models;

namespace Projectwebapp.Controllers
{
    public class UserController : Controller
    {
        private readonly ApplicationDBcontext _db;
        public UserController(ApplicationDBcontext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Login()
        {
            return View();
        }
        public IActionResult Regis()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(User obj) { 
            _db.User.Add(obj);
            _db.SaveChanges();
            return RedirectToAction("Login");
        }
    }
}
