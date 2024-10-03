using LegalexApi.BLL.Services.TelegramService;
using LegalexApi.Utility.Extensions;
using MediatR;


namespace LegalexApi.BLL.BusinessProcesses.SendNotification
{
    public class SendNotificationCommandHandler : IRequestHandler<SendNotificationCommand>
    {
        private readonly ITelegramSender _sender;


        public SendNotificationCommandHandler(ITelegramSender sender)
        {
            _sender = sender;
        }

        public async Task Handle(SendNotificationCommand command, CancellationToken cancellationToken)
        {
            var service = command.Service.GetDisplayName();
            var type = command.ClientType.GetDisplayName();

            try
            {
                await _sender.SendAsync(
                $"*Тип заявки:*  {type}\n\n" +
                $"*Тип услуги:*  {service}\n\n" +
                $"*Имя:*  {command.Name}\n\n" +
                $"*Контакт:*  " + $"{command.Contact}\n\n" +
                $"*Описание:*  {command.Description}");
            }
            catch
            {
                throw new Exception("Failed to send telegram notification");
            }
        }
    }
}
