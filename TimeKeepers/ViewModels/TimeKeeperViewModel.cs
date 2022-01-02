using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows;
using System.Windows.Input;
using TimeKeepers.Models;
using TimeKeepers.Views;

namespace TimeKeepers.ViewModels
{
    public class TimeKeeperViewModel : INotifyPropertyChanged
    {
        #region Properties
        private string password = "pikehomecoming";
        public HocoContext ctx;
        public event PropertyChangedEventHandler PropertyChanged;
        private string _displayStudentText;
        public string DisplayStudentText
        {
            get { return _displayStudentText; }
            set
            {
                _displayStudentText = value;
                OnPropertyChanged();
            }
        }
        private Visibility _isViewStudent = Visibility.Collapsed;
        public Visibility IsViewStudent
        {
            get { return _isViewStudent; }
            set
            {
                _isViewStudent = value;
                OnPropertyChanged();
            }
        }
        private Visibility _isNewUser = Visibility.Collapsed;
        public Visibility IsNewUser
        {
            get { return _isNewUser; }
            set
            {
                _isNewUser = value;
                OnPropertyChanged();
            }
        }
        private Visibility _isSignIn = Visibility.Collapsed;
        public Visibility IsSignIn
        {
            get { return _isSignIn; }
            set
            {
                _isSignIn = value;
                OnPropertyChanged();
            }
        }
        private Visibility _isSignOut = Visibility.Collapsed;
        public Visibility IsSignOut
        {
            get { return _isSignOut; }
            set
            {
                _isSignOut = value;
                OnPropertyChanged();
            }
        }
        private Visibility _isAdmin = Visibility.Collapsed;
        public Visibility IsAdmin
        {
            get { return _isAdmin; }
            set
            {
                _isAdmin = value;
                OnPropertyChanged();
            }
        }
        private Visibility _fullAdmin = Visibility.Collapsed;
        public Visibility FullAdmin
        {
            get { return _fullAdmin; }
            set
            {
                _fullAdmin = value;
                OnPropertyChanged();
            }
        }
        private string _newId;
        public string NewId
        {
            get { return _newId; }
            set
            {
                _newId = value;
                OnPropertyChanged();
            }
        }
        private string _newName;
        public string NewName
        {
            get { return _newName; }
            set
            {
                _newName = value;
                OnPropertyChanged();
            }
        }
        private bool _isNewPike;
        public bool IsNewPike
        {
            get { return _isNewPike; }
            set
            {
                _isNewPike = value;
                OnPropertyChanged();
            }
        }
        private string _newUserStatus;
        public string NewUserStatus
        {
            get { return _newUserStatus; }
            set
            {
                _newUserStatus = value;
                OnPropertyChanged();
            }
        }
        private string _inId;
        public string InId
        {
            get { return _inId; }
            set
            {
                _inId = value;
                OnPropertyChanged();
            }
        }
        private string _inStatus;
        public string InStatus
        {
            get { return _inStatus; }
            set
            {
                _inStatus = value;
                OnPropertyChanged();
            }
        }
        private string _outId;
        public string OutId
        {
            get { return _outId; }
            set
            {
                _outId = value;
                OnPropertyChanged();
            }
        }
        private string _outStatus;
        public string OutStatus
        {
            get { return _outStatus; }
            set
            {
                _outStatus = value;
                OnPropertyChanged();
            }
        }
        private string _viewId;
        public string ViewId
        {
            get { return _viewId; }
            set
            {
                _viewId = value;
                OnPropertyChanged();
            }
        }
        private string _checkPassword;
        public string CheckPassword
        {
            get { return _checkPassword; }
            set
            {
                _checkPassword = value;
                OnPropertyChanged();
            }
        }
        private string _adminStatus;
        public string AdminStatus
        {
            get { return _adminStatus; }
            set
            {
                _adminStatus = value;
                OnPropertyChanged();
            }
        }
        private string _deleteId;
        public string DeleteId
        {
            get { return _deleteId; }
            set
            {
                _deleteId = value;
                OnPropertyChanged();
            }
        }
        private string _addHoursId;
        public string AddHoursId
        {
            get { return _addHoursId; }
            set
            {
                _addHoursId = value;
                OnPropertyChanged();
            }
        }
        private string _addHoursHours;
        public string AddHoursHours
        {
            get { return _addHoursHours; }
            set
            {
                _addHoursHours = value;
                OnPropertyChanged();
            }
        }
        private DateTime _reportStart;
        public DateTime ReportStart
        {
            get { return _reportStart; }
            set
            {
                _reportStart = value;
                OnPropertyChanged();
            }
        }
        private DateTime _reportEnd;
        public DateTime ReportEnd
        {
            get { return _reportEnd; }
            set
            {
                _reportEnd = value;
                OnPropertyChanged();
            }
        }
        private bool _reportPike;
        public bool ReportPike
        {
            get { return _reportPike; }
            set
            {
                _reportPike = value;
                OnPropertyChanged();
            }
        }
        private string _fullAdminStatus;
        public string FullAdminStatus
        {
            get { return _fullAdminStatus; }
            set
            {
                _fullAdminStatus = value;
                OnPropertyChanged();
            }
        }
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
        #endregion

