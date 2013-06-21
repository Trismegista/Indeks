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
        Guid CurrentGrupa;
        int _val;

        public IndexVM(LoginVM loginVm)
        {
            _loginVm = loginVm;
            ExecuteOpenKierunekCommand = new Commanding(AddKierunekCommand, CanAddKierunekCommand);
            ExecuteOpenSemestrCommand = new Commanding(AddSemesterCommand, CanAddSemesterCommand);
            ExecuteOpenPrzedmiotCommand = new Commanding(AddPrzedmiotCommand, CanAddPrzedmiotCommand);
            NumeryIndeksow = Student.CurentUserIndexList(_loginVm.CurrentUserId);
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
        public ICommand ExecuteOpenSemestrCommand { get; set; }
        public ICommand ExecuteOpenKierunekCommand { get; set; }

        #endregion

        #region Command Questions
        private bool CanAddPrzedmiotCommand(object parameter)
        {
            if (String.IsNullOrEmpty(_wybranaGrupa)) return false;
            return true;
        }

        private bool CanAddSemesterCommand(object parameter)
        {
            if (String.IsNullOrEmpty(_wybranaGrupa)) return false;
            return true;
        }

        private bool CanAddKierunekCommand(object parameter)
        {
            return true;
        }

        #endregion

        #region Commands Execute
        private void AddPrzedmiotCommand(object parameter)
        {
            AddPrzedmiot frm = new AddPrzedmiot(CurrentGrupa,CurrentSemesterId);
            Nullable<bool> dialogResult = frm.ShowDialog();
        }

        private void AddKierunekCommand(object parameter)
        {
            GroupRegistration frm = new GroupRegistration(CurrentStudentId);
            Nullable<bool> dialogResult = frm.ShowDialog();
        }

        private void AddSemesterCommand(object parameter)
        {
            SemesterRegistration frm = new SemesterRegistration(CurrentGrupa);
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

        private List<string> _listaGrup;
        public List<string> ListaGrup
        {
            get
            {
                return _listaGrup;
            }
            set
            {
                {
                    _listaGrup = value;
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
                    if (value >= 0)
                    {
                        CurrentSemesterId = _semesters.ToList()[_wybranySemestr].Id_Semestr;
                    }
                }
            }
        }

        private string _wybranaGrupa;
        public string WybranaGrupa
        {
            get { return _wybranaGrupa; }
            set
            {
                if (_wybranaGrupa != value)
                {
                    _wybranaGrupa = value;
                    OnPropertyChanged();
                    Semesters = Student.Semesters(_wybranaGrupa);
                    WybranySemestr = 0;
                    CurrentGrupa = Grupa.FindGrupaIdByFullName(_wybranaGrupa);
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
                    ListaGrup = Student.CurentStudentGroupList(_wybranyIndex);
                    CurrentStudentId = Student.FindStudentIdByIndex(_wybranyIndex);
                }
            }
        }
        #endregion

      }
    }
