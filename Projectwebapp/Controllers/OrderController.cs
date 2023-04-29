using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Projectwebapp.Data;
using Projectwebapp.Models;

namespace Projectwebapp.Controllers
{
    public class OrderController : Controller
    {
        private readonly ProductDBcontext _db;

        public OrderController(ProductDBcontext db)
        {
            _db = db;
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Menu1(Sender obj)
        {
            _db.Sender.Add(obj);
            _db.SaveChanges();
            return RedirectToAction("Thankyou");
        }
        public IActionResult Waiting()
        {
            return View();
        }
        public IActionResult Thankyou()
        {
            return View();
        }
        public IActionResult Stores()
        {
            return View();
        }
        public IActionResult Menu1()
        {
            return View();
        }
        public IActionResult Menu2()
        {
            return View();
        }
        public IActionResult Menu3()
        {
            return View();
        }
        public IActionResult Menu4()
        {
            return View();
        }
        public IActionResult Menu5()
        {
            return View();
        }
        public IActionResult Menu6()
        {
            return View();
        }
        public IActionResult Menu7()
        {
            return View();
        }
        public IActionResult Menu8()
        {
            return View();
        }
        public IActionResult Menu9()
        {
            return View();
        }
    }
}
