using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ET_Movies.Models;
using ET_Movies.Data;
using Microsoft.EntityFrameworkCore;
using movie_ticket.Repositories;
using movie_ticket.Repositories.IRepositories;

namespace ET_Movies.Areas.Customer.Controllars;
[Area("Customer")]
public class HomeController : Controller
{

    public ApplicationDbcontext Dbcontext = new ApplicationDbcontext();
    private IMoviesRepository MoviesRepository;
    private IActorsRepository ActorsRepository;
    private IActorMoviesRepository ActorMoviesRepository;

    public HomeController(IMoviesRepository MoviesRepository, IActorsRepository actorsRepository, IActorMoviesRepository ActorMoviesRepository)
    {
        this.MoviesRepository = MoviesRepository;
       this. ActorsRepository = actorsRepository;
       this.ActorMoviesRepository = ActorMoviesRepository;
    }

    
    public IActionResult Index()
    {
      // var item= MoviesRepository.Get(includes:[e => e.Cinema, e => e.Category]);
       var item= Dbcontext.Movies.Include(e => e.Cinema).Include(e => e.Category);
       
        return View(item.ToList());
    }
     public IActionResult Details(int MovieId)
    {
      // var item = MoviesRepository.GetOne(filter: e =>e.Id== MovieId,includes: [e => e.Cinema, e => e.Category,e=>e.ActorMovies.Select(e=>e.Actor)]);
      var item= Dbcontext.Movies.Include(e => e.Cinema).Include(e => e.Category).Include(e=>e.ActorMovies).ThenInclude(e=>e.Actor).FirstOrDefault(e=>e.Id== MovieId);
        return View(item);
    }
    public IActionResult Actor(int ActorId)
    {
       var item= ActorsRepository.GetOne( filter:e=>e.Id== ActorId,includes:[e=>e.ActorMovies.Select(e=>e.Movie)]);
       //var item= Dbcontext.Actors.Include(e=>e.ActorMovies).ThenInclude(e=>e.Movie).FirstOrDefault(e=>e.Id== ActorId);
        var releted = ActorMoviesRepository.Get( includes: [e => e.Actor,e => e.Movie],filter: e => e.Actor.Id == ActorId).ToList();
        //var releted = Dbcontext.ActorMovies.Include(e => e.Actor).Include(e => e.Movie).Where(e => e.Actor.Id == ActorId );
        ViewBag.releted = releted;
        return View(item);
    }

  
    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
