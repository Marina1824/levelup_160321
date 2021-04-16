using Bill.Management.Windows.ViewModels.Services.Dialog;

namespace Bill.Management.Windows.ViewModels
{
    public abstract class DialogViewModel : BaseViewModel
    {
        private readonly IDialogService _service;

        protected DialogViewModel(IDialogService service)
        {
            _service = service;
        }
    }
}