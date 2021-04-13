using Bill.Management.Abstractions;
using Bill.Management.Core.Abstractions.Services.Validation;
using BillManagement.Imlementations.Data;
using FluentValidation;

namespace Bill.Management.Implementations.Data.Users.Validators
{
    internal sealed class UserValidationService : FluentValidationService<User>
    {
        public UserValidationService()
        {
            RuleFor(x => x.FirstName).NotEmpty().WithMessage("Имя не может быть пустым");
            RuleFor(x => x.MiddleName).NotEmpty().WithMessage("Отчество не может быть пустым");
            RuleFor(x => x.LastName).NotEmpty().WithMessage("Фамилия не может быть пустой");
        }
    }
}