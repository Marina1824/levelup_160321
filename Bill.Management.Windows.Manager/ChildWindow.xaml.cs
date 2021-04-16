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
using Bill.Management.Windows.ViewModels.View;

namespace Bill.Management.Windows.Manager
{
    /// <summary>
    /// Interaction logic for ChildWindow.xaml
    /// </summary>
    public partial class ChildWindow : Window, IChildDialogView
    {
        public ChildWindow(IPrimaryWindowView view)
        {
            base.Owner  = view as Window;

            InitializeComponent();
        }

        public IPrimaryWindowView Owner => base.Owner as IPrimaryWindowView;
    }
}
