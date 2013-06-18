using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indeks.LinqToSql
{
    public partial class Typ_Zajec
    {
        public static List<string> GetZajecias()
        {
            DataClasses1DataContext db = new DataClasses1DataContext();
            return db.Typ_Zajecs.OrderBy(x => x.Typ_Zajec_Nazwa).Select(x => x.Typ_Zajec_Nazwa).ToList();
        }

        public static Guid FindZajeciasIdByName(string name)
        {
            DataClasses1DataContext db = new DataClasses1DataContext();
            return db.Typ_Zajecs.Where(x => x.Typ_Zajec_Nazwa == name).Select(x => x.Id_Zajecia).SingleOrDefault();
        }
    }
}
