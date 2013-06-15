using Indeks.Interfaces;
using Indeks.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Indeks.ViewModels
{
    public class IndexVM : ApplicationVM, INotifyPropertyChanged
    {
        LoginVM _loginVm;

        public IndexVM(LoginVM loginVm)
        {
            _loginVm = loginVm;
            ExecuteOpenSemesterCommand = new Commanding(AddSemesterCommand, CanAddSemesterCommand);
            ExecuteCreateTabControl = new Commanding(GenerateTabControlData, CanGenerateTabControlData);
        }



        public ICommand ExecuteOpenSemesterCommand { get; set; }
        public ICommand ExecuteCreateTabControl { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(String property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }

        private bool CanAddSemesterCommand(object parameter)
        {
            return true;
        }
        
        private void AddSemesterCommand(object parameter)
        {
            Window frm = new Semester(_loginVm);
            frm.Show();
        }

        private bool CanGenerateTabControlData(object parameter)
        {
 	        return true;
        }

        private void GenerateTabControlData(object parameter)
        {
 	        throw new NotImplementedException();
        }
      }
    }
