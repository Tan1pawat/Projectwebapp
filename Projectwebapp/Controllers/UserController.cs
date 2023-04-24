using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Projectwebapp.Data;
using Projectwebapp.Models;
using Microsoft.AspNetCore.Session;
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
        public IActionResult Regis()
        {
            return View();
        }
        public IActionResult Home()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Regis(User obj) { 
            if (ModelState.IsValid)
            {
                _db.User.Add(obj);
                _db.SaveChanges();
                HttpContext.Session.SetString("UserId", obj.Id.ToString());
                return RedirectToAction("Index");
            }
            return View(obj);

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index([Bind("Secid, Pass")] User loginUser)
        {
            var login = await _db.User.FirstOrDefaultAsync(u => u.Secid == loginUser.Secid && u.Pass == loginUser.Pass);

            if (login != null)
            {
                // set the user as logged in using session or cookie
                // for example:
                HttpContext.Session.SetString("UserId", login.Id.ToString());
                return RedirectToAction("Home");
            }
            else
            {
                ModelState.AddModelError("", "Student ID หรือ Password ไม่ถูกต้อง\n\n(กรุณากรอกข้อมูลใหม่)");
            }
            return View(loginUser);
        }


    }
}
