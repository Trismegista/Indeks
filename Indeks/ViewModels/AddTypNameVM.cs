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
    public class AddTypNameVM : ApplicationVM
    {
        public AddTypNameVM()
        {
            ExecuteAddTypNameCommand = new Commanding(AddTypNameCommand, CanAddTypNameCommand);
        }

        public ICommand ExecuteAddTypNameCommand { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string property = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }

        private bool CanAddTypNameCommand(object parameter)
        {
            if (String.IsNullOrEmpty(_typNazwa)) return false;
            return true;
        }

        private void AddTypNameCommand(object parameter)
        {
            DataClasses1DataContext context = new DataClasses1DataContext();

            var typname = new Typ_Zajec
            {
                Typ_Zajec_Nazwa = _typNazwa
            };
            context.Typ_Zajecs.InsertOnSubmit(typname);
            context.SubmitChanges();
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

        private string _typNazwa;
        public string TypNazwa
        {
            get
            {
                return _typNazwa;
            }
            set
            {
                if (value != _typNazwa)
                {
                    _typNazwa = value;
                    OnPropertyChanged();
                }
            }
        }
    }
}