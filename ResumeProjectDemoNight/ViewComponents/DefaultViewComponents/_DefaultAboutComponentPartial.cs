using Microsoft.AspNetCore.Mvc;
using ResumeProjectDemoNight.Context;

namespace ResumeProjectDemoNight.ViewComponents.DefaultViewComponents
{
    public class _DefaultAboutComponentPartial : ViewComponent
    {
        private readonly ResumeContext _context;

        public _DefaultAboutComponentPartial(ResumeContext context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke()
        {
            var aboutValue = _context.Abouts.FirstOrDefault();
            var skillValue = _context.Skills.ToList();
            ViewBag.skillList = skillValue;
            ViewBag.ProjectCount = _context.Portfolios.Count();      
            ViewBag.SkillCount = _context.Skills.Count();            
            ViewBag.TestimonialCount = _context.Testimonials.Count(); 
            ViewBag.ServiceCount = _context.Services.Count();
            return View(aboutValue);
        }

    }
}
