using LegalexApi.DAL.Models;
using LegalexApi.DAL.Models.OrderAggregate;
using LegalexApi.DAL.Storage;
using LegalexApi.DAL.Storage.Repositories;
using Microsoft.EntityFrameworkCore;


namespace LegalexApi.DAL
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly OrderRepository _orderRepository;
        public IOrderRepository Orders { get => _orderRepository; }


        public UnitOfWork(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
            _orderRepository = new(dbContext);

            InitialDatabase();
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
            _dbContext.Dispose();
        }

        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }

        private void InitialDatabase()
        {
            if (_dbContext.Database.GetPendingMigrations().Any())
                _dbContext.Database.Migrate();

            _dbContext.SaveChanges();
        }
    }
}
