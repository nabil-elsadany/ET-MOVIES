using ET_Movies.Data;
using ET_Movies.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ET_Movies.Areas.Admin.Controllars
{
    [Area("Admin")]
    public class CategoriesController : Controller
    {
        ApplicationDbcontext dbcontext = new ApplicationDbcontext();
        public IActionResult Index()
        {
            return View(dbcontext.Categories);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Categories categories)
        {
            if (ModelState.IsValid)
            {
               

                dbcontext.Categories.Add(categories);
                dbcontext.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(nameof(Create));
        }
        [HttpGet]
        public IActionResult Edit(int Id)
        {
            var item = dbcontext.Categories.FirstOrDefault(e => e.Id == Id);
            return View(item);
        }
        [HttpPost]
        public IActionResult Edit(Categories categories)
        {
            var oldfile = dbcontext.Categories.AsNoTracking().FirstOrDefault(e => e.Id == categories.Id);
          

            dbcontext.Categories.Update(categories);
            dbcontext.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int Id)
        {
            var categories = dbcontext.Categories.FirstOrDefault(e => e.Id == Id);
           
                dbcontext.Categories.Remove(categories);
                dbcontext.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
