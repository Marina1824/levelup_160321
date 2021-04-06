using System.Collections.Generic;
using Tasks.Management.Data;

namespace Tasks.Management.Commands
{
    public abstract class BaseCommand
    {
        public bool CanHandle(string command)
        {
            if (string.IsNullOrWhiteSpace(command))
            {
                return false;
            }

            if (string.CompareOrdinal(command.ToLower(), CommandName.ToLower()) == 0)
            {
                return true;
            }

            return false;
        }

        public virtual void Process(List<UserTask> tasks)
        {
            System.Console.WriteLine("Empty command");
        }

        protected abstract string CommandName { get; }
    }
}