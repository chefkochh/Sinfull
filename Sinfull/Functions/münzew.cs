using Discord;
using Discord.Gateway;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sinfull.Functions
{
    internal class münzew
    {
        public static void münze(DiscordSocketClient client, MessageEventArgs args)
        {
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
            foreach (var zahla in zahlen)
            {
                if (zahla > 500)
                {
                    kopfzahl.Add("Kopf");
                }
                else
                {
                    kopfzahl.Add("Zahl");
                }
            }

            Thread.Sleep(1000);
            kzmessage.Edit(new MessageEditProperties { Content = @$"```:: Generiere 5 nummern von 1-1000...
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
            kzmessage.Edit(new MessageEditProperties { Content = @$"```:: Generiere 5 nummern von 1-1000...
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
            kzmessage.Edit(new MessageEditProperties { Content = @$"```:: Generiere 5 nummern von 1-1000...
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
            kzmessage.Edit(new MessageEditProperties { Content = @$"```:: Generiere 5 nummern von 1-1000...
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
            kzmessage.Edit(new MessageEditProperties { Content = @$"```:: Generiere 5 nummern von 1-1000...
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
            kzmessage.Edit(new MessageEditProperties { Content = @$"```:: Generiere 5 nummern von 1-1000...
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
            kzmessage.Edit(new MessageEditProperties { Content = @$"```:: Generiere 5 nummern von 1-1000...
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
        }
    }
}
