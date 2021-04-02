using System;
using Bill.Management.Core.Abstractions.Commands;
using Bill.Management.Core.Abstractions.Services.Logging;
using Bill.Management.Implementations.Data.Users.Managers;

namespace Bill.Management.Implementations.Commands.Users
{
    internal sealed class ApproveUserRightsCommand : BusinessCommand<object>
    {
        private readonly ILoggerService _loggerService;
        private readonly IUsersCollectionManager _manager;

        public ApproveUserRightsCommand(ILoggerService loggerService, IUsersCollectionManager manager)
        {
            _loggerService = loggerService;
            _manager = manager;
        }

        protected override object Run()
        {
            throw new NotImplementedException();
        }
    }
}