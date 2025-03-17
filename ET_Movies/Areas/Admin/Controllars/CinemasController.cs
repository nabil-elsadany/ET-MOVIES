using ET_Movies.Data;
using ET_Movies.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ET_Movies.Areas.Admin.Controllars
{
    [Area("Admin")]
    public class CinemasController : Controller
    {
        ApplicationDbcontext dbcontext = new ApplicationDbcontext();
        public IActionResult Index()
        {
            return View(dbcontext.Cinemas);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Cinemas cinemas, IFormFile file)
        {
            
            
                if (file != null && file.Length > 0)
                {

                    var fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                    var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\Images", fileName);

                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }


                    cinemas.CinemaLogo = fileName;
                


                dbcontext.Add(cinemas);
                dbcontext.SaveChanges();
                return RedirectToAction(nameof(Index));
                }

            return View("Create");
        }
        [HttpGet]
        public IActionResult Edit(int Id)
        {
            var item = dbcontext.Cinemas.FirstOrDefault(e => e.Id == Id);
            return View(item);
        }



        [HttpPost]
        public IActionResult Edit(Cinemas cinemas, IFormFile file)
        {
            var oldfile = dbcontext.Cinemas.AsNoTracking().FirstOrDefault(e => e.Id == cinemas.Id);
            if (oldfile != null && file != null && file.Length > 0)
            {
                // Save img in wwwroot
                var fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\Images", fileName);

                using (var stream = System.IO.File.Create(filePath))
                {
                    file.CopyTo(stream);
                }
                if (oldfile.CinemaLogo != null)
                {
                    var oldPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\Images", oldfile.CinemaLogo);
                    if (System.IO.File.Exists(oldPath))
                    {
                        System.IO.File.Delete(oldPath);
                    }
                }




                // Save img name in db
                cinemas.CinemaLogo = fileName;
            }
            else
            {
                cinemas.CinemaLogo = oldfile.CinemaLogo;
            }

            dbcontext.Cinemas.Update(cinemas);
            dbcontext.SaveChanges();
            return RedirectToAction("Index");
        }


        public IActionResult Delete(int Id)
        {
            var DelFile = dbcontext.Cinemas.FirstOrDefault(e => e.Id == Id);
            if (DelFile.CinemaLogo == null)
            {
                dbcontext.Cinemas.Remove(DelFile);
                dbcontext.SaveChanges();
                return RedirectToAction(nameof(Index));

            }
            else
            {
                var oldPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\Images", DelFile.CinemaLogo);
                if (System.IO.File.Exists(oldPath))
                {
                    System.IO.File.Delete(oldPath);
                }

                dbcontext.Cinemas.Remove(DelFile);
                dbcontext.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(nameof(Index));
        }
    }
}
