namespace Selfbot
{
    internal class Manager
    {
        private static readonly Dictionary<string, Command> _commands = new();

        public void AddCommand(Command command)
        {
            _commands.Add(command.GetCommandInterface().GetName(), command);   
        }

        public int LoadedCommands()
        {
            return _commands.Count;
        }

        public CommandInterface? GetCommandInterface(Type type)
        {
            CommandInterface commandInterface = (CommandInterface) Attribute.GetCustomAttribute(type, typeof(CommandInterface));
            if (commandInterface == null)
                return null;
            return commandInterface;
        }

        public Command? GetCommand(string name)
        {
            return !_commands.ContainsKey(name) ? null : _commands[name];
        }

    }
}
