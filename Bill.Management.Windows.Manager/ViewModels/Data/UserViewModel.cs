using Bill.Management.Windows.ViewModels;
using BillManagement.Imlementations.Data;

namespace Bill.Management.Windows.Manager.ViewModels.Data
{
    public sealed class UserViewModel : BaseViewModel, IUserViewModel
    {
        private readonly User _user;

        public UserViewModel(User user)
        {
            _user = user;
        }

        public string FirstName
        {
            get
            {
                return _user.FirstName;
            }
            set
            {
                _user.FirstName = value;
                
                OnPropertyChanged();
            }
        }
    }
}