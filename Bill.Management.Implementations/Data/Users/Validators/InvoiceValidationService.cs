using Bill.Management.Abstractions;
using Bill.Management.Core.Abstractions.Services.Validation;
using BillManagement.Imlementations.Data;
using FluentValidation;

namespace Bill.Management.Implementations.Data.Users.Validators
{
    internal sealed class InvoiceValidationService : FluentValidationService<Invoice>
    {
        public InvoiceValidationService()
        {
            RuleFor(x => x.ShopName).NotEmpty().WithMessage("Имя магазина не может быть пустым");
            RuleFor(x => x.Sum).NotEmpty().WithMessage("Сумма не может быть пустой");
        }
    }
}