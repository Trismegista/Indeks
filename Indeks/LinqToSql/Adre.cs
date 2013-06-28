using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indeks.LinqToSql
{
    public partial class Adre
    {
        public static bool CheckIfAdresExist(Guid idMiejscowosc, Guid idRegion)
        {
            DataClasses1DataContext db = new DataClasses1DataContext();
            var result = db.Adres.Where(x => x.Id_Miejscowosc == idMiejscowosc).Where(x => x.Id_Region == idRegion).SingleOrDefault();
            if (result == null)
                return false;
            return true;
        }

        public static Adre CheckAdreExist(Guid idMiejscowosc, Guid idRegion)
        {
            DataClasses1DataContext db = new DataClasses1DataContext();
            return db.Adres.Where(x => x.Id_Miejscowosc == idMiejscowosc).Where(x => x.Id_Region == idRegion).SingleOrDefault();
        }
    }
}
