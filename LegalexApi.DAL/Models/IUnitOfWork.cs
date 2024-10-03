using LegalexApi.DAL.Models.OrderAggregate;


namespace LegalexApi.DAL.Models
{
    public interface IUnitOfWork : IDisposable
    {
        IOrderRepository Orders { get; }

        void SaveChanges();
    }
}
