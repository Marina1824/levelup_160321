using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Bill.Management.Rest.Service.Client.Connection;
using Bill.Management.Windows.Manager.Factories;
using Bill.Management.Windows.Manager.ViewModels.Data;
using Bill.Management.Windows.Manager.Views;
using Bill.Management.Windows.ViewModels;
using Bill.Management.Windows.ViewModels.Factories;
using Bill.Management.Windows.ViewModels.Services.Dialog;
using BillManagement.Core.Abstractions.Data.Results;
using BillManagement.Imlementations.Data;
using Nito.AsyncEx.Synchronous;

namespace Bill.Management.Windows.Manager.ViewModels
{
    public sealed class PrimaryMainViewModel : MainViewModel
    {
        private IBillManagementClient _client = ClientFactory.Create("http://localhost:5000");
        private readonly IDialogService _dialogService;
        private readonly ICustomDynamicFactory<BaseViewModel> _viewModeFactory;
        private readonly IUserViewModelFactory _userViewModelFactory;
        private readonly IInvoiceViewModelFactory _invoiceViewModelFactory;
        private readonly ObservableCollection<IUserViewModel> _users = new ObservableCollection<IUserViewModel>();
        private readonly ObservableCollection<IInvoiceViewModel> _invoices = new ObservableCollection<IInvoiceViewModel>();
        private IUserViewModel _currentUser;
        private IInvoiceViewModel _currentInvoice;

        public PrimaryMainViewModel(
            ICommandFactory commandFactory,
            IDialogService dialogService, 
            ICustomDynamicFactory<BaseViewModel> viewModeFactory,
            IUserViewModelFactory userViewModelFactory,
            IInvoiceViewModelFactory invoiceViewModelFactory)
        {
            _dialogService = dialogService;
            _viewModeFactory = viewModeFactory;
            _userViewModelFactory = userViewModelFactory;
            _invoiceViewModelFactory = invoiceViewModelFactory;

            RefreshCommand = commandFactory.Create("Refresh_command", x => Refresh());
            CreateNewUserCommand = commandFactory.Create("Create_User_command", x => CreateNewUser());
            EditCurrentUserCommand = commandFactory.Create("Edit_Current_User_command", x => EditCurrentUser());

            RefreshInvoiceCommand = commandFactory.Create("Refresh_Invoice_command", x => RefreshInvoice());
            CreateNewInvoiceCommand = commandFactory.Create("Create_Invoice_command", x => CreateNewInvoice());
            EditCurrentInvoiceCommand = commandFactory.Create("Edit_Current_Invoice_command", x => EditCurrentInvoice());
        }

        public ICommand RefreshCommand
        {
            get;
        }

        public ICommand CreateNewUserCommand
        {
            get;
        }

        public ICommand EditCurrentUserCommand
        {
            get;
        }

        public ICommand RefreshInvoiceCommand
        {
            get;
        }

        public ICommand CreateNewInvoiceCommand
        {
            get;
        }

        public ICommand EditCurrentInvoiceCommand
        {
            get;
        }

        public ObservableCollection<IUserViewModel> Users
        {
            get => _users;
        }

        public ObservableCollection<IInvoiceViewModel> Invoices
        {
            get => _invoices;
        }

        public IUserViewModel CurrentUser
        {
            get => _currentUser;
            set
            {
                _currentUser = value;

                OnPropertyChanged();
            }
        }

        public IInvoiceViewModel CurrentInvoice
        {
            get => _currentInvoice;
            set
            {
                _currentInvoice = value;

                OnPropertyChanged();
            }
        }

        private void Refresh()
        {
            IOperationResult<IReadOnlyList<User>> result = _client.GetClients().WaitAndUnwrapException();

            if (result.Succeed)
            {
                _users.Clear();

                foreach (User user in result.Result)
                {
                    IUserViewModel viewModel = _userViewModelFactory.Create(user);

                    _users.Add(viewModel);
                }

            }
        }

        private void CreateNewUser()
        {
            User user = new User();
            user.Id = new Random().Next(10, 120);
            user.IsDeleted = false;

            if (RunEdit(user))
            {
                _client.CreateUser(user).WaitAndUnwrapException();
            }
        }

        private void EditCurrentUser()
        {
            if (CurrentUser is null || CurrentUser.Model is null)
            {
                return;
            }

            if (RunEdit(CurrentUser.Model))
            {
                _client.UpdateUser(CurrentUser.Model).WaitAndUnwrapException();
            }
        }


        private bool RunEdit(User user)
        {
            if (user is null)
            {

                return false;
            }

            UserEditorViewModel editorViewModel = _viewModeFactory.Create<UserEditorViewModel>();

            editorViewModel.User = user;

            bool? result = _dialogService.ShowDialog<IEditorUserView, UserEditorViewModel>(editorViewModel);

            if (result.HasValue && result.Value)
            {
                user.FirstName = editorViewModel.FirstName;
                user.LastName = editorViewModel.LastName;
                user.MiddleName = editorViewModel.MiddleName;
                user.Text = editorViewModel.Comment;

                return true;
            }

            return false;
        }
        
        private void RefreshInvoice()
        {
            IOperationResult<IReadOnlyList<Invoice>> result = _client.GetInvoices().WaitAndUnwrapException();

            if (result.Succeed)
            {
                _invoices.Clear();

                foreach (Invoice invoice in result.Result)
                {
                    IInvoiceViewModel viewModel = _invoiceViewModelFactory.Create(invoice);

                    _invoices.Add(viewModel);
                }

            }
        }

        private void CreateNewInvoice()
        {
            Invoice invoice = new Invoice();
            invoice.Id = new Random().Next(10, 120);
            invoice.IsDeleted = false;

            if (RunEditInvoice(invoice))
            {
                _client.CreateInvoice(invoice).WaitAndUnwrapException();
            }
        }

        private void EditCurrentInvoice()
        {
            if (CurrentInvoice is null || CurrentInvoice.Model is null)
            {
                return;
            }

            if (RunEditInvoice(CurrentInvoice.Model))
            {
                _client.UpdateInvoiceById(CurrentInvoice.Model).WaitAndUnwrapException();
            }
        }


        private bool RunEditInvoice(Invoice invoice)
        {
            if (invoice is null)
            {

                return false;
            }

            InvoiceEditorViewModel editorViewModel = _viewModeFactory.Create<InvoiceEditorViewModel>();

            editorViewModel.Invoice = invoice;

            bool? result = _dialogService.ShowDialog<IEditorInvoiceView, InvoiceEditorViewModel>(editorViewModel);

            if (result.HasValue && result.Value)
            {
                invoice.ShopName = editorViewModel.ShopName;
                invoice.Sum = editorViewModel.Sum;
                invoice.Comment = editorViewModel.Comment;

                return true;
            }

            return false;
        }
    }
}