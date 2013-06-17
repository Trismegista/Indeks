using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indeks.LinqToSql
{
    public partial class TypStudiow
    {

        public static List<string> GetTypStudiows()
        {
            DataClasses1DataContext db = new DataClasses1DataContext();
            return db.TypStudiows.Select(x => x.Typ_Studiow_Nazwa).ToList();
        }

        public static Guid FindTypStudiowIdByName(string name)
        {
            DataClasses1DataContext db = new DataClasses1DataContext();
            return db.TypStudiows.Where(x => x.Typ_Studiow_Nazwa == name).Select(x => x.Id_Typ_Studiow).SingleOrDefault();
        }
    }
}