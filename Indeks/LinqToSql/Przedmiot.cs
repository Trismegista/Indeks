using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indeks.LinqToSql
{
    public partial class Przedmiot
    {
        public Wykladowca Wykladowca
        {
            get
            {
                return WykladowcaPrzedmiots.Where(x => x.Przedmiot.Id_Przedmiot == this.Id_Przedmiot).Select(x => x.Wykladowca).SingleOrDefault();
            }
        }

        public Typ_Zajec Typ_Zajec
        {
            get
            {
                return ZajeciaPrzedmiots.Where(x => x.Przedmiot.Id_Przedmiot == this.Id_Przedmiot).Select(x => x.Typ_Zajec).SingleOrDefault();
            }
        }

        public ZajeciaWartosci ZajeciaWartosci
        {
            get
            {
                return ZajeciaPrzedmiots.Where(x => x.Przedmiot.Id_Przedmiot == this.Id_Przedmiot).Select(x => x.ZajeciaWartosci).SingleOrDefault();
            }
        }

        public static List<string> GetPrzedmiots()
        {
                DataClasses1DataContext db = new DataClasses1DataContext();
                return db.Przedmiots.OrderBy(x => x.Przedmiot_Nazwa).Select(x => x.Przedmiot_Nazwa).ToList();
        }

        public static Guid FindPrzedmiotIdByNazwa(string name)
        {
            DataClasses1DataContext db = new DataClasses1DataContext();
            return db.Przedmiots.Where(x => x.Przedmiot_Nazwa == name).Select(x => x.Id_Przedmiot).SingleOrDefault();
        }
    }
}
