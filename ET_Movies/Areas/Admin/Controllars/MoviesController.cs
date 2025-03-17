using ET_Movies.Data;
using ET_Movies.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using movie_ticket.Repositories;
using movie_ticket.Repositories.IRepositories;

namespace ET_Movies.Areas.Admin.Controllars
{
    [Area("Admin")]
    public class MoviesController : Controller
    {
        ApplicationDbcontext dbcontext = new ApplicationDbcontext();
        private readonly IMoviesRepository moviesRepository;
        

        public MoviesController(IMoviesRepository moviesRepository)
        {
            this.moviesRepository = moviesRepository;
            
        }

        public IActionResult Index()
        {

            var item = moviesRepository.Get( includes : [e => e.Cinema,e => e.Category]);
           // var item = dbcontext.Movies.Include(e => e.Cinema).Include(e => e.Category);
            return View(item.ToList());
        }
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Cinemas = new SelectList(dbcontext.Cinemas, "Id", "Name");
            ViewBag.Categories= new SelectList(dbcontext.Categories, "Id", "Name");
            ViewBag.Actors = new SelectList(dbcontext.Actors, "Id", "FirstName");
            ViewBag.MovieStatus = new SelectList(Enum.GetValues(typeof(MovieStatus)));
            
            return View();
        }
        [HttpPost]
        public IActionResult Create(Movies movies, IFormFile? file)
        {


            if (file != null && file.Length > 0)
            {

                var fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\Images\\movies", fileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    file.CopyTo(stream);
                }


                movies.ImgUrl = fileName;
            }


            dbcontext.Add(movies);
            dbcontext.SaveChanges();
            return RedirectToAction(nameof(Index));


            
        }
        [HttpGet]
        public IActionResult Edit(int Id)
        {
            var item = moviesRepository.GetOne( e => e.Id == Id);
           
            ViewBag.Cinemas = new SelectList(dbcontext.Cinemas, "Id", "Name");
            ViewBag.Categories = new SelectList(dbcontext.Categories, "Id", "Name");
            ViewBag.MovieStatus = new SelectList(Enum.GetValues(typeof(MovieStatus)));
            return View(item);
        }
        [HttpPost]
        public IActionResult Edit(Movies movies, IFormFile? file)
        {
            var oldfile = dbcontext.Movies.AsNoTracking().FirstOrDefault(e => e.Id == movies.Id);
            if (oldfile != null && file != null && file.Length > 0)
            {
                // Save img in wwwroot
                var fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\Images\\movies", fileName);

                using (var stream = System.IO.File.Create(filePath))
                {
                    file.CopyTo(stream);
                }
                if (oldfile.ImgUrl != null)
                {
                    var oldPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\Images\\movies", oldfile.ImgUrl);
                    if (System.IO.File.Exists(oldPath))
                    {
                        System.IO.File.Delete(oldPath);
                    }
                }

                // Save img name in db
                movies.ImgUrl = fileName;
            }
            else
            {
                movies.ImgUrl = oldfile.ImgUrl;
            }

            moviesRepository.Edit(movies);
            moviesRepository.Commit();
            return RedirectToAction("Index");
        }


        public IActionResult Delete(int Id)
        {
            var DelFile = moviesRepository.GetOne(e => e.Id == Id);
           // var DelFile = dbcontext.Movies.FirstOrDefault(e => e.Id == Id);
            if (DelFile.ImgUrl == null)
            {
                moviesRepository.Delete(DelFile);
                moviesRepository.Commit();
                return RedirectToAction(nameof(Index));

            }
            else
            {
                var oldPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\Images\\movies", DelFile.ImgUrl);
                if (System.IO.File.Exists(oldPath))
                {
                    System.IO.File.Delete(oldPath);
                }

                moviesRepository.Delete(DelFile);
                moviesRepository.Commit();
                return RedirectToAction(nameof(Index));
            }
            return View(nameof(Index));
        }




    }
}

