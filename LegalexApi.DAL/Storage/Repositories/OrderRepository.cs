using LegalexApi.DAL.Models.OrderAggregate;
using Microsoft.EntityFrameworkCore;


namespace LegalexApi.DAL.Storage.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly ApplicationDbContext _dbContext;


        public OrderRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Create(Order item)
        {
            var entry = _dbContext?.Orders?.Add(item);

            if (entry == null || entry.State != EntityState.Added)
                throw new InvalidOperationException("Order was not created");
        }

        public void Update(Order item)
        {
            throw new NotImplementedException();
        }
    }
}
