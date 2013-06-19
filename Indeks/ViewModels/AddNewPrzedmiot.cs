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
    public class AddNewPrzedmiotVM : ApplicationVM
    {
        public AddNewPrzedmiotVM()
        {
            ExecuteAddPrzedmiotCommand = new Commanding(AddPrzedmiotCommand, CanAddPrzedmiotCommand);
            ExecuteAddPrzedmiotNameCommand = new Commanding(AddPrzedmiotNameCommand, CanAddPrzedmiotNameCommand);
            ExecuteAddTypCommand = new Commanding(AddTypNameCommand, CanAddTypNameCommand);

            TypName = Typ_Zajec.GetZajecias();
            PrzedmiotName = Przedmiot.GetPrzedmiotsNames();
        }

        public ICommand ExecuteAddPrzedmiotCommand { get; set; }
        public ICommand ExecuteAddPrzedmiotNameCommand { get; set; }
        public ICommand ExecuteAddTypCommand { get; set; }

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
            if (String.IsNullOrEmpty(_selectedTyp) || String.IsNullOrEmpty(_selectedPrzedmiot) || String.IsNullOrEmpty(_liczbaGodzin) || String.IsNullOrEmpty(_punktyETCS)) return false;
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

        private void AddPrzedmiotCommand(object parameter)
        {
            DataClasses1DataContext context = new DataClasses1DataContext();

            Guid idTyp = Typ_Zajec.FindZajeciasIdByName(_selectedTyp);
            Guid idPrzedmiotNazwa = Przedmiot.FindPrzedmiotNazwaIdByNazwa(_selectedPrzedmiot);

            var przedmiot = new Przedmiot
            {
                Id_PrzedmiotNazwa = idPrzedmiotNazwa,
                Id_Typ_Zajec = idTyp,
                Godziny = Convert.ToInt32(_liczbaGodzin),
                PunktyETCS = Convert.ToInt32(_punktyETCS)
            };
            context.Przedmiots.InsertOnSubmit(przedmiot);
            context.SubmitChanges();

            Window frm = (Window)parameter;
            frm.Close();
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