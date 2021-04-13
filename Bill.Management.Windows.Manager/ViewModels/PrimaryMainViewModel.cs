using System.Collections.Generic;
using System.Windows.Input;
using Bill.Management.Rest.Service.Client.Connection;
using Bill.Management.Windows.ViewModels;
using Bill.Management.Windows.ViewModels.Commands;
using BillManagement.Core.Abstractions.Data.Results;
using BillManagement.Imlementations.Data;
using Nito.AsyncEx.Synchronous;

namespace Bill.Management.Windows.Manager.ViewModels
{
    public sealed class PrimaryMainViewModel : MainViewModel
    {
        private ICommand _fillGridCommand;
        private IReadOnlyList<User> _users;

        public PrimaryMainViewModel()
        {
            FillGridCommand = new RelayCommand(x => FillUserGridByService());
        }

        public ICommand FillGridCommand
        {
            get => _fillGridCommand;
            set => _fillGridCommand = value;
        }

        public IReadOnlyList<User> Users
        {
            get => _users;
            set
            {
                _users = value;
                
                OnPropertyChanged();
            }
        }

        private void FillUserGridByService()
        {
            IBillManagementClient client = ClientFactory.Create("http://localhost:58755");

            IOperationResult<IReadOnlyList<User>> result = client.GetClients().WaitAndUnwrapException();

            if (result.Succeed)
            {
                Users = result.Result;
            }
        }
    }
}