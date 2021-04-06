using System;
using System.Collections.Generic;
using Tasks.Management.Data;
using Tasks.Management.Service;

namespace Tasks.Management.Commands
{
    public sealed class SaveTaskCommand : PersistenceBaseCommand
    {
        public SaveTaskCommand(PersistenceService persistenceService) 
            : base(persistenceService)
        {
        }

        public override void Process(List<UserTask> tasks)
        {
            if (tasks is null)
            {
                return;
            }

            Persistence.Save(tasks);
        }

        protected override string CommandName => "save";
    }
}