
using ET_Movies.Data;
using ET_Movies.Models;
using movie_ticket.Repositories.IRepositories;

namespace movie_ticket.Repositories
{
    public class ActorsRepository : Repository<Actors> , IActorsRepository
    {

        private readonly ApplicationDbcontext dbContext;

        public ActorsRepository(ApplicationDbcontext dbContext) : base(dbContext)
        {
            this.dbContext = dbContext;
        }

    }
}
