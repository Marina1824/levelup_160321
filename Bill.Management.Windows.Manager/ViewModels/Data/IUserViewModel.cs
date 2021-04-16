using System.ComponentModel;

namespace Bill.Management.Windows.Manager.ViewModels.Data
{
    public interface IUserViewModel : INotifyPropertyChanged
    {
        string FirstName { get; set; }
    }
}