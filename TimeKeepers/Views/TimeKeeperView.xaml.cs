using System;
using System.Collections.Generic;
using System.Text;
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

namespace TimeKeepers.Views
{
    /// <summary>
    /// Interaction logic for TimeKeeperView.xaml
    /// </summary>
    public partial class TimeKeeperView : UserControl
    {
        TimeKeeperViewModel viewModel;
        public TimeKeeperView(TimeKeeperViewModel vm)
        {
            viewModel = viewModel;
            InitializeComponent();
        }

    }
}
