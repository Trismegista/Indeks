using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indeks.LinqToSql
{
    public partial class Wojewodztwo
    {
        public static List<string> GetWojewodztwos()
        {
            DataClasses1DataContext db = new DataClasses1DataContext();
            return db.Wojewodztwos.OrderBy(x=>x.Nazwa_Wojewodztwo).Select(x => x.Nazwa_Wojewodztwo).ToList();
        }

        public static Guid FindWojIdByNazwa(string nazwa)
        {
            DataClasses1DataContext db = new DataClasses1DataContext();
            return db.Wojewodztwos.Where(x => x.Nazwa_Wojewodztwo == nazwa).Select(x => x.Id_Wojewodztwo).SingleOrDefault();
        }
    }
}
