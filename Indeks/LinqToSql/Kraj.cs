using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indeks.LinqToSql
{
    public partial class Kraj
    {
        public static List<string> GetKrajs()
        {
            DataClasses1DataContext db = new DataClasses1DataContext();
            return db.Krajs.OrderBy(x=>x.Nazwa_Kraj).Select(x => x.Nazwa_Kraj).ToList();
        }

        public static Guid FindKrajIdByName(string nazwa)
        {
            DataClasses1DataContext db = new DataClasses1DataContext();
            return db.Krajs.Where(x => x.Nazwa_Kraj == nazwa).Select(x => x.Id_Kraj).SingleOrDefault();
        }
    }
}
