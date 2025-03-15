
using ET_Movies.Data;
using ET_Movies.Models;
using Microsoft.EntityFrameworkCore;

using movie_ticket.Repositories.IRepositories;
using System.Linq.Expressions;

namespace movie_ticket.Repositories
{
    public class MoviesRepository : Repository<Movies>, IMoviesRepository
    {
        private readonly ApplicationDbcontext dbContext;

        public MoviesRepository(ApplicationDbcontext dbContext) : base(dbContext)
        {
            this.dbContext = dbContext;
        }

       

    }
}
    

