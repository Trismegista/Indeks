using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Indeks.Interfaces;
using System.Windows.Input;
using System.Windows;
using System.ComponentModel;

namespace Indeks.ViewModels
{
    public class LoginVM : INotifyPropertyChanged
    {
        public LoginVM()
        {
            ExecuteRegistrationCommand = new Commanding(OpenRegistration,CanOpenRegistration);
            ExecuteLoginCommand = new Commanding(LoginIntoApp,CanLoginIntoApp);
            ExecuteCancelCommand = new Commanding(CancelApp,CanCancelApp);
        }
        
        public ICommand ExecuteRegistrationCommand { get; set; }
        public ICommand ExecuteLoginCommand { get; set; }
        public ICommand ExecuteCancelCommand { get; set; }
        
        public LinqToSql.Student CurrentStudent;

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(String property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }
        public string GetLogin()
        {
            return CurrentStudent.login;
        }
        private bool CanCancelApp(object parameter)
        {
            return true;
        }

        private void CancelApp(object parameter)
        {
            Application.Current.Shutdown();
        }

        private bool CanLoginIntoApp(object parameter)
        {
            return true;
        }

        private void LoginIntoApp(object parameter)
        {
            var service = new StudentServiceVM();
            CurrentStudent = service.FindStudentByLogin(_login);
            if (service.CanBeLogged(CurrentStudent, _password, _login))
            {
                var login = (Window)parameter;
                var frm = new Index(this);
                frm.Show();
                login.Close();
            }
        }

        private bool CanOpenRegistration(object parameter)
        {
            return true;
        }

        private void OpenRegistration(object parameter)
        {
            var frm = new RegisterWindow();
            frm.Show();
        }

        private string _login;
        public string Login
        {
            get { return _login; }
            set
            {
                _login = value;
                OnPropertyChanged("Login");
            }
        }

        private string _password;
        public string Password
        {
            get { return _password; }
            set
            {
                _password = value;
                OnPropertyChanged("Password");
            }
        }
    }
}
