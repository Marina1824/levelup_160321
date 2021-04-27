using Bill.Management.Windows.Manager.ViewModels.Data;
using Bill.Management.Windows.ViewModels.Factories;
using BillManagement.Imlementations.Data;

namespace Bill.Management.Windows.Manager.Factories
{
    public interface IUserViewModelFactory : IDynamicFactory<UserViewModel, User>
    {
    }
}