using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indeks.LinqToSql
{
    public partial class StopienStudiow
    {
        public static List<string> GetStopienStudiows()
        {
            DataClasses1DataContext db = new DataClasses1DataContext();
            return db.StopienStudiows.Select(x => x.Stopien_Studiow_Nazwa).ToList();
        }

        public static Guid FindStupienStudiowIdByName(string name)
        {
            DataClasses1DataContext db = new DataClasses1DataContext();
            return db.StopienStudiows.Where(x => x.Stopien_Studiow_Nazwa == name).Select(x => x.Id_Stopien_Studiow).SingleOrDefault();
        }
    }
}
