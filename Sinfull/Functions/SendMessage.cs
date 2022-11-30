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
        public static void Send(DiscordSocketClient client, MessageEventArgs args, string content)
        {
            var message = client.SendMessage(args.Message.Channel.Id, content);
            Thread.Sleep(Data.deletetimer);
            message.Delete();
        }
    }
}
