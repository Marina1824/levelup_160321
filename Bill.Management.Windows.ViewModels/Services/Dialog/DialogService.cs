using System;
using Bill.Management.Windows.ViewModels.Factories;
using Bill.Management.Windows.ViewModels.Services.Dialog.Arguments;
using Bill.Management.Windows.ViewModels.View;

namespace Bill.Management.Windows.ViewModels.Services.Dialog
{
    internal sealed class DialogService : IDialogService
    {
        private readonly IPrimaryWindowView _primaryWindowView;
        private readonly ICustomDynamicFactory<IDialogView> _dynamicFactory;
        private int _windowCount = 0;

        public DialogService(
            IPrimaryWindowView primaryWindowView, 
            ICustomDynamicFactory<IDialogView> dynamicFactory)
        {
            _primaryWindowView = primaryWindowView;
            _dynamicFactory = dynamicFactory;
        }

        public event DialogShow OnDialogShow;

        public bool? ShowDialog<TView>()
            where TView : IDialogView
        {
            Notificate();

            IDialogView view = _dynamicFactory.Create<TView>();

            return view.ShowDialog();
        }

        public bool? ShowDialog<TView, TBaseViewModel>(TBaseViewModel viewModel) 
            where TView : IDialogView where TBaseViewModel : BaseViewModel
        {
            Notificate();

            TView view = _dynamicFactory.Create<TView>();
            view.DataContext = viewModel;

            return view.ShowDialog();
        }

        private void Notificate()
        {
            _windowCount += 1;

            OnDialogShow?.Invoke(this, new DialogOpenEventArguments() { Count = _windowCount });
        }
    }
}