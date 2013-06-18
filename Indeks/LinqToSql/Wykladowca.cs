using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indeks.LinqToSql
{
    public partial class Wykladowca
    {
        public static List<string> GetWykladowcas()
        {
            DataClasses1DataContext db = new DataClasses1DataContext();
            var idWykladowcasList = db.Wykladowcas.OrderBy(x=>x.Wykladowca_Nazwisko).Select(x => x.Id_Wykladowcy).ToList();
            List<string> nazwiskoImieList = new List<string>();
            foreach (Guid val in idWykladowcasList)
            {
                var nazwiskoWykladowcy = db.Wykladowcas.Where(x => x.Id_Wykladowcy == val).Select(x => x.Wykladowca_Nazwisko).SingleOrDefault();
                var imieWykladowcy = db.Wykladowcas.Where(x => x.Id_Wykladowcy == val).Select(x => x.Wykladowca_Imie).SingleOrDefault();
                var nrWykladowcy = db.Wykladowcas.Where(x => x.Id_Wykladowcy == val).Select(x => x.Nr_Wykladowcy).SingleOrDefault().ToString();

                string nazwiskoImie = nrWykladowcy.ToString()+"-"+nazwiskoWykladowcy.ToString()+"-"+ imieWykladowcy.ToString();
                nazwiskoImieList.Add(nazwiskoImie);
            }
            return nazwiskoImieList;
        }

        public static Guid FindWykladowcaIdByName(string name)
        {
            DataClasses1DataContext db = new DataClasses1DataContext();
            string[] nrNazwiskoImie = name.Split('-');
            return db.Wykladowcas.Where(x => x.Nr_Wykladowcy.ToString() == nrNazwiskoImie[0]).Select(x => x.Id_Wykladowcy).SingleOrDefault();
        }
    }
}
