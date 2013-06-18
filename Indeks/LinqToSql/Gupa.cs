using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indeks.LinqToSql
{
    public partial class Grupa
    {

        public static List<string> GetGrupas()
        {
            DataClasses1DataContext db = new DataClasses1DataContext();
            return db.GrupaNazwas.Select(x => x.Grupa_Nazwa).ToList();
        }

        public static Guid FindGrupaIdByName(string name)
        {
            DataClasses1DataContext db = new DataClasses1DataContext();
            return db.GrupaNazwas.Where(x => x.Grupa_Nazwa == name).Select(x => x.Id_Grupa_Nazwa).SingleOrDefault();
        }
    }
}
