using System;
using Telegram.Bot;
using Telegram.Bot.Args;

namespace Telegram_Bot_ATNG
{
    class Program
    {
        private static TelegramBotClient telegram;
        static void Main(string[] args)
        {
            telegram = new TelegramBotClient(Token.token);
            telegram.StartReceiving();
            telegram.OnMessage += OnMessageHandler;
            Console.WriteLine("Started bot");
            Console.ReadKey();
            telegram.StopReceiving();
        }

        private static async void OnMessageHandler(object sender, MessageEventArgs e)
        {
            var message = e.Message;
            var bot_mes = "Hello";
            if (message.Text != null)
            {
                Console.WriteLine(message.From.Id + message.From.FirstName + message.From.LastName);
                Console.WriteLine(message.Text);
                await telegram.SendTextMessageAsync(message.Chat.Id, bot_mes);
            }
        }
    }
}
