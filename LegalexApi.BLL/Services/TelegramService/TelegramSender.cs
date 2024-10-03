using Telegram.Bot;
using Telegram.Bot.Types.Enums;


namespace LegalexApi.BLL.Services.TelegramService
{
    public class TelegramSender : ITelegramSender
    {
        private readonly string _chatId;
        private readonly string _ApiToken;


        public TelegramSender(string chatId, string ApiToken)
        {
            _chatId = chatId;
            _ApiToken = ApiToken;
        }

        public async Task SendAsync(string message)
        {
            try
            {
                var bot = new TelegramBotClient(_ApiToken);
                await bot.SendTextMessageAsync(_chatId, message, parseMode: ParseMode.Markdown);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
