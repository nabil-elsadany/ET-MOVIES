
using ET_Movies.Data;
using ET_Movies.Models;


using movie_ticket.Repositories.IRepositories;

namespace movie_ticket.Repositories
{
    public class CinemasRepository : Repository<Cinemas> , ICinemasRepository
    {

        private readonly ApplicationDbcontext dbContext;

        public CinemasRepository(ApplicationDbcontext dbContext): base( dbContext)
        {
            this.dbContext = dbContext;   
        }

    }
}
