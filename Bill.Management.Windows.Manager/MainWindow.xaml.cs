﻿using System;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Bill.Management.Rest.Service.Client.Connection;
using Bill.Management.Windows.Manager.ViewModels;
using Bill.Management.Windows.ViewModels;
using BillManagement.Core.Abstractions.Data.Results;
using BillManagement.Imlementations.Data;

namespace Bill.Management.Windows.Manager
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            DataContext = new PrimaryMainViewModel();

            InitializeComponent();
        }

        //MVVM

        //Model
        //View
        //ViewModel
    }
}
