using System.IO;
using System;
using System.Threading.Tasks;
using Discord;
using Discord.Commands;
using Discord.WebSocket;
using fweBot.Services;

namespace fweBot.Modules
{
    public class Help : ModuleBase<SocketCommandContext>
    {
        [Command("help")]
        public async Task HelpAsync()
        {
            var embed = new EmbedBuilder
            {
                Title = "Commands.",
                Color = Color.DarkRed
            };
            embed.AddField(";help", "Displays this message.");
            embed.AddField(";userinfo", "Displays your's or someone you tag's user info.");
            embed.AddField(";ban", "Bans a user. REQUIRED: Ban Members");
            embed.AddField(";announcement", "Interactive embed to create an announcement. REQUIRED: Administrator");
            embed.AddField(";pmrole", "DM's all people with a certain role. REQUIRED: Administrator");
            embed.AddField(";testers", "Notifies all testers a testing session is taking place. REQUIRED: Administrator");
        }
    }
}
