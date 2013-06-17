using Indeks.Interfaces;
using Indeks.LinqToSql;
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
    public class AddKierunekVM : ApplicationVM
    {
        public AddKierunekVM()
        {
            ExecuteAddKierunekCommand = new Commanding(AddKierunekCommand, CanAddKierunekCommand);
        }
        public ICommand ExecuteAddKierunekCommand { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string property = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }

        private bool CanAddKierunekCommand(object parameter)
        {
            if ( String.IsNullOrEmpty(_kierunekName)) return false;
            return true;
        }

        private void AddKierunekCommand(object parameter)
        {
            DataClasses1DataContext context = new DataClasses1DataContext();
            var kierunek = new Kierunek
            {
                Kierunek_Nazwa = _kierunekName
            };
            context.Kieruneks.InsertOnSubmit(kierunek);
            context.SubmitChanges();

            Window frm = (Window)parameter;
            frm.Close();
        }

        private string _kierunekName;
        public string KierunekName
        {
            get
            {
                return _kierunekName;
            }
            set
            {
                if (value != _kierunekName)
                {
                    _kierunekName = value;
                    OnPropertyChanged();
                }
            }
        }
    }
}
