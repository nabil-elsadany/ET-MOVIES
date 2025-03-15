
using ET_Movies.Data;
using ET_Movies.Models;
using movie_ticket.Repositories.IRepositories;

namespace movie_ticket.Repositories
{
    public class ActorMoviesRepository : Repository<ActorMovies>, IActorMoviesRepository
    {

        private readonly ApplicationDbcontext dbContext;
        public ActorMoviesRepository(ApplicationDbcontext dbContext):base( dbContext)
        {
            this.dbContext = dbContext;
        }

    }
}
