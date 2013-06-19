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
                return GrupaSemestrPrzedmiotWykladowcas.Where(x => x.Id_Przedmiot == this.Id_Przedmiot).Select(x => x.Wykladowca).SingleOrDefault();
                //return WykladowcaPrzedmiots.Where(x => x.Przedmiot.Id_Przedmiot == this.Id_Przedmiot).Select(x => x.Wykladowca).SingleOrDefault();
            }
        }

        //public Typ_Zajec Typ_Zajec
        //{
        //    get
        //    {
        //        return ZajeciaPrzedmiots.Where(x => x.Przedmiot.Id_Przedmiot == this.Id_Przedmiot).Select(x => x.Typ_Zajec).SingleOrDefault();
        //    }
        //}

        public static List<string> GetPrzedmiots()
        {
                DataClasses1DataContext db = new DataClasses1DataContext();
                List<Przedmiot> przedmioty = db.Przedmiots.OrderBy(x => x.PrzedmiotNazwa.Przedmiot_Nazwa).ToList();
                List<string> listaPrzedmiotow = new List<string>();
                foreach (Przedmiot val in przedmioty)
                {
                    string nazwaPrzedmiotu = db.PrzedmiotNazwas.Where(x => x.Id_Przedmiot_Nazwa == val.Id_PrzedmiotNazwa).Select(x => x.Przedmiot_Nazwa).SingleOrDefault().ToString();
                    string nazwaTypZajec = db.Typ_Zajecs.Where(x => x.Id_Zajecia == val.Id_Typ_Zajec).Select(x => x.Typ_Zajec_Nazwa).SingleOrDefault().ToString();
                    string punktyETCS = db.Przedmiots.Where(x => x.Id_Przedmiot == val.Id_Przedmiot).Select(x => x.PunktyETCS).SingleOrDefault().ToString();
                    string liczbaGodzin = db.Przedmiots.Where(x => x.Id_Przedmiot == val.Id_Przedmiot).Select(x => x.Godziny).SingleOrDefault().ToString();

                    string nazwyPrzedmiotow = nazwaPrzedmiotu + '-' + nazwaTypZajec + '-' + punktyETCS + '-' + liczbaGodzin;
                    listaPrzedmiotow.Add(nazwyPrzedmiotow);
                }

                return listaPrzedmiotow;
        }

        public static List<string> GetPrzedmiotsNames()
        {
            DataClasses1DataContext db = new DataClasses1DataContext();
            return db.PrzedmiotNazwas.OrderBy(x => x.Przedmiot_Nazwa).Select(x => x.Przedmiot_Nazwa).ToList();
        }

        public static Guid FindPrzedmiotNazwaIdByNazwa(string name)
        {
            DataClasses1DataContext db = new DataClasses1DataContext();
            return db.PrzedmiotNazwas.Where(x => x.Przedmiot_Nazwa == name).Select(x => x.Id_Przedmiot_Nazwa).SingleOrDefault();
        }
    }
}
