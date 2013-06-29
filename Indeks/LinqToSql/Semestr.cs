using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Indeks.LinqToSql
{
    public partial class Semestr
    {
        public List<Przedmiot> Przedmioty
        {
            get
            {
                DataClasses1DataContext db = new DataClasses1DataContext();
                var grupa_id = (Guid)Application.Current.Properties["idgrupa"];
                return GrupaSemestrPrzedmiots.Where(x => x.Id_Semestr == this.Id_Semestr && x.Id_Grupa == grupa_id).Select(x => x.Przedmiot).ToList();
            }
        }
        public static List<string> GetSemestersNames()
        {
            DataClasses1DataContext db = new DataClasses1DataContext();
            return db.Semestrs.Where(x => x.Semestr_Nazwa != "").OrderBy(x => x.Semestr_Nazwa).Select(x => x.Semestr_Nazwa).ToList();
        }

        public static Guid FindSemestrIdByName(string name)
        {
            DataClasses1DataContext db = new DataClasses1DataContext();
            return db.Semestrs.Where(x => x.Semestr_Nazwa == name).Select(x => x.Id_Semestr).SingleOrDefault();
        }

        public static bool CheckPrzedmiotExistInSemester(Guid idSemestr, Guid idGrupa, Guid idPrzedmiot)
        {
            DataClasses1DataContext db = new DataClasses1DataContext();
            var result = db.GrupaSemestrPrzedmiots.Where(x => x.Id_Grupa == idGrupa).Where(x => x.Id_Semestr == idSemestr).Where(x=>x.Id_Przedmiot==idPrzedmiot).SingleOrDefault();
            if (result == null)
                return false;
            return true;
        }

        public static bool CheckSemestrExistInGroup(Guid idGroup, Guid idSemestr)
        {
            DataClasses1DataContext db = new DataClasses1DataContext();
            var semestersList = db.GrupaSemestrPrzedmiots.Where(x => x.Id_Grupa == idGroup).Where(x => x.Id_Semestr == idSemestr).ToList();
            if (semestersList.Count == 0)
                return false;
            return true;
        }

        public string NaglowekPrzedmiot { get { return "Przedmiot"; } }
        public string NaglowekWykladowca { get { return "Wykładowca"; } }
        public string NaglowekZajecia { get { return "Zajęcia"; } }
        public string NaglowekETCS { get { return "ETCS"; } }
        public string NaglowekGodzina { get { return "Godziny"; } }
    }

}
