using Microsoft.AspNetCore.Mvc;
using ResumeProjectDemoNight.Context;

namespace ResumeProjectDemoNight.ViewComponents.DefaultViewComponents
{
    public class _DefaultExperienceComponentPartial : ViewComponent
    {
        private readonly ResumeContext _context;

        public _DefaultExperienceComponentPartial(ResumeContext context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke()
        {
            var experiences = _context.Experiences.ToList();
            var educations = _context.Educations.ToList();
            ViewBag.educationList = educations;
            return View(experiences);
        }
    }
}
