using ET_Movies.Data;
using ET_Movies.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
        public IActionResult Create(Actors actors, IFormFile? file)
        {
            
            
                if (file != null && file.Length > 0)
                {

                    var fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                    var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\Images\\cast", fileName);

                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }


                    actors.ProfilePicture = fileName;
                }


                dbcontext.Add(actors);
                dbcontext.SaveChanges();
                return RedirectToAction(nameof(Index));
            

            return View("Create");
        }
        [HttpGet]
        public IActionResult Edit(int Id)
        {
            var item = dbcontext.Actors.FirstOrDefault(e => e.Id == Id);
            return View(item);
        }
        [HttpPost]
        public IActionResult Edit(Actors actors,IFormFile? file)
        {
            var oldfile = dbcontext.Actors.AsNoTracking().FirstOrDefault(e => e.Id == actors.Id);
            if (oldfile != null && file != null && file.Length > 0)
            {
                // Save img in wwwroot
                var fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\Images\\cast", fileName);

                using (var stream = System.IO.File.Create(filePath))
                {
                    file.CopyTo(stream);
                }
                if (oldfile.ProfilePicture != null)
                {
                    var oldPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\Images\\cast", oldfile.ProfilePicture);
                    if (System.IO.File.Exists(oldPath))
                    {
                        System.IO.File.Delete(oldPath);
                    }
                }




                // Save img name in db
                actors.ProfilePicture = fileName;
            }
            else
            {
                actors.ProfilePicture = oldfile.ProfilePicture;
            }

            dbcontext.Actors.Update(actors);
            dbcontext.SaveChanges();
            return RedirectToAction("Index");
        }

       
        public IActionResult Delete(int Id)
        {
            var DelFile = dbcontext.Actors.FirstOrDefault(e => e.Id == Id);
            if (DelFile.ProfilePicture == null)
            {
                dbcontext.Actors.Remove(DelFile);
                dbcontext.SaveChanges();
                return RedirectToAction(nameof(Index));

            }
            else
            {
                var oldPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\Images\\cast", DelFile.ProfilePicture);
                if (System.IO.File.Exists(oldPath))
                {
                    System.IO.File.Delete(oldPath);
                }

                dbcontext.Actors.Remove(DelFile);
                dbcontext.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(nameof(Index));
        }




    } 
}
