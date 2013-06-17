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
    public class RegistrationSemesterVM : ApplicationVM
    {
        private Guid _studentId;
        public RegistrationSemesterVM(Guid studentId)
        {
            _studentId = studentId;
            ExecuteAddSemesterCommand = new Commanding(AddSemesterCommand, CanAddSemesterCommand);
            ExecuteAddSemesterName = new Commanding(AddSemesterNameCommand, CanAddSemesterNameCommand);
            ExecuteAddKierunek = new Commanding(AddKierunekCommand, CanAddKierunekCommand);
            ExecuteAddCiag = new Commanding(AddCiagCommand, CanAddCiagCommand);
            ExecuteAddGroup = new Commanding(AddGroupCommand, CanAddGroupCommand);

            SemesterName = Semestr.GetSemestersNames();
            KierunekName = Kierunek.GetKieruneks();
            CiagName = Ciag.GetCiags();
            GroupName = Grupa.GetGrupas();
            MessageBox.Show(_studentId.ToString());
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
        public ICommand ExecuteAddSemesterName { get; set; }
        public ICommand ExecuteAddKierunek { get; set; }
        public ICommand ExecuteAddCiag { get; set; }
        public ICommand ExecuteAddGroup { get; set; }
        public ICommand ExecuteAddSemesterCommand { get; set; }
        #endregion
        
        #region CommandQuestions
        private bool CanAddSemesterCommand(object parameter)
        {
            if (String.IsNullOrEmpty(_selectedKierunek) || String.IsNullOrEmpty(_selectedCiag) || String.IsNullOrEmpty(_selectedGroup) || String.IsNullOrEmpty(_selectedSemester)) return false;
            return true;
        }
        private bool CanAddGroupCommand(object parameter)
        {
            return true;
        }

        private bool CanAddCiagCommand(object parameter)
        {
            return true;
        }

        private bool CanAddKierunekCommand(object parameter)
        {
            return true;
        }

        private bool CanAddSemesterNameCommand(object parameter)
        {
            return true;
        }
        #endregion

        #region CommandExecutes
        private void AddSemesterCommand(object parameter)
        {
            DataClasses1DataContext context = new DataClasses1DataContext();

            string[] nameSeparator = _selectedCiag.Split('-');
            string typName = nameSeparator[2];
            string stopienName = nameSeparator[1];
            string ciagName = nameSeparator[0];

            Guid idTypStudiow = TypStudiow.FindTypStudiowIdByName(typName);
            Guid idStopienStudiow = StopienStudiow.FindStupienStudiowIdByName(stopienName);
            Guid idCiag = Ciag.FineCiagIdByName(ciagName);
            Guid idKierunek = Kierunek.FindKierunekIdByName(_selectedKierunek);
            Guid idGrupa = Grupa.FindGrupaIdByName(_selectedGroup);

            var kierunekCiag = new LinqToSql.KierunekCiag
            {
                Id_Kierunek = idKierunek,
                Id_Ciag = idCiag
            };
            context.KierunekCiags.InsertOnSubmit(kierunekCiag);
            context.SubmitChanges();

            var kierunekCiagGrupa = new LinqToSql.KierunekCiagGrupa
            {
                Id_Ciag = idCiag,
                Id_Grupa = idGrupa
            };
            context.KierunekCiagGrupas.InsertOnSubmit(kierunekCiagGrupa);
            context.SubmitChanges();

            var semestr = new Semestr
            {
                Semestr_Nazwa = _selectedSemester
            };
            context.Semestrs.InsertOnSubmit(semestr);
            context.SubmitChanges();


            var kierunekCiagGrupaSemestr = new LinqToSql.KierunekCiagGrupaSemestr
            {
                Id_Grupa = idGrupa,
                Id_Semestr = semestr.Id_Semestr
            };
            context.KierunekCiagGrupaSemestrs.InsertOnSubmit(kierunekCiagGrupaSemestr);
            context.SubmitChanges();

            var studentSemestr = new LinqToSql.StudentSemestr
            {
                Id_Semestr = semestr.Id_Semestr,
                Id_Student = _studentId
            };
            context.StudentSemestrs.InsertOnSubmit(studentSemestr);
            context.SubmitChanges();

            Window frm = (Window)parameter;
            frm.Close();
        }

        private void AddGroupCommand(object parameter)
        {
            AddGroup frm = new AddGroup();
            Nullable<bool> dialogResult = frm.ShowDialog();
        }

        private void AddCiagCommand(object parameter)
        {
            AddCiag frm = new AddCiag();
            Nullable<bool> dialogResult = frm.ShowDialog();
        }

        private void AddKierunekCommand(object parameter)
        {
            AddKierunek frm = new AddKierunek();
            Nullable<bool> dialogResult = frm.ShowDialog();
        }

        private void AddSemesterNameCommand(object parameter)
        {
            AddSemesterName frm = new AddSemesterName();
            Nullable<bool> dialogResult = frm.ShowDialog();
        }
        #endregion

        #region Bindings

        #region Bindings to->
        private List<string> _semesterName;
        public List<string> SemesterName
        {
            get 
            { 
                return _semesterName; 
            }
            set
            {
                _semesterName = value;
                OnPropertyChanged();
            }
        }

        private List<string> _ciagName;
        public List<string> CiagName
        {
            get
            {
                return _ciagName;
            }
            set
            {
                _ciagName = value;
                OnPropertyChanged();
            }
        }

        private List<string> _kierunekName;
        public List<string> KierunekName
        {
            get
            {
                return _kierunekName;
            }
            set
            {
                _kierunekName = value;
                OnPropertyChanged();
            }
        }

        private List<string> _groupName;
        public List<string> GroupName
        {
            get
            {
                return _groupName;
            }
            set
            {
                _groupName = value;
                OnPropertyChanged();
            }
        }
        #endregion

        #region Bindings From <-

        private string _selectedSemester;
        public string SelectedSemester
        {
            get
            {
                return _selectedSemester;
            }
            set
            {
                if (value != _selectedSemester)
                {
                    _selectedSemester = value;
                    OnPropertyChanged();
                }
            }
        }

        private string _selectedKierunek;
        public string SelectedKierunek
        {
            get
            {
                return _selectedKierunek;
            }
            set
            {
                if (value != _selectedKierunek)
                {
                    _selectedKierunek = value;
                    OnPropertyChanged();
                }
            }
        }

        private string _selectedCiag;
        public string SelectedCiag
        {
            get
            {
                return _selectedCiag;
            }
            set
            {
                if (value != _selectedCiag)
                {
                    _selectedCiag = value;
                    OnPropertyChanged();
                }
            }
        }

        private string _selectedGroup;
        public string SelectedGroup
        {
            get
            {
                return _selectedGroup;
            }
            set
            {
                if (value != _selectedGroup)
                {
                    _selectedGroup = value;
                    OnPropertyChanged();
                }
            }
        }
        #endregion

        #endregion
    }
}
