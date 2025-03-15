using ET_Movies.Data;
using ET_Movies.Models;
using Microsoft.AspNetCore.Mvc;

namespace ET_Movies.Areas.Admin.Controllars
{
    [Area("Admin")]
    public class ActorsController : Controller
    {
        ApplicationDbcontext dbcontext = new ApplicationDbcontext();
        public IActionResult Index()
        {
            return View(dbcontext.Actors);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Actors actors,IFormFile file)
        {
            if (ModelState.IsValid)
            {
                if (file != null && file.Length > 0)
                {

                    var fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                    var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\Images\\cast",fileName);

                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }


                    actors.ProfilePicture =  fileName;
                }


                dbcontext.Add(actors);
                dbcontext.SaveChanges();
                return RedirectToAction(nameof(Index));
            }

            return View("Create");
        }

    }
}
