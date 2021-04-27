using System.ComponentModel;
using BillManagement.Imlementations.Data;

namespace Bill.Management.Windows.Manager.ViewModels.Data
{
    public interface IUserViewModel : INotifyPropertyChanged
    {
        string FirstName { get; set; }

        User Model { get; }
    }
}