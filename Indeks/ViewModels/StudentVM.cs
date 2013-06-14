using Indeks.Interfaces;
using Indeks.LinqToSql;
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
    public class StudentVM : ApplicationVM, INotifyPropertyChanged
    {
        public StudentVM()
        {
            ExecuteRegisterCommand = new Commanding(CreateStudent, CanCreateStudent);
        }

        public ICommand ExecuteRegisterCommand { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(String property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }

        private string _firstName;
        public string FirstName
        {
            get { return _firstName; }
            set
            {
                _firstName = value;
                OnPropertyChanged("FirstName");
            }
        }
        
        private string _lastName;
        public string LastName
        {
            get { return _lastName; }
            set
            {
                _lastName = value;
                OnPropertyChanged("LastName");
            }
        }

        private string _telephone;
        public string Telephone
        {
            get { return _telephone; }
            set
            {
                _telephone = value;
                OnPropertyChanged("Telephone");
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

        private string _passwordRepeat;
        public string PasswordRepeat
        {
            get { return _passwordRepeat; }
            set
            {
                _passwordRepeat = value;
                OnPropertyChanged("PasswordRepeat");
            }
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

        private bool CanCreateStudent(object parameter)
        {
            return true;
        }
        
        private void CreateStudent(object parameter)
        {
            if (_password != _passwordRepeat) return;

            DataClasses1DataContext context = new DataClasses1DataContext();
            var student = new LinqToSql.Student()
            {
                imie = _firstName,
                nazwisko = _lastName,
                telefon = _telephone,
                haslo = _password,
                login = _login
            };
            context.Students.InsertOnSubmit(student);
            context.SubmitChanges();

            Window frm = (Window)parameter;
            frm.Close();
        }
    }
}

