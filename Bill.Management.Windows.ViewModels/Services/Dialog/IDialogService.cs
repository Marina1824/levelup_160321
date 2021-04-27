using System;
using Bill.Management.Windows.ViewModels.Services.Dialog.Arguments;
using Bill.Management.Windows.ViewModels.View;

namespace Bill.Management.Windows.ViewModels.Services.Dialog
{
    public delegate void DialogShow(object sender, DialogOpenEventArguments eventArgs);

    public interface IDialogService
    {
        event DialogShow OnDialogShow;

        bool? ShowDialog<TView>()
            where TView : IDialogView;

        bool? ShowDialog<TView, TBaseViewModel>(TBaseViewModel viewModel)
            where TView : IDialogView
            where TBaseViewModel : BaseViewModel;
    }
}