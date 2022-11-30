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
                    Data.Commands.Add("münze:Flips a coin");



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

                case "münze":
                    int kopf = 0;
                    int zahl = 0;
                    

                    string ergebnis = string.Empty;

                    List<int> zahlen = new List<int>();
                    List<string> kopfzahl = new List<string>();
                    Random rnd = new Random();


                    var kzmessage = SendMessage.Send(client, args, @$"```:: Generiere 5 nummern von 1-1000
- nummer > 500 = Kopf
- nummer < 500 = Zahl

[1]: 
[2]:
[3]:
[4]:
[5]:

Kopf: 0
Zahl: {zahl}

Ergebnis: {ergebnis}```", false);

                    for (int j = 0; j < 5; j++)
                    {
                        zahlen.Add(rnd.Next(1000));
                    }
                    foreach(var zahla in zahlen)
                    {
                        if (zahla > 500) 
                        { 
                            kopfzahl.Add("Kopf");  
                        } 
                        else 
                        {
                            kopfzahl.Add("Zahl");                         }
                    }

                    Thread.Sleep(1000);
                    kzmessage.Edit(new MessageEditProperties { Content = @$"```:: Generiere 10 nummern von 1-1000...
- nummer > 500 = Kopf
- nummer < 500 = Zahl

[1]: {zahlen[0]} = {kopfzahl[0]}
[2]:
[3]:
[4]:
[5]:

Kopf: {kopf}
Zahl: {zahl}

Ergebnis: {ergebnis}```" });
                    if (kopfzahl[0] == "Kopf") { kopf++; } else { zahl++; }
                    Thread.Sleep(1000);
                    kzmessage.Edit(new MessageEditProperties { Content = @$"```:: Generiere 10 nummern von 1-1000...
- nummer > 500 = Kopf
- nummer < 500 = Zahl

[1]: {zahlen[0]} = {kopfzahl[0]}
[2]: {zahlen[1]} = {kopfzahl[1]}
[3]:
[4]:
[5]:

Kopf: {kopf}
Zahl: {zahl}

Ergebnis: {ergebnis}```" });
                    if (kopfzahl[1] == "Kopf") { kopf++; } else { zahl++; }
                    Thread.Sleep(1000);
                    kzmessage.Edit(new MessageEditProperties { Content = @$"```:: Generiere 10 nummern von 1-1000...
- nummer > 500 = Kopf
- nummer < 500 = Zahl

[1]: {zahlen[0]} = {kopfzahl[0]}
[2]: {zahlen[1]} = {kopfzahl[1]}
[3]: {zahlen[2]} = {kopfzahl[2]}
[4]:
[5]:

Kopf: {kopf}
Zahl: {zahl}

Ergebnis: {ergebnis}```" });
                    if (kopfzahl[2] == "Kopf") { kopf++; } else { zahl++; }
                    Thread.Sleep(1000);
                    kzmessage.Edit(new MessageEditProperties { Content = @$"```:: Generiere 10 nummern von 1-1000...
- nummer > 500 = Kopf
- nummer < 500 = Zahl

[1]: {zahlen[0]} = {kopfzahl[0]}
[2]: {zahlen[1]} = {kopfzahl[1]}
[3]: {zahlen[2]} = {kopfzahl[2]}
[4]: {zahlen[3]} = {kopfzahl[3]}
[5]:

Kopf: {kopf}
Zahl: {zahl}

Ergebnis: {ergebnis}```" });
                    if (kopfzahl[3] == "Kopf") { kopf++; } else { zahl++; }
                    Thread.Sleep(1000);
                    kzmessage.Edit(new MessageEditProperties { Content = @$"```:: Generiere 10 nummern von 1-1000...
- nummer > 500 = Kopf
- nummer < 500 = Zahl

[1]: {zahlen[0]} = {kopfzahl[0]}
[2]: {zahlen[1]} = {kopfzahl[1]}
[3]: {zahlen[2]} = {kopfzahl[2]}
[4]: {zahlen[3]} = {kopfzahl[3]}
[5]: {zahlen[4]} = {kopfzahl[4]}

Kopf: {kopf}
Zahl: {zahl}

Ergebnis: {ergebnis}```" });
                    

                    if (kopfzahl[4] == "Kopf") { kopf++; } else { zahl++; }
                    Thread.Sleep(1000);
                    kzmessage.Edit(new MessageEditProperties { Content = @$"```:: Generiere 10 nummern von 1-1000...
- nummer > 500 = Kopf
- nummer < 500 = Zahl

[1]: {zahlen[0]} = {kopfzahl[0]}
[2]: {zahlen[1]} = {kopfzahl[1]}
[3]: {zahlen[2]} = {kopfzahl[2]}
[4]: {zahlen[3]} = {kopfzahl[3]}
[5]: {zahlen[4]} = {kopfzahl[4]}

Kopf: {kopf}
Zahl: {zahl}

Ergebnis: {ergebnis}```" });


                    if (kopf > zahl) { ergebnis = "Kopf"; } else { ergebnis = "Zahl"; }
                    Thread.Sleep(1000);
                    kzmessage.Edit(new MessageEditProperties { Content = @$"```:: Generiere 10 nummern von 1-1000...
- nummer > 500 = Kopf
- nummer < 500 = Zahl

[1]: {zahlen[0]} = {kopfzahl[0]}
[2]: {zahlen[1]} = {kopfzahl[1]}
[3]: {zahlen[2]} = {kopfzahl[2]}
[4]: {zahlen[3]} = {kopfzahl[3]}
[5]: {zahlen[4]} = {kopfzahl[4]}

Kopf: {kopf}
Zahl: {zahl}

Ergebnis: {ergebnis}```" });

                    Thread.Sleep(5000);
                    kzmessage.Delete();

                    break;


                default:
                    Console.WriteLine($":: Command not found '{message.Content}'");
                    break;

            }

        }
    }
}
