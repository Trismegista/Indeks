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
            ExecuteOpenGroupCommand = new Commanding(AddGroupCommand, CanAddGroupCommand);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(String property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }


        #region commands

        public ICommand ExecuteOpenGroupCommand { get; set; }
        public ICommand ExecuteOpenSemesterCommand { get; set; }

        #endregion

        #region Command Questions
        private bool CanAddGroupCommand(object parameter)
        {
            return true;
        }

        private bool CanAddSemesterCommand(object parameter)
        {
            return true;
        }

        #endregion

        #region Execute Commands
        private void AddSemesterCommand(object parameter)
        {
            Window frm = new Semester(_loginVm);
            Nullable<bool> dialogResult = frm.ShowDialog();
        }

        private void AddGroupCommand(object parameter)
        {
            Window frm = new GroupRegistration();
            Nullable<bool> dialogResult = frm.ShowDialog();
        }

        #endregion

      }
    }
