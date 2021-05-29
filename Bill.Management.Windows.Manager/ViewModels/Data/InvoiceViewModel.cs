using Bill.Management.Windows.ViewModels;
using BillManagement.Imlementations.Data;

namespace Bill.Management.Windows.Manager.ViewModels.Data
{
    public sealed class InvoiceViewModel : BaseViewModel, IInvoiceViewModel
    {
        private readonly Invoice _invoice;

        public InvoiceViewModel(Invoice argument)
        {
            _invoice = argument;
        }

        public int Id
        {
            get
            {
                return _invoice.Id;
            }
            set
            {
                _invoice.Id = value;

                OnPropertyChanged();
            }
        }

        public string ShopName
        {
            get
            {
                return _invoice.ShopName;
            }
            set
            {
                _invoice.ShopName = value;
                
                OnPropertyChanged();
            }
        }

        public double Sum
        {
            get
            {
                return _invoice.Sum;
            }
            set
            {
                _invoice.Sum = value;

                OnPropertyChanged();
            }
        }

        public string Comment
        {
            get
            {
                return _invoice.Comment;
            }
            set
            {
                _invoice.Comment = value;

                OnPropertyChanged();
            }
        }

        public Invoice Model => _invoice;
    }
}