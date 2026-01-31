using Microsoft.AspNetCore.Mvc;
using ResumeProjectDemoNight.Context;
using ResumeProjectDemoNight.Entities;

namespace ResumeProjectDemoNight.Controllers
{
    public class AboutController : Controller
    {
        private readonly ResumeContext _context;

        public AboutController(ResumeContext context)
        {
            _context = context;
        }

        public IActionResult AboutList()
        {
            var values = _context.Abouts.ToList();
            return View(values);
        }
        [HttpGet]
        public IActionResult EditAbout(int id)
        {
            var values = _context.Abouts.Find(id);
            return View(values);
        }
        [HttpPost]
        public IActionResult EditAbout(About about, IFormFile picture)
        {
            
            if (picture != null)
            {
                var resource = Directory.GetCurrentDirectory();
                var extension = Path.GetExtension(picture.FileName); // .jpg, .png uzantısını al
                var imageName = Guid.NewGuid() + extension; // Rastgele isim oluştur
                var saveLocation = resource + "/wwwroot/images/" + imageName; // Kaydedilecek yer

                using (var stream = new FileStream(saveLocation, FileMode.Create))
                {
                    picture.CopyTo(stream);
                }

                
                about.ImageUrl = "/images/" + imageName;
            }

            

            _context.Abouts.Update(about);
            _context.SaveChanges();
            return RedirectToAction("AboutList");
        }
    }
}
