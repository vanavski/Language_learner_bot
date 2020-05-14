using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace LanguageBot
{
    public abstract class CallBackCommand
    {
        /// <summary>
        /// Command name
        /// </summary>
        public abstract string Name { get; }

        public abstract bool CanUse(long userId, CallbackQuery callback);

        /// <summary>
        /// Task command
        /// </summary>
        /// <param name="message"></param>
        /// <param name="client"></param>
        /// <returns></returns>
        public abstract Task ExecuteAsync(CallbackQuery callback, TelegramBotClient client);
    }
}
