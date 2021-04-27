using System;
using System.Collections.Generic;
using System.Windows.Input;
using Bill.Management.Windows.ViewModels;
using Bill.Management.Windows.ViewModels.Factories;
using BillManagement.Imlementations.Data;

namespace Bill.Management.Windows.Manager.ViewModels
{
    public delegate void ViewClose(object sender, EventArgs args);

    public sealed class UserEditorViewModel : BaseViewModel
    {
        private User _user;
        private string _comment;
        private string _firstName;
        private string _lastName;
        private string _middleName;
        private bool? _result;

        public event ViewClose OnViewClose;

        public UserEditorViewModel(ICommandFactory commandFactory)
        {
            OkCommand = commandFactory.Create("Ok_User_Editor_Command", Execute);
        }

        private void Execute(object obj)
        {
            OnViewClose?.Invoke(this, EventArgs.Empty);
        }

        public ICommand OkCommand { get; }

        public string Comment
        {
            get => _comment;
            set
            {
                _comment = value;

                OnPropertyChanged();
            }
        }

        public string FirstName
        {
            get => _firstName;
            set
            {
                _firstName = value;

                OnPropertyChanged();
            }
        }

        public string LastName
        {
            get => _lastName;
            set
            {
                _lastName = value;

                OnPropertyChanged();
            }
        }

        public string MiddleName
        {
            get => _middleName;
            set
            {
                _middleName = value;

                OnPropertyChanged();
            }
        }

        internal User User
        {
            get => _user;
            set
            {
                _user = value;

                _comment = value.Text;
                _firstName = value.FirstName;
                _lastName = value.LastName;
                _middleName = value.MiddleName;
                
                OnPropertiesChanged(
                    nameof(Comment), 
                    nameof(FirstName), 
                    nameof(LastName), 
                    nameof(MiddleName));
            }
        }
    }
}