using Indeks.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;
using Indeks.LinqToSql;

namespace Indeks.ViewModels
{
    public class AddWykladowcaVM : ApplicationVM
    {
        public AddWykladowcaVM()
        {
            ExecuteAddWykladowcaCommand = new Commanding(AddWykladowcaCommand, CanAddWykladowcaCommand);
        }

        public ICommand ExecuteAddWykladowcaCommand { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string property = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }

        private bool CanAddWykladowcaCommand(object parameter)
        {
            if (String.IsNullOrEmpty(_email) || String.IsNullOrEmpty(_telefon) || String.IsNullOrEmpty(_wykladowcaImie) || String.IsNullOrEmpty(_wykladowcaNazwisko)) return false;
            return true;
        }

        private void AddWykladowcaCommand(object parameter)
        {
            DataClasses1DataContext context = new DataClasses1DataContext();

            var wykladowca = new Wykladowca
            {
                Wykladowca_Imie = _wykladowcaImie,
                Wykladowca_Nazwisko = _wykladowcaNazwisko,
                Wykladowca_E_Mail = _email,
                Wykladowca_Telefon = _telefon
            };
            context.Wykladowcas.InsertOnSubmit(wykladowca);
            context.SubmitChanges();

            Window frm = (Window)parameter;
            frm.Close();
        }

        private string _wykladowcaImie;
        public string WykladowcaImie
        {
            get
            {
                return _wykladowcaImie;
            }
            set
            {
                if (value != _wykladowcaImie)
                {
                    _wykladowcaImie = value;
                    OnPropertyChanged();
                }
            }
        }
        private string _wykladowcaNazwisko;
        public string WykladowcaNazwisko
        {
            get
            {
                return _wykladowcaNazwisko;
            }
            set
            {
                if (value != _wykladowcaNazwisko)
                {
                    _wykladowcaNazwisko = value;
                    OnPropertyChanged();
                }
            }
        }
        private string _telefon;
        public string Telefon
        {
            get
            {
                return _telefon;
            }
            set
            {
                if (value != _telefon)
                {
                    _telefon = value;
                    OnPropertyChanged();
                }
            }
        } 
        private string _email;
        public string eMail
        {
            get
            {
                return _email;
            }
            set
            {
                if (value != _email)
                {
                    _email = value;
                    OnPropertyChanged();
                }
            }
        }
    }
}
