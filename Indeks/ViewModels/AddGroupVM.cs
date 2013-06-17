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
    public class AddGroupVM : ApplicationVM
    {
        public AddGroupVM()
        {
            ExecuteAddGrupaCommand = new Commanding(AddGrupaCommand, CanAddGrupaCommand);
        }

        public ICommand ExecuteAddGrupaCommand { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string property = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }

        private bool CanAddGrupaCommand(object parameter)
        {
            if (String.IsNullOrEmpty(_grupaName)) return false;
            return true;
        }

        private void AddGrupaCommand(object parameter)
        {
            DataClasses1DataContext context = new DataClasses1DataContext();
            var grupa = new Grupa
            {
                Grupa_Nazwa = _grupaName
            };
            context.Grupas.InsertOnSubmit(grupa);
            context.SubmitChanges();
        }

        private string _grupaName;
        public string GrupaName
        {
            get
            {
                return _grupaName;
            }
            set
            {
                if (value != _grupaName)
                {
                    _grupaName = value;
                    OnPropertyChanged();
                }
            }

        }
    }
}
