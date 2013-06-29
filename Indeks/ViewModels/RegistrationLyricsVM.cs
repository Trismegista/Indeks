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
    class RegistrationLyricsVM : ApplicationVM
    {
        Guid _idGrupa;
        Guid _idSemestr;

        public RegistrationLyricsVM(Guid idGrupa, Guid idSemestr)
        {
            _idGrupa = idGrupa;
            _idSemestr = idSemestr;
            ExecuteAddPrzedmiotCommand = new Commanding(AddPrzedmiotCommand, CanAddPrzedmiotCommand);
            ExecuteAddPrzedmiotContinueCommand = new Commanding(AddPrzedmiotAndContinueCommand, CanAddPrzedmiotAndContinueCommand);
            ExecuteAddPrzedmiotNameCommand = new Commanding(AddPrzedmiotNameCommand, CanAddPrzedmiotNameCommand);
            ExecuteAddTypCommand = new Commanding(AddTypNameCommand, CanAddTypNameCommand);
            ExecuteAddWykladowcaCommand = new Commanding(AddWykladowcaCommand, CanAddWykladowcaCommand);

            TypName = Typ_Zajec.GetZajecias();
            PrzedmiotName = Przedmiot.GetPrzedmiotsNames();
            WykladowcaName = Wykladowca.GetWykladowcas();
        }

        public ICommand ExecuteAddPrzedmiotCommand { get; set; }
        public ICommand ExecuteAddPrzedmiotContinueCommand { get; set; }
        public ICommand ExecuteAddPrzedmiotNameCommand { get; set; }
        public ICommand ExecuteAddTypCommand { get; set; }
        public ICommand ExecuteAddWykladowcaCommand { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string property = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }

        #region CommandQuestions

        private bool CanAddPrzedmiotCommand(object parameter)
        {
            if (String.IsNullOrEmpty(_selectedTyp) || String.IsNullOrEmpty(_selectedPrzedmiot) || String.IsNullOrEmpty(_selectedWykladowca) || String.IsNullOrEmpty(_liczbaGodzin) || String.IsNullOrEmpty(_punktyETCS)) return false;
            return true;
        }

        private bool CanAddPrzedmiotAndContinueCommand(object parameter)
        {
            if (String.IsNullOrEmpty(_selectedTyp) || String.IsNullOrEmpty(_selectedPrzedmiot) || String.IsNullOrEmpty(_selectedWykladowca) || String.IsNullOrEmpty(_liczbaGodzin) || String.IsNullOrEmpty(_punktyETCS)) return false;
            return true;
        }

        private bool CanAddWykladowcaCommand(object parameter)
        {
            return true;
        }

        private bool CanAddTypNameCommand(object parameter)
        {
            return true;
        }

        private bool CanAddPrzedmiotNameCommand(object parameter)
        {
            return true;
        }

        #endregion

        #region CommandExecute

        private void dodaj_przedmiot()
        {
            DataClasses1DataContext context = new DataClasses1DataContext();

            Guid idWykladowcy = Wykladowca.FindWykladowcaIdByName(_selectedWykladowca);
            Guid idTyp = Typ_Zajec.FindZajeciasIdByName(_selectedTyp);
            Guid PrzedmiotNazwaId = Przedmiot.FindPrzedmiotNazwaIdByNazwa(_selectedPrzedmiot);
            Przedmiot przedmiotExist = Przedmiot.CheckPrzedmiotExist(idTyp, idWykladowcy, PrzedmiotNazwaId);
            if (przedmiotExist == null)
            {
                var newPrzedmiot = new Przedmiot
                {
                    Id_PrzedmiotNazwa = PrzedmiotNazwaId,
                    Id_Typ_Zajec = idTyp,
                    PunktyETCS = Convert.ToInt32(_punktyETCS),
                    Godziny = Convert.ToInt32(_liczbaGodzin),
                    Id_Wykladowcy = idWykladowcy
                };
                przedmiotExist = newPrzedmiot;
                context.Przedmiots.InsertOnSubmit(przedmiotExist);
                context.SubmitChanges();
            }

            if (!Semestr.CheckPrzedmiotExistInSemester(_idSemestr, _idGrupa, przedmiotExist.Id_Przedmiot))
            {
                var grupaPrzedmiotSemestr = new GrupaSemestrPrzedmiot
                {
                    Id_Grupa = _idGrupa,
                    Id_Semestr = _idSemestr,
                    Id_Przedmiot = przedmiotExist.Id_Przedmiot
                };
                context.GrupaSemestrPrzedmiots.InsertOnSubmit(grupaPrzedmiotSemestr);
                context.SubmitChanges();
            }
            else
            {
                MessageBox.Show("Przedmiot jest już na liście","Uwaga", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void AddPrzedmiotCommand(object parameter)
        {
            dodaj_przedmiot();

            Window frm = (Window)parameter;
            frm.Close();
        }

        private void AddPrzedmiotAndContinueCommand(object parameter)
        {
            dodaj_przedmiot();
            Window frm = (Window)parameter;
            frm.Close();

            AddPrzedmiot frm2 = new AddPrzedmiot(_idGrupa, _idSemestr);
            Nullable<bool> dialogResult = frm2.ShowDialog();
        }

        private void AddWykladowcaCommand(object parameter)
        {
            AddWykladowca frm = new AddWykladowca();
            Nullable<bool> dialogResult = frm.ShowDialog();
        }

        private void AddTypNameCommand(object parameter)
        {
            AddTypName frm = new AddTypName();
            Nullable<bool> dialogResult = frm.ShowDialog();
        }

        private void AddPrzedmiotNameCommand(object parameter)
        {
            AddPrzedmiotName frm = new AddPrzedmiotName();
            Nullable<bool> dialogResult = frm.ShowDialog();
        }

        #endregion

        #region Bindings

        #region To ->
        private List<string> _przedmiotName;
        public List<string> PrzedmiotName
        {
            get
            { return _przedmiotName; }
            set
            {
                _przedmiotName = value;
                OnPropertyChanged();
            }
        }

        private List<string> _typName;
        public List<string> TypName
        {
            get
            {
                return _typName;
            }
            set
            {
                _typName = value;
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

        #region From <-

        private string _selectedPrzedmiot;
        public string SelectedPrzedmiot
        {
            get
            {
                return _selectedPrzedmiot;
            }
            set
            {
                if (value != _selectedPrzedmiot)
                {
                    _selectedPrzedmiot = value;
                    OnPropertyChanged();
                }
            }
        }

        private string _selectedTyp;
        public string SelectedTyp
        {
            get
            {
                return _selectedTyp;
            }
            set
            {
                if (value != _selectedTyp)
                {
                    _selectedTyp = value;
                    OnPropertyChanged();
                }
            }
        }

        private string _selectedWykladowca;
        public string SelectedWykladowca
        {
            get
            {
                return _selectedWykladowca;
            }
            set
            {
                if (value != _selectedWykladowca)
                {
                    _selectedWykladowca = value;
                    OnPropertyChanged();
                }
            }
        }

        private string _liczbaGodzin;
        public string LiczbaGodzin
        {
            get
            {
                return _liczbaGodzin;
            }
            set
            {
                if (value != _liczbaGodzin)
                {
                    _liczbaGodzin = value;
                    OnPropertyChanged();
                }
            }
        }

        private string _punktyETCS;
        public string PunktyETCS
        {
            get
            {
                return _punktyETCS;
            }
            set
            {
                if (value != _punktyETCS)
                {
                    _punktyETCS = value;
                    OnPropertyChanged();
                }
            }
        }

        #endregion
        #endregion
    }
}
