using LegalexApi.DAL.Models;
using LegalexApi.DAL.Models.OrderAggregate;
using MediatR;


namespace LegalexApi.BLL.BusinessProcesses.AddOrder
{
    public class AddOrderCommandHandler : IRequestHandler<AddOrderCommand>
    {
        private readonly IUnitOfWork _unitOfWork;


        public AddOrderCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Task Handle(AddOrderCommand command, CancellationToken cancellationToken)
        {
            var order = new Order
            {
                CreatedAt = DateTime.Now,
                ClientType = command.ClientType,
                Service = command.Service,
                Name = command.Name,
                Contact = command.Contact,
                Description = command.Description
            };

            _unitOfWork.Orders.Create(order);
            _unitOfWork.SaveChanges();

            return Task.CompletedTask;
        }
    }
}
