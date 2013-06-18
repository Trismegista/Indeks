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
            return true;
        }

        private void AddPrzedmiotCommand(object parameter)
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