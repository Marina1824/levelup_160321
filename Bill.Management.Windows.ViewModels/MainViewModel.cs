using System.Windows.Input;

namespace Bill.Management.Windows.ViewModels
{
    public abstract class MainViewModel : BaseViewModel
    {
        private string _title = "Bill Management System";

        public string Title
        {
            get
            {
                return _title;
            }
            set
            {
                _title = value;

                OnPropertyChanged();
            }
        }


    }
}