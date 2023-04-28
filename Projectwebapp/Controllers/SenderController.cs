using Microsoft.AspNetCore.Mvc;
using Projectwebapp.Models;
namespace foodde.Controllers
{
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
        public IActionResult Getorder()
        {
            return View();
        }

        public IActionResult Confirm()
        {
            return View();
        }
    }
}