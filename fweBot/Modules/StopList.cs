using System.IO;
using System;
using System.Threading.Tasks;
using Discord;
using Discord.Commands;
using Discord.Addons.Interactive;
using Discord.WebSocket;
using fweBot.Services;

namespace fweBot.Modules
{
    public class StopList : ModuleBase<SocketCommandContext>
    {
        [Command("stoplist")]
        public async Task StopListAsync([Remainder] string routeC = null)
        {
           if(routeC == null)
            {
                var lostEmbed = new EmbedBuilder
                {
                    Title = "Are you lost?",
                    Description = "You need to enter a route name to see the stops, this is the same as the route number, e.g m1, 73.",
                    Color = Color.Red
                };
                Context.Message.Channel.SendMessageAsync(embed: lostEmbed.Build());
            }

            if (routeC == "m1")
            {
                var m1Embed1 = new EmbedBuilder
                {
                    Title = "m1: Cribbs Causeway - Hengrove Park",
                    Color = Color.Purple
                };
                m1Embed1.AddField("- Cribbs Causeway", "Alight for The Mall at Cribbs Causeway");
                m1Embed1.AddField("- Fir Tree Close", "No alightment information");

                Context.Message.Channel.SendMessageAsync(embed: m1Embed1.Build());
            }
        }
    }
}
