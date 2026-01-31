using Microsoft.AspNetCore.Mvc;
using ResumeProjectDemoNight.Context;
using ResumeProjectDemoNight.Entities;
using System.IO;

namespace ResumeProjectDemoNight.Controllers
{
    public class FeatureController : Controller
    {
        private readonly ResumeContext _context;

        public FeatureController(ResumeContext context)
        {
            _context = context;
        }

        public IActionResult FeatureList()
        {
            var values = _context.Features.ToList();
            return View(values);
        }
        [HttpGet]
        public IActionResult EditFeature(int id)
        {
            var values = _context.Features.Find(id);
            return View(values);
        }
        [HttpPost]
        public IActionResult EditFeature(Feature feature, IFormFile picture)
        {
            
            if (picture != null)
            {     
                var resource = Directory.GetCurrentDirectory();
                var extension = Path.GetExtension(picture.FileName);              
                var imageName = Guid.NewGuid() + extension;      
                var saveLocation = resource + "/wwwroot/images/" + imageName;

                
                using (var stream = new FileStream(saveLocation, FileMode.Create))
                {
                    picture.CopyTo(stream);
                }

               
                feature.ImageUrl = "/images/" + imageName;
            }

            

            _context.Features.Update(feature);
            _context.SaveChanges();
            return RedirectToAction("FeatureList");
        }
    }
}
