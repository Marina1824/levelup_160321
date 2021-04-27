using Bill.Management.Windows.ViewModels;
using BillManagement.Imlementations.Data;

namespace Bill.Management.Windows.Manager.ViewModels.Data
{
    public sealed class UserViewModel : BaseViewModel, IUserViewModel
    {
        private readonly User _user;

        public UserViewModel(User argument)
        {
            _user = argument;
        }

        public int Id
        {
            get
            {
                return _user.Id;
            }
            set
            {
                _user.Id = value;

                OnPropertyChanged();
            }
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

        public string LastName
        {
            get
            {
                return _user.LastName;
            }
            set
            {
                _user.LastName = value;

                OnPropertyChanged();
            }
        }

        public string MiddleName
        {
            get
            {
                return _user.MiddleName;
            }
            set
            {
                _user.MiddleName = value;

                OnPropertyChanged();
            }
        }

        public User Model => _user;
    }
}