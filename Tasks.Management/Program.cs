using System;
using System.Collections.Generic;
using Tasks.Management.Commands;
using Tasks.Management.Data;
using Tasks.Management.Service;

namespace Tasks.Management
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello %username%!");

            PersistenceService persistenceService = new PersistenceService();

            List<BaseCommand> commands = new List<BaseCommand>()
            {
                new LoadTaskCommand(persistenceService),
                new SaveTaskCommand(persistenceService),
                new NewTaskCommand()
            };

            List<UserTask> tasks = new List<UserTask>();

            if (args.Length > 0)
            {
                string firstArg = args[0];

                foreach (BaseCommand command in commands)
                {
                    if (command.CanHandle(firstArg))
                    {
                        command.Process(tasks);

                        break;
                    }
                }
            }
        }
    }
}
