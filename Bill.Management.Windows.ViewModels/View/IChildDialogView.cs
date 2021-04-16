namespace Bill.Management.Windows.ViewModels.View
{
    public interface IChildDialogView : IDialogView
    {
        IPrimaryWindowView Owner { get; }
    }
}