namespace Selfbot
{
    [System.AttributeUsage(System.AttributeTargets.Class, AllowMultiple = true)]
    internal class CommandInterface : System.Attribute
    {
        private readonly String Name;
        private readonly String Description;
        private readonly bool DeleteAfterExecution;

        public CommandInterface(string name, string description, bool deleteafterexecution)
        {
            Name = name;
            Description = description;
            DeleteAfterExecution = deleteafterexecution;
        }
        public string GetName()
        {
            return Name;
        }

        public bool IsDeleteAfterExecution()
        {
            return DeleteAfterExecution;
        }


    }
}
