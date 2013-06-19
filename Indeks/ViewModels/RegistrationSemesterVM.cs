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
            ExecuteAddWykladowcaCommand = new Commanding(AddWykladowca, CanAddWykladowca);

            SemesterName = Semestr.GetSemestersNames();
            PrzedmiotName = Przedmiot.GetPrzedmiots();
            WykladowcaName = Wykladowca.GetWykladowcas();
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
                OnPropertyChanged("Kierunek");
            }
        }

        private string _selectedPrzedmiot;
        public string SelectedPrzedmiot
        {
            get { return _selectedPrzedmiot; }
            set
            {
                _selectedPrzedmiot = value;
                OnPropertyChanged("TypStudiow");
            }
        }

        private string _selectedWykladowca;
        public string SelectedWykladowca
        {
            get { return _selectedWykladowca; }
            set
            {
                _selectedWykladowca = value;
                OnPropertyChanged("RodzajStudiow");
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

        private List<string> _wykladowcaName;
        public List<string> WykladowcaName
        {
            get
            {
                return _wykladowcaName;
            }
            set
            {
                _wykladowcaName = value;
                OnPropertyChanged();
            }
        }
        #endregion

        #region Commands

        public ICommand ExecuteAddSemesterCommand { get; set; }
        public ICommand ExecuteAddSemesterNameCommand { get; set; }
        public ICommand ExecuteAddPrzedmiotName { get; set; }
        public ICommand ExecuteAddWykladowcaCommand { get; set; }

        #endregion

        #region Command Questions

        private bool CanRegisterSemester(object parameter)
        {
 	        return true;
        }

        private bool CanAddWykladowca(object parameter)
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
            

            //Window frm = (Window)parameter;
            //frm.Close();
        }

        private void AddWykladowca(object parameter)
        {
            AddWykladowca frm = new AddWykladowca();
            Nullable<bool> dialogResult = frm.ShowDialog();
        }

        private void AddPrzedmiot(object parameter)
        {
            AddPrzedmiot frm = new AddPrzedmiot();
            Nullable<bool> dialogResult = frm.ShowDialog();
        }

        private void AddSemesterName(object parameter)
        {
            AddSemesterName frm = new AddSemesterName();
            Nullable<bool> dialogResult = frm.ShowDialog();
        }
        #endregion

        public Guid CurrentGroupId
        {
            get { return _groupId; }
        }
    }
}
