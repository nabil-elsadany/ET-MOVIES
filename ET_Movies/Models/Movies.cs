using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace ET_Movies.Models
{
    public class Movies
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public string ImgUrl { get; set; }
        public string TrailerUrl { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public MovieStatus MovieStatus { get; set; }
        public int CinemaId { get; set; }
        public int CategoryId { get; set; }

        public Cinemas Cinema { get; set; }
        public Categories Category { get; set; }
        
        public List<ActorMovies> ActorMovies { get; set; } = new List<ActorMovies>();
        [ValidateNever]
        public List<OrderItems> OrderItems { get; set; } = new List<OrderItems>();
    }
}
