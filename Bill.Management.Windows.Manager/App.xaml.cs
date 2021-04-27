using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Bill.Management.Windows.Manager.Factories;
using Bill.Management.Windows.Manager.ViewModels;
using Bill.Management.Windows.Manager.ViewModels.Data;
using Bill.Management.Windows.Manager.Views;
using Bill.Management.Windows.ViewModels;
using Bill.Management.Windows.ViewModels.Factories;
using Bill.Management.Windows.ViewModels.View;
using BillManagement.Imlementations.Data;
using Ninject;
using Ninject.Extensions.Factory;

namespace Bill.Management.Windows.Manager
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            IKernel kernel = new StandardKernel();

            kernel.Bind<IPrimaryWindowView>().To<MainWindow>().InSingletonScope();
            kernel.Bind<UserEditorViewModel>().To<UserEditorViewModel>().InSingletonScope();
            kernel.Bind<IDialogView, IEditorUserView>().To<UserEditorViewWindow>().InTransientScope();
            kernel.Bind<PrimaryMainViewModel>().ToSelf().InSingletonScope();

            kernel.AddCommandFactory();
            kernel.AddDialogFactory();
            kernel.AddDialogService();
            kernel.AddViewModelsFactory();
            kernel.AddFactory<IUserViewModelFactory, UserViewModel, User>();

            IPrimaryWindowView windowView = kernel.Get<IPrimaryWindowView>();

            windowView.DataContext = kernel.Get<PrimaryMainViewModel>();

            windowView.Show();

        }
    }
}
