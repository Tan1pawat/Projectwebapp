using Microsoft.AspNetCore.Mvc;
using Projectwebapp.Models;
using Microsoft.AspNetCore.Authentication;//new
using Microsoft.AspNetCore.Authorization;

namespace Projectwebapp.Controllers
{
    [Authorize]
    public class SenderController : Controller
    {
        private readonly ProductDBcontext _db;

        public SenderController(ProductDBcontext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            IEnumerable<Sender> allproduct = _db.Sender;
            return View(allproduct);
        }
        public IActionResult Getorder(int? id)
        {
            if (id == null)
            {
                return NotFound("id is null");
            }
            var obj = _db.Sender.Find(id);
            if (obj == null) { 
                return NotFound("obj is null");
            }
            return View(obj);
        }
       
        public IActionResult Confirm(int? id)
        {
            if (id == null)
            {
                return NotFound("ID cannot be null.");
            }
            var obj = _db.Sender.Find(id);
            if (obj == null)
            {
                return NotFound(id);
            }
            _db.Remove(obj);
            _db.SaveChanges();
            return View();
        }
    }
}