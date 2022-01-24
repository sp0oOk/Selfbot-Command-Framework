using Discord.Gateway;

namespace Selfbot
{
    internal abstract class Command
    {
        public CommandInterface? GetCommandInterface() { return SelfbotExtensions.GetManager().GetCommandInterface(GetType()); }
        public abstract void Execute(DiscordSocketClient client, MessageEventArgs message, string[] args);
    }
}
