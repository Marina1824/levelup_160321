using System.ComponentModel;
using BillManagement.Imlementations.Data;

namespace Bill.Management.Windows.Manager.ViewModels.Data
{
    public interface IInvoiceViewModel : INotifyPropertyChanged
    {
        string ShopName { get; set; }

        Invoice Model { get; }
    }
}