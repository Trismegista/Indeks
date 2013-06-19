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
    public class AddPrzedmiotNameVM : ApplicationVM
    {
        public AddPrzedmiotNameVM()
        {
            ExecuteAddPrzedmiotCommand = new Commanding(AddPrzedmiotCommand, CanAddPrzedmiotCommand);
        }

        public ICommand ExecuteAddPrzedmiotCommand { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string property = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }

        private bool CanAddPrzedmiotCommand(object parameter)
        {
            if ( String.IsNullOrEmpty(_przedmiotName)) return false;
            return true;
        }

        private void AddPrzedmiotCommand(object parameter)
        {
            DataClasses1DataContext context = new DataClasses1DataContext();

            var nazwaPrzedmiot = new PrzedmiotNazwa
            {
                Przedmiot_Nazwa = _przedmiotName
            };
            context.PrzedmiotNazwas.InsertOnSubmit(nazwaPrzedmiot);
            context.SubmitChanges();

            Window frm = (Window)parameter;
            frm.Close();
        }

        private string _przedmiotName;
        public string PrzedmiotName
        {
            get
            {
                return _przedmiotName;
            }
            set
            {
                if (value != _przedmiotName)
                {
                    _przedmiotName = value;
                    OnPropertyChanged();
                }
            }
        }
    }
}