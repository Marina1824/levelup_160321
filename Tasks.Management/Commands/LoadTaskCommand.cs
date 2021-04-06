using System.Collections.Generic;
using Tasks.Management.Data;
using Tasks.Management.Service;

namespace Tasks.Management.Commands
{
    public sealed class LoadTaskCommand : PersistenceBaseCommand
    {
        public LoadTaskCommand(PersistenceService persistenceService) 
            : base(persistenceService)
        {
        }

        public override void Process(List<UserTask> tasks)
        {
            List<UserTask> restoredTasks = Persistence.Load();

            if (tasks is null)
            {
                tasks = restoredTasks;

                return;
            }

            foreach (UserTask task in restoredTasks)
            {
                tasks.Add(task);
            }
        }

        protected override string CommandName => "load";
    }
}