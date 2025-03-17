


using ET_Movies.Data;
using ET_Movies.Models;
using movie_ticket.Repositories.IRepositories;

namespace movie_ticket.Repositories
{
    public class CategoriesRepository : Repository<Categories> , ICategoriesRepository
    {

        private readonly ApplicationDbcontext dbContext;
        public CategoriesRepository(ApplicationDbcontext dbContext):base( dbContext)
        {
            this.dbContext = dbContext; 
        }

    }
}
