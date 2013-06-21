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
    public class RegistrationVM : ApplicationVM, INotifyPropertyChanged
    {
        public RegistrationVM()
        {
            ExecuteRegisterCommand = new Commanding(CreateUser, CanCreateUser);
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

        #region Bindings
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

        private string _e_Mail;
        public string E_Mail
        {
            get { return _e_Mail; }
            set
            {
                _e_Mail = value;
                OnPropertyChanged("E_Mail");
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

        private string _ulica;
        public string Ulica
        {
            get { return _ulica; }
            set
            {
                _ulica = value;
                OnPropertyChanged("Ulica");
            }
        }

        private string _numerDomu;
        public string NumerDomu
        {
            get { return _numerDomu; }
            set
            {
                _numerDomu = value;
                OnPropertyChanged("NumerDomu");
            }
        }

        private string _numerMieszkania;
        public string NumerMieszkania
        {
            get { return _numerMieszkania; }
            set
            {
                _numerMieszkania = value;
                OnPropertyChanged("NumerMieszkania");
            }
        }

        private string _miasto;
        public string Miasto
        {
            get { return _miasto; }
            set
            {
                _miasto = value;
                OnPropertyChanged("Miasto");
            }
        }

        private string _kod1;
        public string Kod1
        {
            get { return _kod1; }
            set
            {
                _kod1 = value;
                OnPropertyChanged("Kod1");
            }
        }

        private string _kod2;
        public string Kod2
        {
            get { return _kod2; }
            set
            {
                _kod2 = value;
                OnPropertyChanged("Kod2");
            }
        }

        private string _kraj;
        public string Kraj
        {
            get { return _kraj; }
            set
            {
                _kraj = value;
                OnPropertyChanged("Kraj");
            }
        }

        private string _wojewodztwo;
        public string Wojewodztwo
        {
            get { return _wojewodztwo; }
            set
            {
                _wojewodztwo = value;
                OnPropertyChanged("Wojewodztwo");
            }
        }

        private string _powiat;
        public string Powiat
        {
            get { return _powiat; }
            set
            {
                _powiat = value;
                OnPropertyChanged("Powiat");
            }
        }

        private string _gmina;
        public string Gmina
        {
            get { return _gmina; }
            set
            {
                _gmina = value;
                OnPropertyChanged("Gmina");
            }
        }

        private string _poczta;
        public string Poczta
        {
            get { return _poczta; }
            set
            {
                _poczta = value;
                OnPropertyChanged("Poczta");
            }
        }

        #endregion


        private bool CanCreateUser(object parameter)
        {
            if (String.IsNullOrEmpty(_firstName) || String.IsNullOrEmpty(_poczta) || String.IsNullOrEmpty(_gmina) || String.IsNullOrEmpty(_powiat) || String.IsNullOrEmpty(_wojewodztwo) ||
                String.IsNullOrEmpty(_kraj) || String.IsNullOrEmpty(_kod2) || String.IsNullOrEmpty(_kod1) || String.IsNullOrEmpty(_miasto) || String.IsNullOrEmpty(_numerMieszkania) ||
                String.IsNullOrEmpty(_numerDomu) || String.IsNullOrEmpty(_ulica) || String.IsNullOrEmpty(_login) || String.IsNullOrEmpty(_passwordRepeat) || String.IsNullOrEmpty(_e_Mail) ||
                String.IsNullOrEmpty(_telephone) || String.IsNullOrEmpty(_lastName) || String.IsNullOrEmpty(_firstName)) return false;
            if (!IsNumeric(_numerMieszkania) && !IsNumeric(_telephone) && !IsNumeric(_kod2) && !IsNumeric(_kod1)) return false;
            if (Convert.ToInt32(_kod1) > 99 || Convert.ToInt32(_kod2) > 999 || ( Convert.ToInt32(_telephone)>999999999 && Convert.ToInt32(_telephone)<100000000)) return false;
            if (_password != _passwordRepeat) return false;
            return true;
        }
        
        private void CreateUser(object parameter)
        {
            DataClasses1DataContext context = new DataClasses1DataContext();
            string[] kod = { _kod1, _kod2 };

            var adresData = new Adre
            {
                Ulica = _ulica,
                Nr_Domu = _numerDomu,
                Nr_Mieszkania = Convert.ToInt32(_numerMieszkania),
                Miasto = _miasto,
                Kod_Pocztowy = string.Join("-",kod),
                Poczta = _poczta,
                Gmina = _gmina,
                Powiat = _powiat,
                Woj = _wojewodztwo,
                Kraj = _kraj,
            };
            context.Adres.InsertOnSubmit(adresData);
            context.SubmitChanges();

            var userLogin = new Login
            {
                User_Login = _login,
                Student_Imie = _firstName,
                Student_Nazwisko = _lastName,
                Student_E_Mail = E_Mail,
                Student_Telefon = _telephone,
                Haslo = _password,
                Id_Adres = adresData.Id_Adres
            };
            context.Logins.InsertOnSubmit(userLogin);
            context.SubmitChanges();

            var student = new Student
            {
                Id_Login = userLogin.Id_Login,
            };
            context.Students.InsertOnSubmit(student);
            context.SubmitChanges();

            Window frm = (Window)parameter;
            frm.Close();
        }
    }
}

