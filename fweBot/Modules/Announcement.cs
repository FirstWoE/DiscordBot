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
    public class AnnouncementModule : InteractiveBase
    {
        [Command("announcement", RunMode = RunMode.Async)]
        [RequireUserPermission(GuildPermission.Administrator)]
        public async Task Announcement(ulong channel)
        {
            var embed = new EmbedBuilder {};
            await ReplyAsync("What is the title of the announcement?");
            var titleM = await NextMessageAsync();
            if (titleM != null)
            {
                embed.Title = titleM.Content;
                await ReplyAsync("What is the field (description) of this announcement?");
                var descM = await NextMessageAsync();
                if(descM != null)
                {
                    embed.Description = descM.Content;
                    await ReplyAsync("Do you want to attach an image to this embed? Y/n");
                    var imageASK = await NextMessageAsync();
                    if(imageASK.Content.ToUpper() == "Y")
                    {
                        await ReplyAsync("Upload ONE image.");
                        var imageM = await NextMessageAsync();
                        foreach (Attachment image in imageM.Attachments)
                        {
                            embed.ImageUrl = image.Url;
                        }
                    }  else if(imageASK.Content.ToUpper() == "N")
                    {
                        await ReplyAsync("That's ok!");
                    } else
                    {
                        await ReplyAsync("You did not specify a correct option. Setting the value to false.");
                    }
                    await ReplyAsync("Do you want to add the timestamp? Y/n");
                    var timestampASK = await NextMessageAsync();
                    if (timestampASK.Content.ToUpper() == "Y")
                    {
                        embed.Timestamp = DateTimeOffset.Now;
                        await ReplyAsync("Added timestamp.");
                    }
                    else if (timestampASK.Content.ToUpper() == "N")
                    {
                        await ReplyAsync("That's ok!");
                    }
                    else
                    {
                        await ReplyAsync("You did not specify a correct option. Setting the value to false.");
                    }
                    embed.Author = new EmbedAuthorBuilder { Name = Context.Message.Author.Username };
                    embed.Color = Color.Purple;
                    await ReplyAsync($"Here is the embed. Do you want to send this to channel with the ID {channel}? Y/n");
                    Context.Channel.SendMessageAsync(embed: embed.Build());
                    var sendASK = await NextMessageAsync();
                    if (sendASK.Content.ToUpper() == "Y")
                    {
                        Context.Guild.GetTextChannel(channel).SendMessageAsync(embed: embed.Build());
                    }
                    else if (sendASK.Content.ToUpper() == "N")
                    {
                        await ReplyAsync("That's ok!");
                    }
                    else
                    {
                        await ReplyAsync("You did not specify a correct option. I will not send this embed.");
                    }
                }
            }
            else
                await ReplyAsync("You did not reply before the timeout");
        }
    }
}
