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
    [Route("v1/bills")]
    public class InvoiceManagementController : ControllerBase
    {
        private readonly ILogger<UserManagementController> _logger;
        private readonly IInvoiceCollectionManager _collectionManager;
        private readonly IMapService _mapService;

        public InvoiceManagementController(
            ILogger<UserManagementController> logger,
            IInvoiceCollectionManager collectionManager,
            IMapService mapService)
        {
            _logger = logger;
            _collectionManager = collectionManager;
            _mapService = mapService;
        }

        [HttpGet]
        public async Task<IOperationResult<IReadOnlyList<Invoice>>> GetAll()
        {
            IOperationResult<IReadOnlyList<Invoice>> result = _collectionManager.GetAllInvoices();

            return await Task.FromResult(result);
        }

        [HttpPut]
        public IOperationResult<Invoice> CreateInvoice([FromBody] Invoice invoice)
        {
            return _collectionManager.CreateInvoice(invoice);
        }
        
        [HttpPost]
        public IOperationResult<Invoice> UpdateInvoiceById([FromBody] Invoice invoice)
        {
            return _collectionManager.UpdateInvoiceById(invoice);
        }
    }
}
