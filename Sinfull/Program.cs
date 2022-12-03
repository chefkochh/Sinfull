using System;
using System.Threading;
using Discord;
using Discord.Commands;
using Discord.Gateway;
using Newtonsoft.Json.Linq;
using Sinfull.Functions;

namespace Sinfull
{
    internal class Program
    {
        public static string prefix = Data.prefix;
        private static void Main()
        {
            DiscordSocketClient client = new DiscordSocketClient();

            client.OnLoggedIn += Client_OnLoggedIn;
            client.OnMessageReceived += Client_OnMessageReceived;

            logo.logoo();
            if (!Directory.Exists(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\Sinfull"))
            {
                Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\Sinfull");
            }
            if (!File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\Sinfull\\token.sf"))
            {
                File.Create(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\Sinfull\\token.sf").Close();
                Console.WriteLine(":: Created 'token.sf'");
                Console.Write(":: token $ ");
                File.WriteAllText(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\Sinfull\\token.sf", Console.ReadLine());
            }

            Data.token = File.ReadAllText(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\Sinfull\\token.sf");
            client.Login(Data.token);
            Thread.Sleep(-1);
        }

        private static void Client_OnLoggedIn(DiscordSocketClient client, LoginEventArgs args)
        {
            Console.WriteLine(":: logged in to " + client.User.Username);
            
        }

        private static void Client_OnMessageReceived(DiscordSocketClient client, MessageEventArgs args)
        {
            if(client.User.Id == args.Message.Author.User.Id)
            {
                if (args.Message.Content.StartsWith(prefix))
                {
                    try
                    {
                        Functions.CommandHandlerClass.CommandHandler(client, args);
                    }
                    catch(Exception ex)
                    {
                        SendMessage.Send(client, args, @$"Error in '{args.Message.Content}'
```{ex.Message}```");
                    }
                }
            }
        }
    }
}