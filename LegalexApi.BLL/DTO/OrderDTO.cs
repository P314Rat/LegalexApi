using LegalexApi.DAL.Models.OrderAggregate;


namespace LegalexApi.BLL.DTO
{
    public class OrderDTO
    {
        public ClientType ClientType { get; set; }
        public Service Service { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Contact { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
    }
}
