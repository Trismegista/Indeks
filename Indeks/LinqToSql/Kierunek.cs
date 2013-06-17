using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indeks.LinqToSql
{
    public partial class Kierunek
    {
        public static List<string> GetKieruneks()
        {
            DataClasses1DataContext db = new DataClasses1DataContext();
            return db.Kieruneks.Select(x => x.Kierunek_Nazwa).ToList();
        }

        public static Guid FindKierunekIdByName(string name)
        {
            DataClasses1DataContext db = new DataClasses1DataContext();
            return db.Kieruneks.Where(x => x.Kierunek_Nazwa == name).Select(x => x.Id_Kierunek).SingleOrDefault();
        }
    }
}
