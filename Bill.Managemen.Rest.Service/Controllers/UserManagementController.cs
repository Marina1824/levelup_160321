using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;
using Bill.Management.Abstractions;
using Bill.Management.Core.Abstractions.Services.Mapper;
using Bill.Management.Data.Transfer;
using Bill.Management.Implementations.Data.Users.Managers;
using BillManagement.Core.Abstractions.Data.Results;
using BillManagement.Imlementations.Data;

namespace Bill.Managemen.Rest.Service.Controllers
{
    [ApiController]
    [Route("v1/users")]
    public class UserManagementController : ControllerBase
    {
        private readonly ILogger<UserManagementController> _logger;
        private readonly IUsersCollectionManager _collectionManager;
        private readonly IMapService _mapService;

        public UserManagementController(
            ILogger<UserManagementController> logger, 
            IUsersCollectionManager collectionManager,
            IMapService mapService)
        {
            _logger = logger;
            _collectionManager = collectionManager;
            _mapService = mapService;
        }

        /// <summary>
        /// Very important method
        /// </summary>
        /// <returns>A operation result <see cref="IOperationResult{TResult}"/></returns>
        [HttpGet]
        public async Task<IOperationResult<IReadOnlyList<User>>> GetAll()
        {
            IOperationResult<IReadOnlyList<User>> result = _collectionManager.GetAllUsers();

            return await Task.FromResult(result);
        }

        [HttpPut]
        public IOperationResult<User> Create([FromBody] User user)
        {
            return _collectionManager.CreateUser(user);
        }

        
        [HttpPost]
        public IOperationResult<User> UpdateUserTextById([FromBody] User user)
        {
            return _collectionManager.UpdateUser(user);
        }
    }
}
