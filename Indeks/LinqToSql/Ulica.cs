using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indeks.LinqToSql
{
    public partial class Ulica
    {
        public static List<string> GetUlicas()
        {
            DataClasses1DataContext db = new DataClasses1DataContext();
            return db.Ulicas.OrderBy(x=>x.Nazwa_Ulica).Select(x => x.Nazwa_Ulica).ToList();
        }

        public static Guid FindUlicaIdByName(string nazwa)
        {
            DataClasses1DataContext db = new DataClasses1DataContext();
            return db.Ulicas.Where(x => x.Nazwa_Ulica == nazwa).Select(x => x.Id_Ulica).SingleOrDefault();
        }
    }
}
