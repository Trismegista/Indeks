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
            return true;
        }

        private void AddWykladowcaCommand(object parameter)
        {
            throw new NotImplementedException();
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
    }
}
