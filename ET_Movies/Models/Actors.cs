using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace ET_Movies.Models
{
    public class Actors
    {
        public int Id { get; set; }
        public string FirstName { get; set; } 
        public string LastName { get; set; } 
        public string Bio { get; set; } 
        public string ProfilePicture { get; set; } 
        public string News { get; set; }
        [ValidateNever]
        public List<ActorMovies> ActorMovies { get; set; } = new List<ActorMovies>();
    }
}
