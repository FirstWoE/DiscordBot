using System.IO;
using System;
using System.Threading.Tasks;
using Discord;
using Discord.Commands;
using Discord.WebSocket;
using fweBot.Services;

namespace fweBot.Modules
{
    public class PMRole : ModuleBase<SocketCommandContext>
    {
        [Command("pmrole")]
        [RequireUserPermission(GuildPermission.Administrator)]
        public Task TestersAsync(ulong roleId, [Remainder] string message)
        {
            foreach (SocketRole role in Context.Guild.Roles)
            {
                if (role.Id == roleId)
                {
                    foreach (SocketGuildUser user in role.Members)
                    {
                        var embed = new EmbedBuilder
                        {
                            // Embed property can be set within object initializer
                            Title = "There was a message sent out to all people with a role you have.",
                            Description = $"Message: {message}",
                            Color = Color.DarkBlue,
                            Footer = new EmbedFooterBuilder
                            {
                                Text = $"Announcement sent out by: {Context.Message.Author.Username} for role: {role.Name}"
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
