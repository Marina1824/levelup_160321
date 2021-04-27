using Bill.Management.Windows.Manager.ViewModels;
using Bill.Management.Windows.ViewModels.View;

namespace Bill.Management.Windows.Manager.Views
{
    public interface IEditorUserView : IChildDialogView
    {
        object DataContext { get; set; }
    }
}