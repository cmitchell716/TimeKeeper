using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Text;
using TimeKeepers.Views;

namespace TimeKeepers.ViewModels
{
    public class TimeKeeperViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private System.Windows.Controls.UserControl _gui;
        public System.Windows.Controls.UserControl Gui
        {
            get { return _gui; }
            set
            {
                _gui = value;
                OnPropertyChanged();
            }
        }

        public TimeKeeperViewModel()
        {
            Gui = new TimeKeeperView(this) { DataContext = this };
        }


        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
