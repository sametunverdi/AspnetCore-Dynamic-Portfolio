using Microsoft.AspNetCore.Mvc;
using ResumeProjectDemoNight.Context;
using ResumeProjectDemoNight.Entities;

namespace ResumeProjectDemoNight.Controllers
{
    public class DefaultController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public PartialViewResult SendMessage()
        {
            return PartialView();
        }

        [HttpPost]
        public IActionResult SendMessage(Contact p)
        {
            using (var context = new ResumeContext())
            {                
                p.Date = DateTime.Parse(DateTime.Now.ToShortDateString());         
                context.Contacts.Add(p);      
                context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}