        public TimeKeeperViewModel()
        {
            Gui = new TimeKeeperView(this) { DataContext = this };
            ctx = new HocoContext();
        }


        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        private void RefreshInputs()
        {
            NewId = "";
            NewName = "";
            IsNewPike = false;
            InId = "";
            OutId = "";
            ViewId = "";
            CheckPassword = "";
            DeleteId = "";
            AddHoursHours = "";
            AddHoursId = "";
            ReportEnd = DateTime.Today;
            ReportStart = DateTime.Today;
            ReportPike = false;
        }

        public ICommand AddPerson
        {
            get
            {
                Action actionToExecute = new Action(async () =>
                {
                    if (NewId == "" || NewId == null)
                        NewUserStatus = "New user must have an Id";
                    else if (NewId.Length != 8)
                        NewUserStatus = "New user Id must contain 8 characters";
                    else if (ctx.Persons.Find(NewId) != null)
                        NewUserStatus = "User with that Id already exists";
                    else if (NewName == "" || NewName == null)
                        NewUserStatus = "New user must have a name";
                    else
                    {
                        var newUser = new Person() { Name = NewName, Id = NewId, IsPike = IsNewPike};
                        ctx.Persons.Add(newUser);
                        ctx.SaveChanges();                        
                        NewUserStatus = $"{newUser.Name} was created successfully";
                        RefreshInputs();
                        ctx.Persons.Load();
                    }                    
                });

                return new ViewModelDelegateCommand(actionToExecute);
            }                      
        }

        public ICommand ClockIn
        {
            get
            {
                Action actionToExecute = new Action(async () =>
                {
                    if (InId == "" || InId == null)
                        InStatus = "Id not valid";
                    else if (InId.Length != 8)
                        InStatus = "Id not valid";
                    else if (ctx.Persons.Find(InId) == null)
                        InStatus = "User with that Id does not exists";
                    else
                    {
                        var person = ctx.Persons.Single(b => b.Id == InId);
                        Timecard newTimecard;
                        if (person.Records == null)
                        {
                            newTimecard = new Timecard() { Person = person, Id = $"{person.Id}1" };
                        }
                        else
                        {
                            if (person.Records.Count() > 0)
                            {
                                if (person.Records.Last().Done == false)
                                {
                                    person.Records.Last().Hours = 0.0;
                                    person.Records.Last().Done = true;
                                }
                            }
                            newTimecard = new Timecard() { Person = person, Id = $"{person.Id}{person.Records.Count() + 1}" };
                        }                       
                        newTimecard.Begin();
                        //person.Records.Add(newTimecard);
                        ctx.Timecards.Add(newTimecard);
                        ctx.SaveChanges();
                        RefreshInputs();
                        InStatus = $"{person.Name} was clocked in at {newTimecard.Start.TimeOfDay.ToString().Substring(0, 8)}"; 
                    }
                   
                });

                return new ViewModelDelegateCommand(actionToExecute);
            }           
        }

