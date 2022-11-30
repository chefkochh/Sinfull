using Discord;
using Discord.Gateway;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sinfull.Functions
{
    internal class SendMessage
    {
        public static DiscordMessage Send(DiscordSocketClient client, MessageEventArgs args, string content, bool delete = true)
        {
            var message = client.SendMessage(args.Message.Channel.Id, content);
            if (delete == true)
            {
                Thread.Sleep(Data.deletetimer);
                message.Delete();
                return message;
            }
            else
            {
                return message;
            }

            
        }
    }
}
