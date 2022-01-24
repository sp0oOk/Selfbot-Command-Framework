using Discord.Gateway;

namespace Selfbot.Commands
{
    [CommandInterface("rotate", "Rotate statuses automatically read from statuses.txt", true)]
    internal class CommandRotate : Command
    {
        private bool _rotate = false;
        private int _rotation = 1;

        public override void Execute(DiscordSocketClient client, MessageEventArgs message, string[] args)
        {
            IEnumerable<string> lines = File.ReadLines("statuses.txt");
            if(lines.Count() == 0)
            {
                Utils.LogColored(ConsoleColor.DarkYellow, "[WARN] The file \"statuses.txt\" is empty? Please try again!");
                return;
            }
            if(_rotate == true)
            {
                _rotate = false;
                Utils.LogColored(ConsoleColor.Blue, "[INFO] Successfully halted status rotation!");
                return;
            }
            _rotate = true;
            Utils.LogColored(ConsoleColor.Blue, "[INFO] Successfully started rotating statuses automatically!");
            while (_rotate == true)
            {
                if (_rotate == false)
                    break;
                if (_rotation == lines.Count())
                    _rotation = 1;
                client.User.ChangeSettings(new() { Theme = Discord.DiscordTheme.Dark, CustomStatus = new() { Text = lines.ElementAt(_rotation) } });
                _rotation++;
                Thread.Sleep(2000);
            }
        }
    }
}
