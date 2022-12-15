using System;
using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Extensions.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Exceptions;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;
using System.Data.SqlClient;
using System.Security.Cryptography.X509Certificates;
using System.Data.SQLite;
using System.Collections.Specialized;
using Microsoft.VisualBasic;


namespace tg_bot
{
    class Program
    {
        static TelegramBotClient botClient = new TelegramBotClient("5826612141:AAGtP4Irsrgnj1YDMmsScLiLw0XVC0HaS38");
        public static SQLiteConnection DB;

        static async void Main(string[] args)
        {
            using var cts = new CancellationTokenSource();
            var me = await botClient.GetMeAsync();

            var receiverOptions = new ReceiverOptions
            {
                AllowedUpdates = new UpdateType[]
                {
                    UpdateType.Message,
                    UpdateType.EditedMessage,
                }
            };
            Console.WriteLine($"works @{me.Username}");
            Console.ReadLine();
            cts.Cancel();
            botClient.StartReceiving(UpdateHandler, ErrorHandler, receiverOptions, cancellationToken: cts.Token);
        }

        private static Task ErrorHandler(ITelegramBotClient arg1, Exception arg2, CancellationToken arg3)
        {
            throw new NotImplementedException();
        }

        private static async Task UpdateHandler(ITelegramBotClient botClient, Update update, CancellationToken arg3)
        {
            if (update.Type == UpdateType.Message && update?.Message?.Text != null)
            {
                if (update.Message.Type == MessageType.Text)
                {
                    var text = update.Message.Text;
                    var id = update.Message.Chat.Id;
                    /*var id = user.UserId;*/
                    string? username = update.Message.Chat.Username;
                    var data = update.Message.Date;

                    Console.WriteLine($"{username} | {id} | {text} | {data}");

                  
                }
            }
        }

