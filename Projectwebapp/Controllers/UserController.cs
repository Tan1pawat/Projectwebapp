using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Projectwebapp.Data;
using Projectwebapp.Models;


namespace Projectwebapp.Controllers
{
    public class UserController : Controller
    {
        private readonly ApplicationDBcontext _db;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public UserController(ApplicationDBcontext db, IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
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
        public IActionResult Profile() 
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Regis(User obj) { 
            if (ModelState.IsValid)
            {
                _db.Users.Add(obj);
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
            var login = await _db.Users.FirstOrDefaultAsync(u => u.Secid == loginUser.Secid && u.Pass == loginUser.Pass);
            HttpContext.Session.SetString("UserId", login.Secid.ToString());
            if (login != null)
            {

                return RedirectToAction("Home");
            }
            else
            {
                ModelState.AddModelError("","Student ID หรือ Password ไม่ถูกต้อง");
            }
            
            return View(loginUser);
        }


    }
}