        public ICommand ClockOut
        {
            get
            {
                Action actionToExecute = new Action(async () =>
                {
                    if (OutId == "" || OutId == null)
                        OutStatus = "Id not valid";
                    else if (OutId.Length != 8)
                        OutStatus = "Id not valid";
                    else if (ctx.Persons.Find(OutId) == null)
                        OutStatus = "User with that Id does not exists";
                    else
                    {
                        var person = ctx.Persons.Single(b => b.Id == OutId);
                        if(person.Records != null)
                        {
                            if (person.Records.Count() > 0)
                            {
                                if (person.Records.Last().Done == false)
                                {
                                    person.Records.Last().Close();
                                    ctx.SaveChanges();
                                }
                                RefreshInputs();
                                OutStatus = $"{person.Name} was clocked out at {person.Records.Last().End.TimeOfDay.ToString().Substring(0, 8)}";
                            }
                            else OutStatus = $"{person.Name} had not clocked in";
                        }
                        else OutStatus = $"{person.Name} had not clocked in";
                    }                   
                });

                return new ViewModelDelegateCommand(actionToExecute);
            }           
        }

        public ICommand DisplayStudent
        {
            get
            {
                Action actionToExecute = new Action(async () =>
                {
                    if (ViewId == "" || ViewId == null)
                        DisplayStudentText = "Id not valid";
                    else if (ViewId.Length != 8)
                        DisplayStudentText = "Id not valid";
                    else if (ctx.Persons.Find(ViewId) == null)
                        DisplayStudentText = "User with that Id does not exists";
                    else
                    {
                        DisplayStudentText = "";
                        var person = ctx.Persons.Single(b => b.Id == ViewId);
                        DisplayStudentText += $"{person.Name}\n";
                        if(person.Records != null)
                        {
                            if (person.Records.Count() == 0)
                                DisplayStudentText = "No records to display\n";
                            foreach (var card in person.Records)
                            {
                                DisplayStudentText += card.ToString();
                            }
                            RefreshInputs();
                        }
                        else DisplayStudentText = "No records to display\n";

                    }
                    
                });

                return new ViewModelDelegateCommand(actionToExecute);
            }            
        }

        public ICommand ConfirmPassword
        {
            get
            {
                Action actionToExecute = new Action(async () =>
                {
                    if (CheckPassword == password)
                    {
                        FullAdmin = Visibility.Visible;
                        IsAdmin = Visibility.Collapsed;
                        RefreshInputs();
                    }
                    else AdminStatus = "Incorrect Password";
                });
                return new ViewModelDelegateCommand(actionToExecute);
            }
        }

        public ICommand DeleteUser
        {
            get
            {
                Action actionToExecute = new Action(async () =>
                {
                    if (DeleteId == "" || DeleteId == null)
                        FullAdminStatus = "Id not valid";
                    else if (DeleteId.Length != 8)
                        FullAdminStatus = "Id not valid";
                    else if (ctx.Persons.Find(DeleteId) == null)
                        FullAdminStatus = "User with that Id does not exists";
                    else
                    {
                        var person = ctx.Persons.Single(b => b.Id == DeleteId);
                        foreach(var record in person.Records)
                        {
                            ctx.Remove(record);
                        }
                        FullAdminStatus = $"{person.Name} has been removed from the database";
                        ctx.Remove(person);
                        ctx.SaveChanges();
                        RefreshInputs();
                    }
                });
                return new ViewModelDelegateCommand(actionToExecute);
            }
        }

        public ICommand AddHours
        {
            get
            {
                Action actionToExecute = new Action(async () =>
                {
                    if (AddHoursId == "" || AddHoursId == null)
                        FullAdminStatus = "Id not valid";
                    else if (AddHoursId.Length != 8)
                        FullAdminStatus = "Id not valid";
                    else if (ctx.Persons.Find(AddHoursId) == null)
                        FullAdminStatus = "User with that Id does not exists";
                    else if (AddHoursHours == "" || AddHoursHours == null)
                        FullAdminStatus = "Hours not valid";
                    else
                    {
                        try
                        {
                            double hours = double.Parse(AddHoursHours);
                            var person = ctx.Persons.Single(b => b.Id == AddHoursId);
                            var newTimecard = new Timecard() { Person = person, Id = $"{person.Id}{person.Records.Count() + 1}", Hours = hours, Done = true, Start = DateTime.Now};
                            person.Records.Add(newTimecard);
                            ctx.Timecards.Add(newTimecard);
                            ctx.SaveChanges();
                            RefreshInputs();
                            FullAdminStatus = $"{person.Name} has been given {hours} hours";
                        }
                        catch(Exception e)
                        {
                            FullAdminStatus = "Hours not valid";
                        }
                    }
                });

                return new ViewModelDelegateCommand(actionToExecute);
            }
        }

