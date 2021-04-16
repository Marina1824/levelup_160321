using Bill.Management.Windows.ViewModels.Factories;
using Bill.Management.Windows.ViewModels.View;

namespace Bill.Management.Windows.ViewModels.Services.Dialog
{
    internal sealed  class DialogService : IDialogService
    {
        private readonly IPrimaryWindowView _primaryWindowView;
        private readonly ICustomDynamicFactory<IDialogView> _dynamicFactory;

        public DialogService(IPrimaryWindowView primaryWindowView, ICustomDynamicFactory<IDialogView> dynamicFactory)
        {
            _primaryWindowView = primaryWindowView;
            _dynamicFactory = dynamicFactory;
        }

        public bool? ShowDialog<TView>()
            where TView : IDialogView
        {
            IDialogView view = _dynamicFactory.Create<TView>();

            return view.ShowDialog();
        }
    }
}