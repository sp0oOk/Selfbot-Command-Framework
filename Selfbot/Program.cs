using Newtonsoft.Json.Linq;
using Discord.Gateway;
using System.Text.RegularExpressions;
using Selfbot.Commands;

namespace Selfbot
{
    public class SelfbotExtensions
    {
        private static readonly JObject config = JObject.Parse(File.ReadAllText("config.json"));
        private static readonly Manager manager = new();


        static int Main() { 
            DiscordSocketClient client = new(new DiscordSocketConfig() { ApiVersion = 7U });
            client.OnLoggedIn += Client_OnLoggedIn;
            client.OnMessageReceived += Client_OnMessageReceived;
            client.Login(config["token"]?.ToString());
            RegisterCommands();
            Thread.Sleep(-1);
            return 0; 
        }

        private static void RegisterCommands()
        {
            manager.AddCommand(new CommandHelp());
            manager.AddCommand(new CommandRotate());
        }

        private static void Client_OnMessageReceived(DiscordSocketClient client, MessageEventArgs args)
        {
            if (!args.Message.Author.User.Id.Equals(client.User.Id) || !args.Message.Content.StartsWith(config["prefix"]?.ToString())) return;
            string[] vs = Regex.Split(args.Message.Content, " +");
            if (vs.Length < 1) return;
            string command = vs[0].ToLower().Replace(config["prefix"]?.ToString(), "");
            Command? _command = manager.GetCommand(command);
            vs = vs.Skip(1).ToArray();
            if(_command == null) return;
            if (_command.GetCommandInterface().IsDeleteAfterExecution())
                args.Message.DeleteAsync();
            _command.Execute(client, args, vs);
        }

        private static void Client_OnLoggedIn(DiscordSocketClient client, LoginEventArgs args)
        {
            Utils.LogColored(ConsoleColor.Yellow, "[LOG] Logged into Discord as " + client.User.Username + " (" + client.User.Id + ") @ " + DateTime.Now);
        }

        internal static Manager GetManager()
        {
            return manager;
        }
 
    
    }
}