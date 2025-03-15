
using ET_Movies.Data;
using ET_Movies.Models;
using movie_ticket.Repositories.IRepositories;

namespace movie_ticket.Repositories
{
    public class OrderItemsRepository : Repository<OrderItems> , IOrderItemsRepository
    {

        private readonly ApplicationDbcontext dbContext;

        public OrderItemsRepository(ApplicationDbcontext dbContext):base(dbContext)
        {
            this.dbContext = dbContext;
        }

    }
}
