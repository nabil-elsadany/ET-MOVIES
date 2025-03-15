using ET_Movies.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ET_Movies.Areas.Customer.Controllars
    
{
    [Area("Customer")]
    public class CategoryController : Controller
    {
        public ApplicationDbcontext Dbcontext = new ApplicationDbcontext();

        public IActionResult Index()
        {
             var item = Dbcontext.Categories;
            return View(item);
        }
        public IActionResult Movies(int CategoryId)
        {
            var item = Dbcontext.Movies.Include(e => e.Cinema).Include(e => e.Category).Where(e=>e.CategoryId== CategoryId);
            return View(item);
            
        }
    }
}
