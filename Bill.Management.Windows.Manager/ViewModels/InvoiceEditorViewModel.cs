using System;
using System.Collections.Generic;
using System.Windows.Input;
using Bill.Management.Windows.ViewModels;
using Bill.Management.Windows.ViewModels.Factories;
using BillManagement.Imlementations.Data;

namespace Bill.Management.Windows.Manager.ViewModels
{
    public delegate void ViewInvoiceClose(object sender, EventArgs args);

    public sealed class InvoiceEditorViewModel : BaseViewModel
    {
        private Invoice _invoice;
        private string _comment;
        private double _sum;
        private string _shopName;
        private bool? _result;

        public event ViewInvoiceClose OnViewClose;

        public InvoiceEditorViewModel(ICommandFactory commandFactory)
        {
            OkCommand = commandFactory.Create("Ok_Invoice_Editor_Command", Execute);
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

        public double Sum
        {
            get => _sum;
            set
            {
                _sum = value;

                OnPropertyChanged();
            }
        }

        public string ShopName
        {
            get => _shopName;
            set
            {
                _shopName = value;

                OnPropertyChanged();
            }
        }
        
        internal Invoice Invoice
        {
            get => _invoice;
            set
            {
                _invoice = value;

                _comment = value.Comment;
                _sum = value.Sum;
                _shopName = value.ShopName;
                
                OnPropertiesChanged(
                    nameof(Comment), 
                    nameof(Sum), 
                    nameof(ShopName));
            }
        }
    }
}