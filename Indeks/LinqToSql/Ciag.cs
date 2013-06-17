using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indeks.LinqToSql
{
    public partial class Ciag
    {
        public static List<string> GetCiags()
        {
            DataClasses1DataContext db = new DataClasses1DataContext();
            var ciag = db.Ciags.Select(x => x.Ciag_Nazwa).ToList();
            List<string> ListaCiag = new List<string>();
            foreach (string val in ciag)
            {
                string stringBuilder = "";

                Guid stopienId = db.Ciags.Where(x => x.Ciag_Nazwa == val).Select(x => x.Id_Stopien_Studiow).SingleOrDefault();
                string stopien = db.StopienStudiows.Where(x => x.Id_Stopien_Studiow == stopienId).Select(x => x.Stopien_Studiow_Nazwa).SingleOrDefault();

                Guid typId = db.Ciags.Where(x => x.Ciag_Nazwa == val).Select(x => x.Id_Typ_Studiow).SingleOrDefault();
                string typ = db.TypStudiows.Where(x => x.Id_Typ_Studiow == typId).Select(x => x.Typ_Studiow_Nazwa).SingleOrDefault();

                stringBuilder = val+"-"+stopien+"-"+typ;
                ListaCiag.Add(stringBuilder);
            }
            return ListaCiag;
        }
    }
}
