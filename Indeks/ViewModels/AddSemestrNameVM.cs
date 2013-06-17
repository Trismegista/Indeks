using Indeks.Interfaces;
using Indeks.LinqToSql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Indeks.ViewModels
{
    public class AddSemestrNameVM : ApplicationVM
    {
        public AddSemestrNameVM()
        {
            ExecuteAddSemestrNameCommand = new Commanding(AddSemestrNameCommand, CanAddSemestrNameCommand);
        }

        public ICommand ExecuteAddSemestrNameCommand { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string property = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }

        private bool CanAddSemestrNameCommand(object parameter)
        {
            if (String.IsNullOrEmpty(_semestrName)) return false;
            return true;
        }

        private void AddSemestrNameCommand(object parameter)
        {
            DataClasses1DataContext context = new DataClasses1DataContext();
            var semestr = new Semestr
            {
                Semestr_Nazwa = _semestrName
            };
            context.Semestrs.InsertOnSubmit(semestr);
            context.SubmitChanges();
        }

        private string _semestrName;
        public string SemestrName
        {
            get { return _semestrName; }
            set
            {
                if (value != _semestrName)
                {
                    _semestrName = value;
                    OnPropertyChanged();
                }
            }

        }
    }
}
