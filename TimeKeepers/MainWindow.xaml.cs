using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using TimeKeepers.ViewModels;

namespace TimeKeepers
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public TimeKeeperViewModel ViewModel;
        public MainWindow()
        {
            InitializeComponent();
            ViewModel = new TimeKeeperViewModel();
            this.DataContext = ViewModel;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            // this is for demo purposes only, to make it easier
            // to get up and running
            ViewModel.ctx.Database.EnsureCreated();

            // load the entities into EF Core
            ViewModel.ctx.Persons.Load();

        }

        protected override void OnClosing(CancelEventArgs e)
        {
            // clean up database connections
            ViewModel.ctx.Dispose();
            base.OnClosing(e);
        }
    }
}
