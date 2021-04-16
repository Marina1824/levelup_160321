namespace Bill.Management.Windows.ViewModels.View
{
    public interface IDialogView
    {
        object DataContext { get; set; }

        void Show();

        bool? ShowDialog();
    }
}