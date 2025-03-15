using ET_Movies.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ET_Movies.Areas.Customer.Controllars
{
    [Area("Customer")]
    public class CinemaController : Controller
    {
        public ApplicationDbcontext Dbcontext = new ApplicationDbcontext();

        public IActionResult Index()
        {
            var item = Dbcontext.Cinemas;
            return View(item);
        }
        public IActionResult Cinemas(int CinemasId)
        {
            var item = Dbcontext.Movies.Include(e => e.Cinema).Include(e => e.Category).Where(e => e.CinemaId == CinemasId);
            return View(item);
            
        }
    }
}
