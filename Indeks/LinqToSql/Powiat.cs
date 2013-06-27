using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indeks.LinqToSql
{
    public partial class Powiat
    {
        public static List<string> GetPowiats()
        {
            DataClasses1DataContext db = new DataClasses1DataContext();
            return db.Powiats.OrderBy(x=>x.Nazwa_Powiat).Select(x => x.Nazwa_Powiat).ToList();
        }

        public static Guid FindPowiatIdByNazwa(string nazwa)
        {
            DataClasses1DataContext db = new DataClasses1DataContext();
            return db.Powiats.Where(x => x.Nazwa_Powiat == nazwa).Select(x => x.Id_Powiat).SingleOrDefault();
        }
    }
}
