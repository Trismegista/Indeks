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
        public string NaglowekPrzedmiot { get { return "Przedmiot"; } }
        public string NaglowekWykladowca { get { return "Wykładowca"; } }
        public string NaglowekZajecia { get { return "Zajęcia"; } }
        public string NaglowekETCS { get { return "ETCS"; } }
        public string NaglowekGodzina { get { return "Godziny"; } }
    }
}
