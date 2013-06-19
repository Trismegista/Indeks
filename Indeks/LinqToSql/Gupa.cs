using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indeks.LinqToSql
{
    public partial class Grupa
    {

        public static List<string> GetGrupas()
        {
            DataClasses1DataContext db = new DataClasses1DataContext();
            return db.GrupaNazwas.Select(x => x.Grupa_Nazwa).ToList();
        }

        public static Guid FindGrupaIdByName(string name)
        {
            DataClasses1DataContext db = new DataClasses1DataContext();
            return db.GrupaNazwas.Where(x => x.Grupa_Nazwa == name).Select(x => x.Id_Grupa_Nazwa).SingleOrDefault();
        }

        public static Guid FindGrupaIdByFullName(string fullGrupaName)
        {
            DataClasses1DataContext db = new DataClasses1DataContext();
            string[] splitGrupa = fullGrupaName.Split('-');
            Guid idKierunek = db.Kieruneks.Where(x => x.Kierunek_Nazwa == splitGrupa[0]).Select(x => x.Id_Kierunek).SingleOrDefault();
            Guid idCiag = db.Ciags.Where(x => x.Ciag_Nazwa == splitGrupa[1]).Select(x => x.Id_Ciag).SingleOrDefault();
            Guid idGrupaNazwa = db.GrupaNazwas.Where(x => x.Grupa_Nazwa == splitGrupa[2]).Select(x => x.Id_Grupa_Nazwa).SingleOrDefault();
            return db.Grupas.Where(x => x.Id_Kierunek == idKierunek).Where(x => x.Id_Ciag == idCiag).Where(x => x.Id_Grupa_Nazwa == idGrupaNazwa).Select(x => x.Id_Grupa).SingleOrDefault();
        }
    }
}
