using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indeks.LinqToSql
{
    public class StudentData
    {
        public string User_Login;
        public string Student_Imie;
        public string Student_Nazwisko;
        public string Student_Telefon;
        public string Studetn_E_Mail;
        public string Haslo;
        public string Numer_Domu;
        public int Numer_Mieszkania;
        public string Poczta;
        public string kod1;
        public string kod2;
        public string Nazwa_Miasto;
        public string Nazwa_Ulica;
        public string Nazwa_Kraj;
        public string Nazwa_Powiat;
        public string Nazwa_Gmina;
        public string Nazwa_Wojewodztwo;
        public Guid Id_Login;

        public void loadData(Login login)
        {
            DataClasses1DataContext db = new DataClasses1DataContext();
            User_Login = login.User_Login;
            Student_Imie = login.Student_Imie;
            Student_Nazwisko = login.Student_Nazwisko;
            Student_Telefon = login.Student_Telefon;
            Studetn_E_Mail = login.Student_E_Mail;
            Haslo = login.Haslo;
            Numer_Domu = login.Numer_Domu;
            Numer_Mieszkania = Convert.ToInt32(login.Numer_Mieszkania);
            Id_Login = login.Id_Login;

            Miejscowosc miejscowosc = db.Adres.Where(x => x.Id_Adres == login.Id_Adres).SingleOrDefault().Miejscowosc;
            Region region = db.Adres.Where(x => x.Id_Adres == login.Id_Adres).SingleOrDefault().Region;

            Poczta = miejscowosc.Poczta;

            string[] kody = miejscowosc.Kod.Split('-');
            kod1 = kody[0];
            kod2 = kody[1];

            Nazwa_Miasto = db.Nazwa_Miastos.Where(x => x.Id_Nazwa_Miasto == miejscowosc.Id_Nazwa_Miasto).Select(x => x.Nazwa_Miasto1).SingleOrDefault();
            Nazwa_Ulica = db.Ulicas.Where(x => x.Id_Ulica == miejscowosc.Id_Ulica).Select(x => x.Nazwa_Ulica).SingleOrDefault();
            Nazwa_Kraj = db.Krajs.Where(x => x.Id_Kraj == region.Id_Kraj).Select(x => x.Nazwa_Kraj).SingleOrDefault();
            Nazwa_Powiat = db.Powiats.Where(x => x.Id_Powiat == region.Id_Powiat).Select(x => x.Nazwa_Powiat).SingleOrDefault();
            Nazwa_Gmina = db.Gminas.Where(x => x.Id_Gmina == region.Id_Gmina).Select(x => x.Nazwa_Gmina).SingleOrDefault();
            Nazwa_Wojewodztwo = db.Wojewodztwos.Where(x => x.Id_Wojewodztwo == region.Id_Wojewodztwo).Select(x => x.Nazwa_Wojewodztwo).SingleOrDefault();
        }
    }
}