        public ICommand CreateReport
        {
            get
            {
                Action actionToExecute = new Action(async () =>
                {
                    if (!Directory.Exists(".\\Reports"))
                        Directory.CreateDirectory(".\\Reports");
                    var fileName = $".\\Reports\\{DateTime.Now.ToString().Replace("/","-").Replace(" ","").Replace(":","_")}.txt";
                    using (FileStream fs = File.Create(fileName))
                    {
                        using(var sr = new StreamWriter(fs))
                        {
                            if (ReportPike)
                                sr.Write($"Showing all Pike hours between {ReportStart.Date.ToString().Substring(0, 9)} and {ReportEnd.Date.ToString().Substring(0, 9)}\n\n");
                            else sr.Write($"Showing all non Pike hours between {ReportStart.Date.ToString().Substring(0, 9)} and {ReportEnd.Date.ToString().Substring(0, 9)}\n\n");

                            ctx.Persons.Load();
                            foreach(var person in ctx.Persons)
                            {
                                double totalhours = person.GetHours(ReportStart, ReportEnd);
                                if(ReportPike == person.IsPike && totalhours > 0.0)
                                {
                                    sr.Write($"{person.Name}: {totalhours} hours\n");
                                }

                            }
                        }
                    }
                    RefreshInputs();
                    FullAdminStatus = "Report Created";
                });

                return new ViewModelDelegateCommand(actionToExecute);
            }
        }

        public ICommand NewUser
        {
            get
            {
                Action actionToExecute = new Action(async () =>
                {
                    IsNewUser = Visibility.Visible;
                    IsSignIn = Visibility.Collapsed; IsViewStudent = Visibility.Collapsed; IsSignOut = Visibility.Collapsed; IsAdmin = Visibility.Collapsed; FullAdmin = Visibility.Collapsed;
                });

                return new ViewModelDelegateCommand(actionToExecute);
            }
        }

        public ICommand ViewStudent
        {
            get
            {
                Action actionToExecute = new Action(async () =>
                {
                    DisplayStudentText = "";
                    IsViewStudent = Visibility.Visible;
                    IsNewUser = Visibility.Collapsed; IsSignIn = Visibility.Collapsed; IsSignOut = Visibility.Collapsed; IsAdmin = Visibility.Collapsed; FullAdmin = Visibility.Collapsed;
                });

                return new ViewModelDelegateCommand(actionToExecute);
            }                   
        }

        public ICommand SignIn
        {
            get
            {
                Action actionToExecute = new Action(async () =>
                {
                    IsSignIn = Visibility.Visible;
                    IsNewUser = Visibility.Collapsed; IsViewStudent = Visibility.Collapsed; IsSignOut = Visibility.Collapsed; IsAdmin = Visibility.Collapsed; FullAdmin = Visibility.Collapsed;
                });

                return new ViewModelDelegateCommand(actionToExecute);
            }
        }

        public ICommand SignOut
        {
            get
            {
                Action actionToExecute = new Action(async () =>
                {
                    IsSignOut = Visibility.Visible;
                    IsNewUser = Visibility.Collapsed; IsViewStudent = Visibility.Collapsed; IsSignIn = Visibility.Collapsed; IsAdmin = Visibility.Collapsed; FullAdmin = Visibility.Collapsed;
                });

                return new ViewModelDelegateCommand(actionToExecute);
            }
        }
        public ICommand Admin
        {
            get
            {
                Action actionToExecute = new Action(async () =>
                {
                    IsAdmin = Visibility.Visible;
                    IsNewUser = Visibility.Collapsed; IsViewStudent = Visibility.Collapsed; IsSignIn = Visibility.Collapsed; IsSignOut = Visibility.Collapsed; FullAdmin = Visibility.Collapsed;
                });

                return new ViewModelDelegateCommand(actionToExecute);
            }
        }
    }

    public class ViewModelDelegateCommand : ICommand
    {
        private Action _executeMethod;
        public ViewModelDelegateCommand(Action executeMethod)
        {
            _executeMethod = executeMethod;
        }
        public bool CanExecute(object parameter)
        {
            if (CanExecuteChanged != null)
                return true;
            else
                return true;
        }

        public event EventHandler CanExecuteChanged;

        public void Execute(object parameter)
        {
            _executeMethod.Invoke();
        }
    }
}
