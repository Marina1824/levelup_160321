using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bill.Management.Abstractions;
using Bill.Management.Core.Abstractions.Results;
using Bill.Management.Implementations.Data.Users.Managers;
using Tasks.Management.Commands;
using Tasks.Management.Data;
using Tasks.Management.Service;

namespace Bill.Managemen.Rest.Service.Controllers
{
    [ApiController]
    [Route("v1/users")]
    public class UserManagementController : ControllerBase
    {

        private readonly ILogger<UserManagementController> _logger;
        private readonly IUsersCollectionManager _collectionManager;

        public UserManagementController(
            ILogger<UserManagementController> logger, 
            IUsersCollectionManager collectionManager)
        {
            _logger = logger;
            _collectionManager = collectionManager;
        }

        [HttpGet]
        public IOperationResult<IReadOnlyList<User>> Bar()
        {
            return _collectionManager.GetAllUsers();
        }

        [HttpGet]
        [Route("tasks")]
        public IEnumerable<UserTask> GetTasks()
        {
            List<UserTask> tasks = new List<UserTask>();

            new LoadTaskCommand(new PersistenceService()).Process(tasks);

            return tasks;
        }
    }
}
