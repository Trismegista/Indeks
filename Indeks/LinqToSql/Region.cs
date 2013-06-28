using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indeks.LinqToSql
{
    public partial class Region
    {
        public static bool CheckIfRegionExist(Guid idKraj, Guid idPowiat, Guid idGmina, Guid idWojewodztwo)
        {
            DataClasses1DataContext db = new DataClasses1DataContext();
            var result = db.Regions.Where(x => x.Id_Kraj == idKraj).Where(x => x.Id_Powiat == idPowiat).Where(x => x.Id_Gmina == idGmina).Where(x => x.Id_Wojewodztwo == idWojewodztwo).SingleOrDefault();
            if (result == null)
                return false;
            return true;
        }

        public static Region CheckRegionExist(Guid idKraj, Guid idPowiat, Guid idGmina, Guid idWojewodztwo)
        {
            DataClasses1DataContext db = new DataClasses1DataContext();
            return db.Regions.Where(x => x.Id_Kraj == idKraj).Where(x => x.Id_Powiat == idPowiat).Where(x => x.Id_Gmina == idGmina).Where(x => x.Id_Wojewodztwo == idWojewodztwo).SingleOrDefault();
        }
    }
}
