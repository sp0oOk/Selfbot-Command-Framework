using Discord;
using Discord.Gateway;

namespace Selfbot.Commands
{
    [CommandInterface("help", "Returns a help embed", true)]
    internal class CommandHelp : Command
    {
        public override void Execute(DiscordSocketClient client, MessageEventArgs message, string[] args)
        {

            message.Message.Edit(new() { Embed = new EmbedMaker() { Description = "asdfsadf" }, Flags = MessageFlags.SuppressEmbeds });
        }
    }
}
