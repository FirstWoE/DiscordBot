using System.IO;
using System;
using System.Threading.Tasks;
using Discord;
using Discord.Commands;
using Discord.WebSocket;
using fweBot.Services;

namespace fweBot.Modules
{
    public class RequireTesters : ModuleBase<SocketCommandContext>
    {
        [Command("testers")]
        [RequireUserPermission(GuildPermission.Administrator)]
        public Task TestersAsync()
        {
            foreach (SocketRole role in Context.Guild.Roles)
            {
                if(role.Id == 848621594620198961)
                {
                    foreach(SocketGuildUser user in role.Members)
                    {
                        var embed = new EmbedBuilder
                        {
                            // Embed property can be set within object initializer
                            Title = "There is a testing session currently taking place.",
                            Description = "You can join here: https://www.roblox.com/games/6754071908/B",
                            Color = Color.Green,
                            Footer = new EmbedFooterBuilder
                            {
                                Text = $"Announcement sent out by: {Context.Message.Author.Username}"
                            }
                        };
                        user.SendMessageAsync(embed: embed.Build());
                        Context.Channel.SendMessageAsync("Successfully sent message.");
                    }
                }
            }
            return Task.CompletedTask;
        }
    }
}
