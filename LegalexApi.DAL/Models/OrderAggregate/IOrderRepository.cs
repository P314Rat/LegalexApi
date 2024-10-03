namespace LegalexApi.DAL.Models.OrderAggregate
{
    public interface IOrderRepository
    {
        void Create(Order item);
        void Update(Order item);
    }
}
