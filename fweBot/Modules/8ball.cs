using System.IO;
using System;
using System.Threading.Tasks;
using Discord;
using Discord.Commands;
using Discord.WebSocket;
using fweBot.Services;
using System.Collections.Generic;

namespace fweBot.Modules
{
    public class _8ball : ModuleBase<SocketCommandContext>
    {
        [Command("8ball")]
        public async Task eightBall([Remainder] string message)
        {
            List<string> list = new List<string>() {"No", "Only time will tell", "DEFINITELY NOT", "I don't know son.", "Maybe, but who knows?", "100%", "YES" };
            Random rnd = new Random();
            int number = rnd.Next(1, list.Count);
            var embed = new EmbedBuilder
            {
                Title = $"The 8 ball says to {message}:",
                Description = list[number],
                Color = Color.DarkRed
            };
            Context.Channel.SendMessageAsync(embed: embed.Build());
        }
    }
}
