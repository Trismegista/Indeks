using Indeks.Interfaces;
using Indeks.LinqToSql;
using Indeks.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Indeks.ViewModels
{
    public class IndexVM : ApplicationVM, INotifyPropertyChanged
    {
        LoginVM _loginVm;
        Guid CurrentStudentId;
        Guid CurrentSemesterId;

        public IndexVM(LoginVM loginVm)
        {
            _loginVm = loginVm;
            ExecuteOpenSemesterCommand = new Commanding(AddSemesterCommand, CanAddSemesterCommand);
            ExecuteOpenGroupCommand = new Commanding(AddGroupCommand, CanAddGroupCommand);
            ExecuteOpenPrzedmiotCommand = new Commanding(AddPrzedmiotCommand, CanAddPrzedmiotCommand);
            NumeryIndeksow = Student.CurentStudentIndexList(_loginVm.CurrentUserId);            
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string property = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }

        #region Commands

        public ICommand ExecuteOpenPrzedmiotCommand { get; set; }
        public ICommand ExecuteTestButtonCommand { get; set; }
        public ICommand ExecuteOpenGroupCommand { get; set; }
        public ICommand ExecuteOpenSemesterCommand { get; set; }

        #endregion

        #region Command Questions
        private bool CanAddPrzedmiotCommand(object parameter)
        {
            return true;
        }

        private bool CanAddGroupCommand(object parameter)
        {
            return true;
        }

        private bool CanAddSemesterCommand(object parameter)
        {
            return true;
        }

        private bool CanTestInformation(object parameter)
        {
            return true;
        }

        #endregion

        #region Commands Execute
        private void AddPrzedmiotCommand(object parameter)
        {
            AddPrzedmiot frm = new AddPrzedmiot(CurrentSemesterId);
            Nullable<bool> dialogResult = frm.ShowDialog();
        }

        private void AddSemesterCommand(object parameter)
        {
            Semester frm = new Semester(CurrentStudentId);
            Nullable<bool> dialogResult = frm.ShowDialog();
        }

        private void AddGroupCommand(object parameter)
        {
            Window frm = new GroupRegistration();
            Nullable<bool> dialogResult = frm.ShowDialog();
        }

        #endregion

        #region Bindings

        private IQueryable<Semestr> _semesters;
        public IQueryable<Semestr> Semesters
        {
            get
            {
                return _semesters;
            }
            set
            {
                {
                    _semesters = value;
                    OnPropertyChanged();
                }
            }
        }

        private List<int> _numeryIndeksow;
        public List<int> NumeryIndeksow
        {
            get
            {
                return _numeryIndeksow;
            }
            set
            {
                _numeryIndeksow = value;
                OnPropertyChanged();
            }
        }


        private int _wybranySemestr;
        public int WybranySemestr
        {
            get { return _wybranySemestr; }
            set
            {
                if (value != _wybranySemestr )
                {
                    _wybranySemestr = value;
                    OnPropertyChanged();
                    CurrentSemesterId = _semesters.ToList()[_wybranySemestr].Id_Semestr;
                }
            }
        }

        private int _wybranyIndex;
        public int WybranyIndeks
        {
            get
            {
                return _wybranyIndex;
            }
            set
            {
                if (_wybranyIndex != value)
                {
                    _wybranyIndex = value;
                    OnPropertyChanged();
                    Semesters = Student.Semesters(_wybranyIndex);
                    CurrentStudentId = Student.FindStudentIdByIndex(_wybranyIndex);
                    WybranySemestr = 0;
                    CurrentSemesterId = _semesters.ToList()[_wybranySemestr].Id_Semestr;
                }
            }
        }
        #endregion

      }
    }
