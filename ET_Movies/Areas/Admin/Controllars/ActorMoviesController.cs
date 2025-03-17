using ET_Movies.Data;
using ET_Movies.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using movie_ticket.Repositories.IRepositories;

namespace ET_Movies.Areas.Admin.Controllars
{   [Area("Admin")]
    public class ActorMoviesController : Controller
    {
       
        ApplicationDbcontext dbcontext = new ApplicationDbcontext();
        private readonly IActorMoviesRepository actorMoviesRepository;
        public ActorMoviesController(IActorMoviesRepository actorMoviesRepository)
        {
            this.actorMoviesRepository = actorMoviesRepository;
        }
        public IActionResult Index()
        {
          var item = actorMoviesRepository.Get(includes:[e=>e.Movie,e => e.Actor]);
          //var item =   dbcontext.ActorMovies.Include(e=>e.Movie).Include(e => e.Actor);
            return View(item.ToList());
        }
        [HttpGet]
        public IActionResult Create()
        {
         
            return View();
        }
        [HttpPost]
        public IActionResult Create(ActorMovies ActorMovies)
        {
           

           // var item = dbcontext.ActorMovies.Add(ActorMovies);
            return RedirectToAction("Index");
        }

    }
}
