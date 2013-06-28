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
    public class RegistrationSemesterVM : ApplicationVM, INotifyPropertyChanged
    {
        Guid _groupId;

        public RegistrationSemesterVM(Guid idGrupa)
        {
            _groupId = idGrupa;
            ExecuteAddSemesterCommand = new Commanding(RegisterSemester, CanRegisterSemester);
            ExecuteAddSemesterNameCommand = new Commanding(AddSemesterName, CanAddSemesterName);
            ExecuteAddPrzedmiotName = new Commanding(AddPrzedmiot, CanAddPrzedmiotName);

            SemesterName = Semestr.GetSemestersNames();
            PrzedmiotName = Przedmiot.GetPrzedmiots();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string property = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }

        #region Bindings

        private string _selectedSemester;
        public string SelectedSemester
        {
            get { return _selectedSemester; }
            set
            {
                _selectedSemester = value;
                OnPropertyChanged();
            }
        }

        private string _selectedPrzedmiot;
        public string SelectedPrzedmiot
        {
            get { return _selectedPrzedmiot; }
            set
            {
                _selectedPrzedmiot = value;
                OnPropertyChanged();
            }
        }

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

        private List<string> _przedmiotName;
        public List<string> PrzedmiotName
        {
            get
            {
                return _przedmiotName;
            }
            set
            {
                _przedmiotName = value;
                OnPropertyChanged();
            }
        }

        #endregion

        #region Commands

        public ICommand ExecuteAddSemesterCommand { get; set; }
        public ICommand ExecuteAddSemesterNameCommand { get; set; }
        public ICommand ExecuteAddPrzedmiotName { get; set; }

        #endregion

        #region Command Questions

        private bool CanRegisterSemester(object parameter)
        {
 	        return true;
        }

        private bool CanAddPrzedmiotName(object parameter)
        {
            return true;
        }

        private bool CanAddSemesterName(object parameter)
        {
            return true;
        }
        #endregion

        #region Command Executes

        private void RegisterSemester(object parameter)
        {
            DataClasses1DataContext context = new DataClasses1DataContext();
            Guid idSemestr = Semestr.FindSemestrIdByName(_selectedSemester);
            Guid idPrzedmiot = Przedmiot.FindPrzedmiotIdByFullName(_selectedPrzedmiot);
            if (!Semestr.CheckSemestrExistInGroup(CurrentGroupId, idSemestr))
            {
                var grupaSemestrPrzedmiot = new GrupaSemestrPrzedmiot
                {
                    Id_Grupa = CurrentGroupId,
                    Id_Przedmiot = idPrzedmiot,
                    Id_Semestr = idSemestr
                };

                context.GrupaSemestrPrzedmiots.InsertOnSubmit(grupaSemestrPrzedmiot);
                context.SubmitChanges();
            }
            else MessageBox.Show("Semestr jest już wpisany","Uwaga", MessageBoxButton.OK, MessageBoxImage.Error);

            Window frm = (Window)parameter;
            frm.Close();
        }

        private void AddPrzedmiot(object parameter)
        {
            AddNewPrzedmiot frm = new AddNewPrzedmiot();
            Nullable<bool> dialogResult = frm.ShowDialog();
        }

        private void AddSemesterName(object parameter)
        {
            AddSemesterName frm = new AddSemesterName();
            Nullable<bool> dialogResult = frm.ShowDialog();
            SemesterName = Semestr.GetSemestersNames();
        }
        #endregion

        public Guid CurrentGroupId
        {
            get { return _groupId; }
        }
    }
}
