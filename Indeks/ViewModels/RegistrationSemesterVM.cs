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
    public class RegistrationSemesterVM : ApplicationVM
    {
        private LoginVM _loginVm;
        public RegistrationSemesterVM(LoginVM loginVm)
        {
            _loginVm = loginVm;
            ExecuteAddSemesterCommand = new Commanding(AddSemesterCommand, CanAddSemesterCommand);
            SemesterName = Semestr.GetSemestersNames();
            KierunekName = Kierunek.GetKieruneks();
            CiagName = Ciag.GetCiags();
            GroupName = Grupa.GetGrupas();
        }



        private void AddSemesterCommand(object parameter)
        {
            
        }

        private bool CanAddSemesterCommand(object parameter)
        {
            return true;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string property = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }

        public ICommand ExecuteAddSemesterCommand { get; set; }

        private List<string> _semesterName;
        public List<string> SemesterName
        {
            get 
            { 
                return _semesterName; 
            }
            set
            {
                _semesterName = value;
                OnPropertyChanged();
            }
        }

        private List<string> _ciagName;
        public List<string> CiagName
        {
            get
            {
                return _ciagName;
            }
            set
            {
                _ciagName = value;
                OnPropertyChanged();
            }
        }

        private List<string> _kierunekName;
        public List<string> KierunekName
        {
            get
            {
                return _kierunekName;
            }
            set
            {
                _kierunekName = value;
                OnPropertyChanged();
            }
        }

        private List<string> _groupName;
        public List<string> GroupName
        {
            get
            {
                return _groupName;
            }
            set
            {
                _groupName = value;
                OnPropertyChanged();
            }
        }
    }
}
