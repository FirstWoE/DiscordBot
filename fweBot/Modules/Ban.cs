using System.IO;
using System;
using System.Threading.Tasks;
using Discord;
using Discord.Commands;
using Discord.WebSocket;
using fweBot.Services;

namespace fweBot.Modules
{
    public class Ban : ModuleBase<SocketCommandContext>
    {
        [Command("ban")]
        [RequireContext(ContextType.Guild)]
        // make sure the user invoking the command can ban
        [RequireUserPermission(GuildPermission.BanMembers)]
        // make sure the bot itself can ban
        [RequireBotPermission(GuildPermission.BanMembers)]
        public async Task BanUserAsync(IGuildUser user, [Remainder] string reason = null)
        {
            await user.Guild.AddBanAsync(user, reason: reason);
            await ReplyAsync($"Banned user {user.Username} for {reason}!");
            var embed = new EmbedBuilder
            {
                Title = $"User {user.Username} banned",
                Description = $"Reason: {reason}",
                Footer = new EmbedFooterBuilder
                {
                    Text = $"Banned by {Context.Message.Author.Username}"
                },
                Color = Color.DarkRed
            };
        }
    }
}
