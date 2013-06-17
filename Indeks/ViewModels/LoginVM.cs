using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Indeks.Interfaces;
using System.Windows.Input;
using System.Windows;
using System.ComponentModel;
using Indeks.LinqToSql;

namespace Indeks.ViewModels
{
    public class LoginVM : INotifyPropertyChanged

    {
        public Login CurrentStudentLogin { get; set; }
        public Guid CurrentUserId { get; set; }

        public LoginVM()
        {
            ExecuteRegistrationCommand = new Commanding(OpenRegistration,CanOpenRegistration);
            ExecuteLoginCommand = new Commanding(LoginIntoApp,CanLoginIntoApp);
            ExecuteCancelCommand = new Commanding(CancelApp,CanCancelApp);
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
        public ICommand ExecuteRegistrationCommand { get; set; }
        public ICommand ExecuteLoginCommand { get; set; }
        public ICommand ExecuteCancelCommand { get; set; }
        #endregion

        #region commands Questions

        private bool CanCancelApp(object parameter)
        {
            return true;
        }

        private bool CanLoginIntoApp(object parameter)
        {
            return true;
        }

        private bool CanOpenRegistration(object parameter)
        {
            return true;
        }

        #endregion

        #region commands execute
        private void CancelApp(object parameter)
        {
            Application.Current.Shutdown();
        }

        private void LoginIntoApp(object parameter)
        {
            var model = new Login();
            CurrentStudentLogin = model.FindUserByLogin(_login);
            CurrentUserId = model.GetUserId(_login);
            if (model.IsAuthenticated(CurrentStudentLogin, _password, _login))
            {
                var login = (Window)parameter;
                var frm = new Index(this);
                frm.Show();
                login.Close();
            }
            else
            {
                MessageBox.Show("Brak Autoryzacji");
            }
        }

        private void OpenRegistration(object parameter)
        {
            var frm = new RegisterWindow();
            frm.Show();
        }

        #endregion

        #region bindings

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

        #endregion

        public string GetLogin()
        {
            return CurrentStudentLogin.User_Login;
        }
    }
}
