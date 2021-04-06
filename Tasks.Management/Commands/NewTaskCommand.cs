using System.Collections.Generic;
using Tasks.Management.Data;

namespace Tasks.Management.Commands
{
    public sealed class NewTaskCommand : BaseCommand
    {
        public override void Process(List<UserTask> tasks)
        {
            UserTask task = new UserTask();

            System.Console.WriteLine("Enter the name of task:");

            string name = System.Console.ReadLine();

            task.Name = name;

            tasks.Add(task);
        }

        protected override string CommandName => "new";
    }
}