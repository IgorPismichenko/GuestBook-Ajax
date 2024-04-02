using GuestBook_Ajax.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace GuestBook_Ajax.Controllers
{
    public class HomeController : Controller
    {
        private readonly GBContext _context;
        public HomeController(GBContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Comment(Messages messages)
        {
            if (ModelState.IsValid)
            {
                messages.UserId = (int)HttpContext.Session.GetInt32("Id");
                messages.Date = DateTime.Now.ToString();
                _context.Add(messages);
                await _context.SaveChangesAsync();
                string response = "Comment was added succesfully";
                return Json(response);
            }
            return Problem("Issue during adding your comment!");
        }
        [HttpGet]
        public async Task<IActionResult> GetMessages()
        {
            if (_context.Messages == null)
                return Problem("Message list is empty!");
            List<Messages> list = await _context.Messages.Include(p => p.User).ToListAsync();
            string response = JsonConvert.SerializeObject(list);
            return Json(response);
        }
        public ActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
        }
    }
}
