using Bill.Management.Windows.ViewModels;

namespace Bill.Management.Windows.Manager.ViewModels
{
    public class ChildViewModel : BaseViewModel
    {
        private string _someText;

        public string SomeText
        {
            get => _someText;
            set
            {
                _someText = value;
                
                OnPropertyChanged();
            }
        }
    }
}