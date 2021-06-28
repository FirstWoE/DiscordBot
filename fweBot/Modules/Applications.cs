using System.IO;
using System;
using System.Threading.Tasks;
using Discord;
using Discord.Commands;
using Discord.WebSocket;
using fweBot.Services;

namespace fweBot.Modules
{
    public class Applications : ModuleBase<SocketCommandContext>
    {
        [Command("applications")]
        public async Task ApplicationsAsync()
        {
            var embed = new EmbedBuilder
            {
                Title = "Applications.",
                Description = "All applications are shut whilst we setup our operations.",
                Color = Color.Purple
            };
            Context.Channel.SendMessageAsync(embed: embed.Build());
        }
    }
}
