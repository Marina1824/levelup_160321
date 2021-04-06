using Tasks.Management.Service;

namespace Tasks.Management.Commands
{
    public abstract class PersistenceBaseCommand : BaseCommand
    {
        private readonly PersistenceService _persistenceService;

        protected PersistenceBaseCommand(PersistenceService persistenceService)
        {
            _persistenceService = persistenceService;
        }

        protected PersistenceService Persistence => _persistenceService;
    }
}