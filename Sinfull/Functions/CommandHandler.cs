using Discord;
using Discord.Gateway;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Security.Authentication.ExtendedProtection;
using System.Text;
using System.Threading.Tasks;

namespace Sinfull.Functions
{
    internal class CommandHandlerClass
    {
        public static void CommandHandler(DiscordSocketClient client, MessageEventArgs args)
        {
            args.Message.Delete();
            var message = args.Message;
            var arguments = args.Message.Content.Split(" ");
            var command = args.Message.Content.Split(' ')[0].Replace(Program.prefix, "");


            switch (command)
            {
                case "help":
                    Data.Commands.Add("purge <ammount> [all]:Purges the messages for you/everyone");
                    Data.Commands.Add($"purgeme:Purges all your messages in a channel");
                    Data.Commands.Add("shutdown:Shuts the selfbot safely down");
                    
                    string helptext = string.Empty;
                    foreach(var hcommand in Data.Commands)
                    {
                        var name = hcommand.Split(":")[0];
                        var description = hcommand.Split(":")[1];

                        helptext = helptext + $"\n```{name} \n-> {description} ```";
                    }
                    Functions.SendMessage.Send(client, args, helptext);
                    break;


                case "test":
                    Functions.SendMessage.Send(client, args, "I cant pay electric bill");
                    break;


                case "shutdown":
                    client.Logout();
                    Environment.Exit(0);
                    break;


                case "purge":
                    var channelmsg = new List<DiscordMessage>();
                    foreach(var purgemsg in client.GetChannelMessages(message.Channel.Id))
                    {
                        try
                        {
                            if (arguments[2] == "all")
                            {
                                channelmsg.Add(purgemsg);   
                            }
                        }
                        catch
                        {
                            if (purgemsg.Author.User.Id == client.User.Id) { channelmsg.Add(purgemsg); }
                        }
                    }
                    int todelete = Convert.ToInt32(arguments[1]);
                    int deleted = 0;
                    foreach(var purgemessage in channelmsg) 
                    {
                        foreach (var todeletemsg in channelmsg)
                        {
                            if (deleted < todelete) { todeletemsg.Delete(); deleted++; }
                            else { break; }
                        }
                    }
                    break;


                case "purgeme":
                    var topurgemsg = client.GetChannelMessages(message.Channel.Id);
                    topurgemsg.Reverse();
                    foreach (var purgemsg in topurgemsg)
                    {
                        if (purgemsg.Author.User.Id == client.User.Id) 
                        {
                            purgemsg.Delete();
                            Thread.Sleep(100);
                        }
                    }
                    break;
                

                


                default:
                    Console.WriteLine($":: Command not found '{message.Content}'");
                    break;

            }

        }
    }
}
