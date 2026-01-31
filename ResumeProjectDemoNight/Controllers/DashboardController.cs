using Microsoft.AspNetCore.Mvc;
using ResumeProjectDemoNight.Context;
using System; // Convert işlemleri için gerekli
using System.Linq;

namespace ResumeProjectDemoNight.Controllers
{
    public class DashboardController : Controller
    {
        private readonly ResumeContext _context;

        public DashboardController(ResumeContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            
            ViewBag.ProjectCount = _context.Portfolios.Count();
            ViewBag.SkillCount = _context.Skills.Count();
            ViewBag.ServiceCount = _context.Services.Count();
            ViewBag.MessageCount = _context.Messages.Count();
            ViewBag.UnreadMessages = _context.Messages.Where(x => x.IsRead == false).Count();
            
            if (_context.Skills.Any())
            {
                ViewBag.AvgSkillValue = _context.Skills.ToList().Average(x => Convert.ToDouble(x.Value));
            }
            else
            {
                ViewBag.AvgSkillValue = 0;
            }

            // 3. Son Mesajlar ve Projeler
            var lastMessages = _context.Messages.OrderByDescending(x => x.SendDate).Take(5).ToList();
            var lastProjects = _context.Portfolios.OrderByDescending(x => x.PortfolioId).Take(4).ToList();

            ViewBag.LastProjects = lastProjects;

            return View(lastMessages);
        }
    }
}