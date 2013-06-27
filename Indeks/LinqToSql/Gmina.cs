using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indeks.LinqToSql
{
    public partial class Gmina
    {
        public static List<string> GetGminas()
        {
            DataClasses1DataContext db = new DataClasses1DataContext();
            return db.Gminas.OrderBy(x=>x.Nazwa_Gmina).Select(x => x.Nazwa_Gmina).ToList();
        }

        public static Guid FindGminaIdByName(string nazwa)
        {
            DataClasses1DataContext db = new DataClasses1DataContext();
            return db.Gminas.Where(x => x.Nazwa_Gmina == nazwa).Select(x => x.Id_Gmina).SingleOrDefault();
        }
    }
}