        public static void Reg(int id, int username, string date)
        {
            try
            {
                DB = new SQLiteConnection("Data Source = DB.db");
                DB.Open();
                SQLiteCommand regcmd = DB.CreateCommand();
                regcmd.CommandText = "INSERT INTO users VALUES(@id, @username, @date)";
                regcmd.Parameters.AddWithValue("@id", id);
                regcmd.Parameters.AddWithValue("@username", username);
                regcmd.Parameters.AddWithValue("@date", date);
                DB.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex);
            }

        }


   
        async Task HandleMessage(ITelegramBotClient botClient, Message message)
        {
            if (message.Text == "/start")
            {
                await botClient.SendTextMessageAsync(message.Chat.Id, "Щоб глянути розклад тицьни /keyboard");

            }

            if (message.Text == "/keyboard")
            {
                ReplyKeyboardMarkup keyboard = new(new[]
                {
            new KeyboardButton[] {"Інженерія ПЗ", "Автоматизація"},
            new KeyboardButton[] {"Менеджмент", "Маркетинг"},
            new KeyboardButton[] {"Фінанси", "Облік і оподаткування"},
             new KeyboardButton[] {"Технології ЛП", "Машинобудування"},
              new KeyboardButton[] {"Деревообробні та МТ", "Розклад дзвінків"}
        })

                {
                    ResizeKeyboard = true
                };

                await botClient.SendTextMessageAsync(message.Chat.Id, "Спеціальність?", replyMarkup: keyboard);
                return;
            }


            if (message.Text == "Інженерія ПЗ")
            {
                InlineKeyboardMarkup keyboard = new(new[]
                {
            new[]
            {
               InlineKeyboardButton.WithCallbackData("П-11"),
               InlineKeyboardButton.WithCallbackData("П-21"),
                InlineKeyboardButton.WithCallbackData("П-31"),
                 InlineKeyboardButton.WithCallbackData("П-32"),
                 InlineKeyboardButton.WithCallbackData("П-41"),
                  InlineKeyboardButton.WithCallbackData("П-42")
            }
        }
                );
                await botClient.SendTextMessageAsync(message.Chat.Id, "Група?", replyMarkup: keyboard);
                return;
            }

            if (message.Text == "Автоматизація")
            {
                InlineKeyboardMarkup keyboard = new(new[]
                {
            new[]
            {
               InlineKeyboardButton.WithCallbackData("А-11"),
               InlineKeyboardButton.WithCallbackData("А-21"),
                InlineKeyboardButton.WithCallbackData("A-31"),
                 InlineKeyboardButton.WithCallbackData("A-41")

            }
        }
                );
                await botClient.SendTextMessageAsync(message.Chat.Id, "Група?", replyMarkup: keyboard);
                return;
            }

            if (message.Text == "Менеджмент")
            {
                InlineKeyboardMarkup keyboard = new(new[]
                {
            new[]
            {
                InlineKeyboardButton.WithCallbackData("Мд-11"),
               InlineKeyboardButton.WithCallbackData("Мд-21"),
                InlineKeyboardButton.WithCallbackData("Мд-31")

            }
        }
                );
                await botClient.SendTextMessageAsync(message.Chat.Id, "Група?", replyMarkup: keyboard);
                return;
            }


            if (message.Text == "Маркетинг")
            {
                InlineKeyboardMarkup keyboard = new(new[]
                {
            new[]
            {
                 InlineKeyboardButton.WithCallbackData("Е-11"),
               InlineKeyboardButton.WithCallbackData("Е-21"),
                InlineKeyboardButton.WithCallbackData("Е-31"),
                 InlineKeyboardButton.WithCallbackData("Е-41")

            }
        }
                );
                await botClient.SendTextMessageAsync(message.Chat.Id, "Група?", replyMarkup: keyboard);
                return;
            }


            if (message.Text == "Фінанси")
            {
                InlineKeyboardMarkup keyboard = new(new[]
                {
            new[]
            {
               InlineKeyboardButton.WithCallbackData("Ф-11"),
               InlineKeyboardButton.WithCallbackData("Ф-21"),
                InlineKeyboardButton.WithCallbackData("Ф-31")

            }
        }
                );
                await botClient.SendTextMessageAsync(message.Chat.Id, "Група?", replyMarkup: keyboard);
                return;
            }


            if (message.Text == "Облік і оподаткування")
            {
                InlineKeyboardMarkup keyboard = new(new[]
                {
            new[]
            {
                InlineKeyboardButton.WithCallbackData("Б-11"),
               InlineKeyboardButton.WithCallbackData("Б-21"),
                InlineKeyboardButton.WithCallbackData("Б-31")

            }
        }
                );
                await botClient.SendTextMessageAsync(message.Chat.Id, "Група?", replyMarkup: keyboard);
                return;
            }


            if (message.Text == "Технології ЛП")
            {
                InlineKeyboardMarkup keyboard = new(new[]
                {
            new[]
            {
                InlineKeyboardButton.WithCallbackData("Мк-11"),
               InlineKeyboardButton.WithCallbackData("Мк-21"),
                InlineKeyboardButton.WithCallbackData("Мк-31"),
                 InlineKeyboardButton.WithCallbackData("Мк-41")

            }
        }
                );
                await botClient.SendTextMessageAsync(message.Chat.Id, "Група?", replyMarkup: keyboard);
                return;
            }

            if (message.Text == "Машинобудування")
            {
                InlineKeyboardMarkup keyboard = new(new[]
                {
            new[]
            {
                  InlineKeyboardButton.WithCallbackData("М-11"),
               InlineKeyboardButton.WithCallbackData("М-21"),
                InlineKeyboardButton.WithCallbackData("М-31"),
                 InlineKeyboardButton.WithCallbackData("М-41")

            }
        }
                );

                await botClient.SendTextMessageAsync(message.Chat.Id, "Група?", replyMarkup: keyboard);
                return;
            }

            if (message.Text == "Деревообробні та МТ")
            {
                InlineKeyboardMarkup keyboard = new(new[]
                {
            new[]
            {
                 InlineKeyboardButton.WithCallbackData("Т-11"),
               InlineKeyboardButton.WithCallbackData("Т-21"),
                InlineKeyboardButton.WithCallbackData("Т-31")

            }
        }
                );

                await botClient.SendTextMessageAsync(message.Chat.Id, "Група?", replyMarkup: keyboard);
                return;
            }

            if (message.Text == "Розклад дзвінків")
            {
                InlineKeyboardMarkup keyboard = new(new[]
                {
            new[]
            {
                 InlineKeyboardButton.WithCallbackData("Звичайний"),
               InlineKeyboardButton.WithCallbackData("Скорочений"),

            }
        }
                );

                await botClient.SendTextMessageAsync(message.Chat.Id, "Група?", replyMarkup: keyboard);
                return;
            }



        }

        async Task HandleCallbackQuery(ITelegramBotClient botClient, CallbackQuery callbackQuery)
        {

        }

        




    }
}





