using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace LanguageBot
{
    public abstract class Command
    {
        public abstract string PreviousCommand { get; }
        /// <summary>
        /// Command name
        /// </summary>
        public abstract string CommandName { get; }
        /// <summary>
        /// Task command
        /// </summary>
        /// <param name="message"></param>
        /// <param name="client"></param>
        /// <returns></returns>
        public abstract Task ExecuteAsync(Message message, TelegramBotClient client);

        public abstract bool CanUse(long chatId,Message message);
    }
}
