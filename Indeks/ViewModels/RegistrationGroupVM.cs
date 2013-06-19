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
    public class RegistrationGroupVM : ApplicationVM
    {
        private Guid _studentId;
        public RegistrationGroupVM(Guid studentId)
        {
            _studentId = studentId;
            ExecuteAddKierunekCommand = new Commanding(AddKierunekCiagGroupCommand, CanAddKierunekCiagGroupCommand);
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
        public ICommand ExecuteAddKierunek { get; set; }
        public ICommand ExecuteAddCiag { get; set; }
        public ICommand ExecuteAddGroup { get; set; }
        public ICommand ExecuteAddKierunekCommand { get; set; }
        #endregion
        
        #region CommandQuestions
        private bool CanAddKierunekCiagGroupCommand(object parameter)
        {
            if (String.IsNullOrEmpty(_selectedKierunek) || String.IsNullOrEmpty(_selectedCiag) || String.IsNullOrEmpty(_selectedGroup)) return false;
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
        private void AddKierunekCiagGroupCommand(object parameter)
        {
            DataClasses1DataContext context = new DataClasses1DataContext();

            string[] nameSeparator = _selectedCiag.Split('-');

            Guid idCiag = Ciag.FindCiagIdByName(nameSeparator[0]);
            Guid idKierunek = Kierunek.FindKierunekIdByName(_selectedKierunek);
            Guid idGrupa = Grupa.FindGrupaIdByName(_selectedGroup);

            var grupa = new Grupa
            {
                Id_Ciag = idCiag,
                Id_Kierunek = idKierunek,
                Id_Grupa_Nazwa = Grupa.FindGrupaIdByName(_selectedGroup)
            };
            context.Grupas.InsertOnSubmit(grupa);
            context.SubmitChanges();

            var studentGrupa = new StudentGrupa
            {
                Id_Grupa = grupa.Id_Grupa,
                Id_Student = _studentId
            };
            context.StudentGrupas.InsertOnSubmit(studentGrupa);
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
