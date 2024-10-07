using LegalexApi.BLL.BusinessProcesses.AddOrder;
using LegalexApi.BLL.BusinessProcesses.SendNotification;
using LegalexApi.BLL.DTO;
using LegalexApi.DAL.Models.OrderAggregate;
using LegalexApi.Web.ViewModels;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using LegalexApi.Utility.Extensions;


namespace LegalexApi.Web.Controllers.API
{
    public class OrderController : BaseApiController
    {
        private readonly IMediator _mediator;


        public OrderController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public override async Task<IActionResult> Post(OrderViewModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest("Model isn't valid");

            var a = Enum.GetValues(typeof(Service)).Cast<Service>();

            var service = Enum.GetValues(typeof(Service)).Cast<Service>()
                .FirstOrDefault(x => x.GetDisplayName() == model.Service);

            var order = new OrderDTO
            {
                ClientType = model.ClientType,
                Service = service,
                Name = model.Name,
                Contact = model.Contact,
                Description = model.Description
            };

            try
            {
                await _mediator.Send(new AddOrderCommand(order));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            try
            {
                await _mediator.Send(new SendNotificationCommand(order));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return Ok();
        }

        public override async Task<IActionResult> Get(int id)
        {
            throw new NotImplementedException();
        }

        public override Task<IActionResult> Update(OrderViewModel model)
        {
            throw new NotImplementedException();
        }

        public override async Task<IActionResult> Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
