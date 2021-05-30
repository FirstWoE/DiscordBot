using System.IO;
using System;
using System.Threading.Tasks;
using Discord;
using Discord.Commands;
using Discord.WebSocket;
using fweBot.Services;

namespace fweBot.Modules
{
    public class UserInfo : ModuleBase<SocketCommandContext>
    {
        [Command("userinfo")]
        public async Task UserInfoAsync(IUser user = null)
        {
            user = user ?? Context.User;

            var embed = new EmbedBuilder
            {
                Author = new EmbedAuthorBuilder
                {
                    IconUrl = user.GetAvatarUrl()
                },
                Title = $"{user.Username}'s information.",
                Color = Color.DarkTeal
            };
            embed.AddField("Joined Discord:", user.CreatedAt);
            embed.AddField("Status:", user.Status);
            embed.AddField("Activity:", user.Activity);
            embed.AddField("User a bot?", user.IsBot);

            Context.Message.Channel.SendMessageAsync(embed: embed.Build());
        }
    }
}
