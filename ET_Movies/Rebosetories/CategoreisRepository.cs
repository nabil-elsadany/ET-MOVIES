


using ET_Movies.Data;
using ET_Movies.Models;
using movie_ticket.Repositories.IRepositories;

namespace movie_ticket.Repositories
{
    public class CategoreisRepository : Repository<Categories> , ICategoreisRepository
    {

        private readonly ApplicationDbcontext dbContext;
        public CategoreisRepository(ApplicationDbcontext dbContext):base( dbContext)
        {
            this.dbContext = dbContext; 
        }

    }
}
