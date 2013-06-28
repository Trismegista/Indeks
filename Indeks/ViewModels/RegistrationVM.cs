using Indeks.Interfaces;
using Indeks.LinqToSql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Linq;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Indeks.ViewModels
{
    public class RegistrationVM : ApplicationVM, INotifyPropertyChanged
    {
        public bool edycja;
        StudentData _student;
        public RegistrationVM()
        {
            edycja = false;
            ExecuteRegisterCommand = new Commanding(CreateUser, CanCreateUser);

            KrajName = Kraj.GetKrajs();
            WojewodztwoName = Wojewodztwo.GetWojewodztwos();
            PowiatName = Powiat.GetPowiats();
            GminaName = Gmina.GetGminas();
            UlicaName = Ulica.GetUlicas();
            MiastoName = Nazwa_Miasto.GetMiastos();
        }

        Login _studentData;
        public RegistrationVM(Login studentData)
        {
            edycja = true;
            ExecuteRegisterCommand = new Commanding(CreateUser, CanCreateUser);

            _studentData = studentData;
            KrajName = Kraj.GetKrajs();
            WojewodztwoName = Wojewodztwo.GetWojewodztwos();
            PowiatName = Powiat.GetPowiats();
            GminaName = Gmina.GetGminas();
            UlicaName = Ulica.GetUlicas();
            MiastoName = Nazwa_Miasto.GetMiastos();

            StudentData student = new StudentData();
            student.loadData(studentData);
            FirstName = student.Student_Imie;
            LastName = student.Student_Nazwisko;
            Telephone = student.Student_Telefon;
            E_Mail = student.Studetn_E_Mail;
            Login = student.User_Login;
            Password = student.Haslo;
            PasswordRepeat = student.Haslo;
            NumerDomu = student.Numer_Domu;
            NumerMieszkania = student.Numer_Mieszkania.ToString();
            SelectedUlica = student.Nazwa_Ulica;
            SelectedMiasto = student.Nazwa_Miasto;
            Kod1 = student.kod1;
            Kod2 = student.kod2;
            SelectedWojewodztwo = student.Nazwa_Wojewodztwo;
            SelectedPowiat = student.Nazwa_Powiat;
            SelectedGmina = student.Nazwa_Gmina;
            SelectedKraj = student.Nazwa_Kraj;
            Poczta = student.Poczta;

            _student = student;
            
        }
        public ICommand ExecuteRegisterCommand { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string property = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }

        #region Bindings

        #region From <-

        private string _valitadionMessage;
        public string ValitadionMessage
        {
            get { return _valitadionMessage; }
            set
            {
                _valitadionMessage = value;
                OnPropertyChanged();
            }
        }
        private string _firstName;
        public string FirstName
        {
            get { return _firstName; }
            set
            {
                _firstName = value;
                OnPropertyChanged();
            }
        }
        
        private string _lastName;
        public string LastName
        {
            get { return _lastName; }
            set
            {
                _lastName = value;
                OnPropertyChanged();
            }
        }

        private string _telephone;
        public string Telephone
        {
            get { return _telephone; }
            set
            {
                _telephone = value;
                OnPropertyChanged();
            }
        }

        private string _e_Mail;
        public string E_Mail
        {
            get { return _e_Mail; }
            set
            {
                _e_Mail = value;
                OnPropertyChanged();
            }
        }

        private string _password;
        public string Password
        {
            get { return _password; }
            set
            {
                _password = value;
                OnPropertyChanged();
            }
        }

        private string _passwordRepeat;
        public string PasswordRepeat
        {
            get { return _passwordRepeat; }
            set
            {
                _passwordRepeat = value;
                OnPropertyChanged();
            }
        }

        private string _login;
        public string Login
        {
            get { return _login; }
            set
            {
                _login = value;
                OnPropertyChanged();
            }
        }

        private string _selectedUlica;
        public string SelectedUlica
        {
            get { return _selectedUlica; }
            set
            {
                _selectedUlica = value;
                OnPropertyChanged();
            }
        }

        private string _numerDomu;
        public string NumerDomu
        {
            get { return _numerDomu; }
            set
            {
                _numerDomu = value;
                OnPropertyChanged();
            }
        }

        private string _numerMieszkania;
        public string NumerMieszkania
        {
            get { return _numerMieszkania; }
            set
            {
                _numerMieszkania = value;
                OnPropertyChanged();
            }
        }

        private string _selectedMiasto;
        public string SelectedMiasto
        {
            get { return _selectedMiasto; }
            set
            {
                _selectedMiasto = value;
                OnPropertyChanged();
            }
        }

        private string _kod1;
        public string Kod1
        {
            get { return _kod1; }
            set
            {
                _kod1 = value;
                OnPropertyChanged();
            }
        }

        private string _kod2;
        public string Kod2
        {
            get { return _kod2; }
            set
            {
                _kod2 = value;
                OnPropertyChanged();
            }
        }

        private string _selectedKraj;
        public string SelectedKraj
        {
            get { return _selectedKraj; }
            set
            {
                _selectedKraj = value;
                OnPropertyChanged();
            }
        }

        private string _selectedWojewodztwo;
        public string SelectedWojewodztwo
        {
            get { return _selectedWojewodztwo; }
            set
            {
                _selectedWojewodztwo = value;
                OnPropertyChanged();
            }
        }

        private string _selectedPowiat;
        public string SelectedPowiat
        {
            get { return _selectedPowiat; }
            set
            {
                _selectedPowiat = value;
                OnPropertyChanged();
            }
        }

        private string _selectedGmina;
        public string SelectedGmina
        {
            get { return _selectedGmina; }
            set
            {
                _selectedGmina = value;
                OnPropertyChanged();
            }
        }

        private string _poczta;
        public string Poczta
        {
            get { return _poczta; }
            set
            {
                _poczta = value;
                OnPropertyChanged();
            }
        }
        #endregion

        #region Binding to ->
        private List<string> _miastoName;
        public List<string> MiastoName
        {
            get
            {
                return _miastoName;
            }
            set
            {
                _miastoName = value;
                OnPropertyChanged();
            }
        }
        private List<string> _ulicaName;
        public List<string> UlicaName
        {
            get
            {
                return _ulicaName;
            }
            set
            {
                _ulicaName = value;
                OnPropertyChanged();
            }
        }
        private List<string> _krajName;
        public List<string> KrajName
        {
            get
            {
                return _krajName;
            }
            set
            {
                _krajName = value;
                OnPropertyChanged();
            }
        }
        private List<string> _wojewodztwoName;
        public List<string> WojewodztwoName
        {
            get
            {
                return _wojewodztwoName;
            }
            set
            {
                _wojewodztwoName = value;
                OnPropertyChanged();
            }
        }
        private List<string> _powiatName;
        public List<string> PowiatName
        {
            get
            {
                return _powiatName;
            }
            set
            {
                _powiatName = value;
                OnPropertyChanged();
            }
        }
        private List<string> _gminaName;
        public List<string> GminaName
        {
            get
            {
                return _gminaName;
            }
            set
            {
                _gminaName = value;
                OnPropertyChanged();
            }
        }

        #endregion

        #endregion


        private bool CanCreateUser(object parameter)
        {
            Login log = new Login();
            if (String.IsNullOrEmpty(_login))
            {
                ValitadionMessage = "Wpisz login";
                return false;
            }
            if (log.FindUserByLogin(_login) != null && edycja == false)
            {
                ValitadionMessage = "Login zajęty";
                return false;
            }
            if (String.IsNullOrEmpty(_firstName))
            {
                ValitadionMessage = "Wpisz imię";
                return false;
            }
            if (Regex.Match(_firstName, @"\d").Success)
            {
                ValitadionMessage = "Błędne imie ( Tylko litery od A-Z )";
                return false;
            }
            if (String.IsNullOrEmpty(_lastName))
            {
                ValitadionMessage = "Wpisz imię";
                return false;
            }
            if (Regex.Match(_lastName, @"\d").Success)
            {
                ValitadionMessage = "Błędne nazwisko ( tylko litery od A-Z )";
                return false;
            }
            if (String.IsNullOrEmpty(_telephone))
            {
                ValitadionMessage = "Wpisz nr.telefonu";
                return false;
            }
            if (!Regex.Match(_telephone, @"^[\d]{9}$").Success || Regex.IsMatch(_telephone, @"(?i)^[a-z]+$") || Regex.Match(_telephone, @"^[\d]{10}$").Success)
            {
                ValitadionMessage = "Błędny nr.telefonu ( numer 9-cio cyfrowy )";
                return false;
            }
            if (String.IsNullOrEmpty(_e_Mail))
            {
                ValitadionMessage = "Wpisz e-mail";
                return false;
            }
            if (!Regex.Match(_e_Mail, @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$").Success)
            {
                ValitadionMessage = "Błędny e_mail ( xxxx@yyy.zz )";
                return false;
            }
            if (String.IsNullOrEmpty(_password))
            {
                ValitadionMessage = "Wpisz hasło";
                return false;
            }
            if (String.IsNullOrEmpty(_passwordRepeat))
            {
                ValitadionMessage = "Powtórz hasło";
                return false;
            }
            if (_passwordRepeat != _password)
            {
                ValitadionMessage = "Hasła są różne";
                return false;
            }
            if (String.IsNullOrEmpty(_selectedUlica))
            {
                ValitadionMessage = "Wybierz ulicę";
                return false;
            }
            if (String.IsNullOrEmpty(_numerDomu))
            {
                ValitadionMessage = "Wpisz nr. domu";
                return false;
            }
            if (Regex.Match(_numerDomu, @"[^a-zA-Z0-9]").Success || _numerDomu.Length > 4)
            {
                ValitadionMessage = "Zły nr. domu ( tylko cyfry 0-9 i litery, do 4ch znaków )";
                return false;
            }
            if (String.IsNullOrEmpty(_numerMieszkania))
            {
                ValitadionMessage = "Wpisz nr. mieszkania";
                return false;
            }
            if (!Regex.Match(_numerMieszkania, @"^[0-9]").Success || Regex.Match(_numerMieszkania, @"[a-zA-Z]").Success || _numerMieszkania.Length > 3)
            {
                ValitadionMessage = "Zły nr. mieszkania ( tylko cyfry )";
                return false;
            }
            if (String.IsNullOrEmpty(_selectedMiasto))
            {
                ValitadionMessage = "Wybierz miasto";
                return false;
            }
            if (String.IsNullOrEmpty(_kod1) || String.IsNullOrEmpty(_kod2))
            {
                ValitadionMessage = "Wpisz kod pocztowy";
                return false;
            }
            if (!Regex.Match(_kod1, @"^[\d]{2}$").Success || !Regex.Match(_kod2, @"^[\d]{3}$").Success || _kod1.Length > 2 || _kod2.Length > 3)
            {
                ValitadionMessage = "Błędny kod pocztowy ( xx-xxx )";
                return false;
            }
            if (String.IsNullOrEmpty(_poczta))
            {
                ValitadionMessage = "Wpisz pocztę";
                return false;
            }
            if (Regex.Match(_poczta, @"^[0-9]+$").Success || !Regex.IsMatch(_poczta, @"\w"))
            {
                ValitadionMessage = "Zła nazwa poczty ( Tylko litery od A-Z )";
                return false;
            }
            if (String.IsNullOrEmpty(_selectedGmina))
            {
                ValitadionMessage = "Wybierz gminę";
                return false;
            }
            if (String.IsNullOrEmpty(_selectedPowiat))
            {
                ValitadionMessage = "Wybierz powiat";
                return false;
            }
            if (String.IsNullOrEmpty(_selectedWojewodztwo))
            {
                ValitadionMessage = "Wybierz województwo";
                return false;
            }
            if (String.IsNullOrEmpty(_selectedKraj))
            {
                ValitadionMessage = "Wybierz kraj";
                return false;
            }
            ValitadionMessage = "";
            return true;
        }
        
        private void CreateUser(object parameter)
        {
            if (edycja == false)
            {
                DataClasses1DataContext context = new DataClasses1DataContext();

                Miejscowosc oldMiejscowosc = Miejscowosc.CheckMiejscowoscExist(Ulica.FindUlicaIdByName(_selectedUlica), 
                                                                               Nazwa_Miasto.FindNazwiaMiastoByName(_selectedMiasto));

                Region oldRegion = Region.CheckRegionExist(Kraj.FindKrajIdByName(_selectedKraj),
                                                           Powiat.FindPowiatIdByNazwa(_selectedPowiat),
                                                           Gmina.FindGminaIdByName(_selectedGmina),
                                                           Wojewodztwo.FindWojIdByNazwa(_selectedWojewodztwo));
                if (oldMiejscowosc == null)
                {
                    var miejscowosc = new Miejscowosc
                    {
                        Id_Nazwa_Miasto = Nazwa_Miasto.FindNazwiaMiastoByName(_selectedMiasto),
                        Id_Ulica = Ulica.FindUlicaIdByName(_selectedUlica),
                        Poczta = _poczta,
                        Kod = _kod1.ToString() + '-' + _kod2.ToString()
                    };
                    context.Miejscowoscs.InsertOnSubmit(miejscowosc);
                    context.SubmitChanges();
                    oldMiejscowosc = miejscowosc;
                }

                if (oldRegion == null)
                {
                    var region = new Region
                    {
                        Id_Kraj = Kraj.FindKrajIdByName(_selectedKraj),
                        Id_Powiat = Powiat.FindPowiatIdByNazwa(_selectedPowiat),
                        Id_Gmina = Gmina.FindGminaIdByName(_selectedGmina),
                        Id_Wojewodztwo = Wojewodztwo.FindWojIdByNazwa(_selectedWojewodztwo)
                    };
                    context.Regions.InsertOnSubmit(region);
                    context.SubmitChanges();
                    oldRegion = region;
                }
                Adre oldAdres = Adre.CheckAdreExist(oldMiejscowosc.Id_Miejscowosc, oldRegion.Id_Region);
                if (oldAdres == null)
                {
                    var adresData = new Adre
                    {
                        Id_Miejscowosc = oldMiejscowosc.Id_Miejscowosc,
                        Id_Region = oldRegion.Id_Region
                    };
                    context.Adres.InsertOnSubmit(adresData);
                    context.SubmitChanges();
                    oldAdres = adresData;
                }

                var userLogin = new Login
                {
                    User_Login = _login,
                    Student_Imie = _firstName,
                    Student_Nazwisko = _lastName,
                    Student_E_Mail = E_Mail,
                    Student_Telefon = _telephone,
                    Haslo = _password,
                    Id_Adres = oldAdres.Id_Adres,
                    Numer_Domu = _numerDomu,
                    Numer_Mieszkania = Convert.ToInt32(_numerMieszkania),
                    Id_Zdjecie = new Guid("3c554039-2175-4aaa-9001-1372b82cb04c")
                };

                context.Logins.InsertOnSubmit(userLogin);
                context.SubmitChanges();

                var student = new Student
                {
                    Id_Login = userLogin.Id_Login,
                };
                context.Students.InsertOnSubmit(student);
                context.SubmitChanges();
            }
            if (edycja == true)
            {
                DataClasses1DataContext context = new DataClasses1DataContext();
                var idKraj = Kraj.FindKrajIdByName(_selectedKraj);
                var idPowiat = Powiat.FindPowiatIdByNazwa(_selectedPowiat);
                var idGmina = Gmina.FindGminaIdByName(_selectedGmina);
                var idWojewodztwo = Wojewodztwo.FindWojIdByNazwa(_selectedWojewodztwo);
                var idNazwa_Miasto = Nazwa_Miasto.FindNazwiaMiastoByName(_selectedMiasto);
                var idUlica = Ulica.FindUlicaIdByName(_selectedUlica);
                Miejscowosc oldMiejscowosc = Miejscowosc.CheckMiejscowoscExist(idNazwa_Miasto, idUlica);
                Region oldRegion = Region.CheckRegionExist(idKraj, idPowiat, idGmina, idWojewodztwo);
                Adre oldAdres;
                if (oldMiejscowosc != null && oldRegion != null)
                {
                    oldAdres = Adre.CheckAdreExist(oldMiejscowosc.Id_Miejscowosc, oldRegion.Id_Region);
                    if (_studentData.Id_Adres == oldAdres.Id_Adres && !Student.AnyChanges(_studentData, _login, _firstName, _lastName, _telephone, _e_Mail, _password, _numerDomu, Convert.ToInt32(_numerMieszkania)))
                    {
                        MessageBox.Show("Nie dokonano żadnych zmian w treści", "Uwaga", MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }
                    else
                    {
                        Login log = context.Logins.Single(x => x.Id_Login == _student.Id_Login);
                        log.Id_Adres = oldAdres.Id_Adres;
                        log.User_Login = _login;
                        log.Student_Imie = _firstName;
                        log.Student_Nazwisko = _lastName;
                        log.Student_Telefon = _telephone;
                        log.Student_E_Mail = _e_Mail;
                        log.Haslo = _password;
                        log.Numer_Domu = _numerDomu;
                        log.Numer_Mieszkania = Convert.ToInt32(_numerMieszkania);
                        context.SubmitChanges();
                    }
                }
                if (oldMiejscowosc == null || oldRegion == null)
                {
                    if (oldMiejscowosc == null)
                    {
                        var newMiejscowosc = new Miejscowosc
                        {
                            Id_Nazwa_Miasto = idNazwa_Miasto,
                            Id_Ulica = idUlica,
                            Poczta = _poczta,
                            Kod = _kod1.ToString() + '-' + _kod2.ToString()
                        };
                        context.Miejscowoscs.InsertOnSubmit(newMiejscowosc);
                        context.SubmitChanges();
                        oldMiejscowosc = newMiejscowosc;
                    }
                    if (oldRegion == null)
                    {
                        var newRegion = new Region
                        {
                            Id_Kraj = idKraj,
                            Id_Wojewodztwo = idWojewodztwo,
                            Id_Powiat = idPowiat,
                            Id_Gmina = idGmina
                        };
                        context.Regions.InsertOnSubmit(newRegion);
                        context.SubmitChanges();
                        oldRegion = newRegion;
                    }

                    var newAdres = new Adre
                    {
                        Id_Miejscowosc = oldMiejscowosc.Id_Miejscowosc,
                        Id_Region = oldRegion.Id_Region
                    };
                    context.Adres.InsertOnSubmit(newAdres);
                    context.SubmitChanges();

                    Login log = context.Logins.Single(x => x.Id_Login == _student.Id_Login);
                    log.Id_Adres = newAdres.Id_Adres;
                    context.SubmitChanges();
                    context.Refresh(RefreshMode.OverwriteCurrentValues, newAdres);
                }
            }
            Window frm = (Window)parameter;
            frm.Close();
        }
    }
}

