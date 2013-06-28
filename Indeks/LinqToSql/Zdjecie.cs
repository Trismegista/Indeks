using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indeks.LinqToSql
{
    public partial class Zdjecie
    {
        public static string GetZdjecieSource(Guid idLogin)
        {
            DataClasses1DataContext db = new DataClasses1DataContext();
            var idZdjecie = db.Logins.Where(x => x.Id_Login == idLogin).Select(x => x.Id_Zdjecie).SingleOrDefault();
            return db.Zdjecies.Where(x => x.Id_Zdjecia == idZdjecie).Select(x => x.Sciezka).SingleOrDefault().ToString();
        }
    }
}
