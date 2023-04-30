using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Projectwebapp.Data;
using Projectwebapp.Models;
using System.Security.Claims;//new
using Microsoft.AspNetCore.Authentication;//new
using Microsoft.AspNetCore.Authentication.Cookies;//new
using Microsoft.AspNetCore.Authorization;

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
        
        public async Task<IActionResult> Index()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            ClaimsPrincipal claimUser = HttpContext.User;
            if (claimUser.Identity.IsAuthenticated)
                return View();
            return View();
        }
        public IActionResult Regis()
        {
            return View();
        }
        [Authorize]
        public IActionResult Home()
        {
            return View();
        }
        public IActionResult Profile() 
        {
            return View();
        }
        public IActionResult MadeBy()
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
            
            if (login != null)
            {
                HttpContext.Session.SetString("UserId", login.Secid.ToString());
                List<Claim> claims = new List<Claim>(){
                    new Claim(ClaimTypes.NameIdentifier,loginUser.Secid),
                    new Claim("OtherProperties","Example Role")
                };
                ClaimsIdentity claimsIdentify = new ClaimsIdentity(claims,
                    CookieAuthenticationDefaults.AuthenticationScheme);

                AuthenticationProperties properties = new AuthenticationProperties()
                {
                    AllowRefresh = true
                };
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(claimsIdentify), properties);
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
