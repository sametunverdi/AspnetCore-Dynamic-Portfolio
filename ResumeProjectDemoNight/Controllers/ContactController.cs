using Microsoft.AspNetCore.Mvc;
using ResumeProjectDemoNight.Context;

namespace ResumeProjectDemoNight.Controllers
{
    public class ContactController : Controller
    {
        private readonly ResumeContext _context;

        public ContactController(ResumeContext context)
        {
            _context = context;
        }

        public IActionResult ContactList()
        {
            var values= _context.Contacts.ToList();
            return View(values);
        }
        [HttpGet]
        public IActionResult MessageDetails(int id)
        {
            var value = _context.Contacts.Find(id);
            return View(value);
        }
        public IActionResult DeleteContact(int id)
        {
            var values = _context.Contacts.Find(id);
            _context.Contacts.Remove(values);
            _context.SaveChanges();
            return RedirectToAction("ContactList");
        }

    }
}
