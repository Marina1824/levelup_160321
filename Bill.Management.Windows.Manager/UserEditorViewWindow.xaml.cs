using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Bill.Management.Windows.Manager.ViewModels;
using Bill.Management.Windows.Manager.Views;
using Bill.Management.Windows.ViewModels.View;

namespace Bill.Management.Windows.Manager
{
    /// <summary>
    /// Interaction logic for UserEditorViewWindow.xaml
    /// </summary>
    public partial class UserEditorViewWindow : Window, IEditorUserView
    {
        public UserEditorViewWindow(IPrimaryWindowView view)
        {
            base.Owner  = view as Window;

            InitializeComponent();
        }

        public IPrimaryWindowView Owner => base.Owner as IPrimaryWindowView;

        public object DataContext
        {
            get
            {
                return base.DataContext as UserEditorViewModel;
            }
            set
            {
                (value as UserEditorViewModel).OnViewClose += ValueOnOnViewClose;

                base.DataContext = value;
            }
        }

        private void ValueOnOnViewClose(object sender, EventArgs args)
        {
            DialogResult = true;

            Close();

            (DataContext as UserEditorViewModel).OnViewClose -= ValueOnOnViewClose;
        }
    }
}
