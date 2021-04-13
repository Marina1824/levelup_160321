using Bill.Management.Core.Abstractions.Data;
using Bill.Management.Core.Abstractions.Data.Repository;
using Bill.Management.Core.Abstractions.Services.Logging;
using Bill.Management.Core.Abstractions.Services.Validation;
using BillManagement.Core.Abstractions.Data;

namespace Bill.Management.Core.Abstractions.Managers
{
    public abstract class CollectionManager<TDataItem, TUniqueIdType> : ICollectionManager<TDataItem, TUniqueIdType>
        where TDataItem : BaseEntity<TUniqueIdType>
        where TUniqueIdType : struct
    {
        private readonly IRepository<TDataItem, TUniqueIdType> _repository;
        private readonly IValidationService<TDataItem> _validationService;
        private readonly ILoggerService _loggerService;

        protected CollectionManager(
            IRepository<TDataItem, TUniqueIdType> repository, 
            IValidationService<TDataItem> validationService,
            ILoggerService loggerService)
        {
            _repository = repository;
            _validationService = validationService;
            _loggerService = loggerService;
        }

        protected IRepository<TDataItem, TUniqueIdType> Repository
        {
            get { return _repository; }
        }

        protected IValidationService<TDataItem> Validation
        {
            get
            {
                return _validationService;
            }
        }

        protected ILoggerService Logger
        {
            get
            {
                return _loggerService;
            }
        }
    }
}