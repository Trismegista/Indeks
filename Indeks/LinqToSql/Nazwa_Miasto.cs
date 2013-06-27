using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indeks.LinqToSql
{
    public partial class Nazwa_Miasto
    {
        public static Guid FindNazwiaMiastoByName(string nazwa)
        {
            DataClasses1DataContext db = new DataClasses1DataContext();
            return db.Nazwa_Miastos.Where(x => x.Nazwa_Miasto1 == nazwa).Select(x => x.Id_Nazwa_Miasto).SingleOrDefault();
        }

        public static List<string> GetMiastos()
        {
            DataClasses1DataContext db = new DataClasses1DataContext();
            return db.Nazwa_Miastos.OrderBy(x=>x.Nazwa_Miasto1).Select(x => x.Nazwa_Miasto1).ToList();
        }
    }
}
