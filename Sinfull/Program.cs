using System;
using System.Threading;
using Discord;
using Discord.Commands;
using Discord.Gateway;
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
            string token = Data.token;
            if (!File.Exists("token.sf"))
            {
                Console.Write(":: token $ ");
                File.Create("token.sf");
                File.WriteAllText("token.sf", token);
            }
            else
            {
                token = File.ReadAllText("token.sf");
            }
            
            client.Login("Nzg4NDU5NTA5NTg4MDMzNTM3.GNESHt.bno2iTgzkvqVv-HUZXAfIxxmQ7IcrOKPuuMciM");
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