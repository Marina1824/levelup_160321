using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;
using Bill.Management.Abstractions;
using Bill.Management.Core.Abstractions.Results;
using Bill.Management.Core.Abstractions.Services.Mapper;
using Bill.Management.Data.Transfer;
using Bill.Management.Implementations.Data.Users.Managers;

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
        public IOperationResult<UserTransfer> ReplaceUserById(
            [FromQuery] int id, 
            [FromQuery] string name, 
            [FromBody] UserTransfer user)
        {
            User userModel = _mapService.Map<UserTransfer, User>(user);

            UserTransfer userDto = _mapService.Map<User, UserTransfer>(userModel);

            return new OperationResult<UserTransfer>(user);
        }
    }
}
