using Indeks.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Indeks.LinqToSql
{
    public partial class Student
    {        
        public static List<int> CurentUserIndexList(Guid login)
        {
            DataClasses1DataContext db = new DataClasses1DataContext();
            var result = db.Students.Where(x => x.Id_Login == login);
            var indexNr = result.Select(x => x.Nr_Indeksu).ToList();
            return indexNr;
        }
        public static List<string> CurentStudentGroupList(int index)
        {
            DataClasses1DataContext db = new DataClasses1DataContext();
            Guid idStudent = db.Students.Where(x => x.Nr_Indeksu == index).Select(x => x.Id_Student).SingleOrDefault();
            List<Grupa> grupaList = db.StudentGrupas.Where(x => x.Id_Student == idStudent).Select(x => x.Grupa).ToList();
            List<string> grupaStringList = new List<string>();
            foreach (Grupa grupa in grupaList)
            {
            string nazwaKierunku = db.Kieruneks.Where(x => x.Id_Kierunek == grupa.Id_Kierunek).Select(x => x.Kierunek_Nazwa).SingleOrDefault().ToString();
            string nazwaCiagu = db.Ciags.Where(x => x.Id_Ciag == grupa.Id_Ciag).Select(x => x.Ciag_Nazwa).SingleOrDefault().ToString();
            string nazwaGrupy = db.GrupaNazwas.Where(x => x.Id_Grupa_Nazwa == grupa.Id_Grupa_Nazwa).Select(x => x.Grupa_Nazwa).SingleOrDefault().ToString();
                string fullName = nazwaKierunku+"-"+nazwaCiagu+"-"+nazwaGrupy;
                grupaStringList.Add(fullName);
            }
            return grupaStringList;
        }

        public static IQueryable<Semestr> Semesters(string fullGrupaName)
        {
            DataClasses1DataContext db = new DataClasses1DataContext();
            string[] splitGrupa = fullGrupaName.Split('-');
            Guid idKierunek = db.Kieruneks.Where(x => x.Kierunek_Nazwa == splitGrupa[0]).Select(x => x.Id_Kierunek).SingleOrDefault();
            Guid idCiag = db.Ciags.Where(x => x.Ciag_Nazwa == splitGrupa[1]).Select(x => x.Id_Ciag).SingleOrDefault();
            Guid idGrupaNazwa = db.GrupaNazwas.Where(x => x.Grupa_Nazwa == splitGrupa[2]).Select(x => x.Id_Grupa_Nazwa).SingleOrDefault();
            Guid idgrupa = db.Grupas.Where(x => x.Id_Kierunek == idKierunek).Where(x => x.Id_Ciag == idCiag).Where(x => x.Id_Grupa_Nazwa == idGrupaNazwa).Select(x => x.Id_Grupa).SingleOrDefault();
            //var cos = db.GrupaSemestrPrzedmiotWykladowcas.Where(x => x.Id_Grupa == idgrupa).Select(x => x.Semestr);            
            Application.Current.Properties["idgrupa"] = idgrupa;
            return db.GrupaSemestrPrzedmiots.Where(x => x.Id_Grupa == idgrupa).Select(x => x.Semestr).GroupBy(x => x.Id_Semestr).Select(x => x.First());
        }

        public static Guid FindStudentIdByIndex(int index)
        {
            DataClasses1DataContext db = new DataClasses1DataContext();
            return db.Students.Where(x => x.Nr_Indeksu == index).Select(x => x.Id_Student).SingleOrDefault();
        }

        public static bool AnyChanges(Login login, string name, string im, string naz, string tel, string mail, string pas, string nrD, int nrM)
        {
            if (login.User_Login != name ||
                    login.Student_Imie != im ||
                    login.Student_Nazwisko != naz ||
                    login.Student_Telefon != tel ||
                    login.Student_E_Mail != mail ||
                    login.Haslo != pas ||
                    login.Numer_Domu != nrD ||
                    login.Numer_Mieszkania != nrM)
                return true;
            return false;
        }

    }
}
