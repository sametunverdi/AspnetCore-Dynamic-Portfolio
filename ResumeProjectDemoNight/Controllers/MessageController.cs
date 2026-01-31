using Microsoft.AspNetCore.Mvc;
using ResumeProjectDemoNight.Context;
using System.Linq;

namespace ResumeProjectDemoNight.Controllers
{
    public class MessageController : Controller
    {
        private readonly ResumeContext _context;

        public MessageController(ResumeContext context)
        {
            _context = context;
        }

        public IActionResult MessageList()
        {
          
            var values = _context.Messages.OrderByDescending(x => x.SendDate).ToList();
            return View(values);
        }

   
        public IActionResult Delete(int id)
        {
            var value = _context.Messages.Find(id);
            if (value != null)
            {
                _context.Messages.Remove(value);
                _context.SaveChanges(); // Veritabanına kaydetmek şart!
            }
            return RedirectToAction("MessageList");
        }

        
        [HttpGet]
        public IActionResult Details(int id)
        {
            var value = _context.Messages.Find(id);

          
            if (value != null && value.IsRead == false)
            {
                value.IsRead = true;
                _context.SaveChanges(); // Değişikliği kaydet
            }

            return View(value);
        }
    }
}