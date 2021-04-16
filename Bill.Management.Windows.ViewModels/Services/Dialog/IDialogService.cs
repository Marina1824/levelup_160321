using Bill.Management.Windows.ViewModels.View;

namespace Bill.Management.Windows.ViewModels.Services.Dialog
{
    public interface IDialogService
    {
        bool? ShowDialog<TView>()
            where TView : IDialogView;

        bool? ShowDialog<TView, TBaseViewModel>(TBaseViewModel viewModel)
            where TView : IDialogView
            where TBaseViewModel : BaseViewModel;
    }
}