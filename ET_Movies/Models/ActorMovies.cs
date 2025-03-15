namespace ET_Movies.Models
{
    public class ActorMovies
    {
        public int ActorsId { get; set; }
        public int MoviesId { get; set; }

        public Actors Actor { get; set; } 
        public Movies Movie { get; set; } 
    }
}
