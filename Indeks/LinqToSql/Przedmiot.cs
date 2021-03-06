﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indeks.LinqToSql
{
    public partial class Przedmiot
    {        
        public PrzedmiotNazwa Przedmiot_Nazwa
        {
            get
            {
                return PrzedmiotNazwa;
            }
        }
        public Typ_Zajec TypZajec
        {
            get
            {
                return GrupaSemestrPrzedmiots.Where(x => x.Przedmiot.Id_Przedmiot == this.Id_Przedmiot).SingleOrDefault().Przedmiot.Typ_Zajec;
            }
        }


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
                    string nrWykladowcy = db.Wykladowcas.Where(x => x.Id_Wykladowcy == val.Id_Wykladowcy).Select(x => x.Nr_Wykladowcy).SingleOrDefault().ToString();
                    string nazwyPrzedmiotow = nazwaPrzedmiotu + "-" + nazwaTypZajec + "-Punkty:" + punktyETCS + "-Godz.:" + liczbaGodzin+"-Wykl.:" + nrWykladowcy;
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

        public static Guid FindPrzedmiotIdByFullName(string name)
        {
            DataClasses1DataContext db = new DataClasses1DataContext();
            string[] grupyTematycznePrzedmiotu = name.Split('-');
            string wykladowcaFull = grupyTematycznePrzedmiotu[grupyTematycznePrzedmiotu.Length-1];
            string wykladowca = wykladowcaFull.Substring(wykladowcaFull.LastIndexOf(':')+1);
            Guid idPrzedmiotNazwa = db.PrzedmiotNazwas.Where(x => x.Przedmiot_Nazwa == grupyTematycznePrzedmiotu[0]).Select(x => x.Id_Przedmiot_Nazwa).SingleOrDefault();
            Guid idTyp = db.Typ_Zajecs.Where(x => x.Typ_Zajec_Nazwa == grupyTematycznePrzedmiotu[1]).Select(x => x.Id_Zajecia).SingleOrDefault();
            Guid idWyk = db.Wykladowcas.Where(x => x.Nr_Wykladowcy == Convert.ToInt32(wykladowca)).Select(x => x.Id_Wykladowcy).SingleOrDefault();
            return db.Przedmiots.Where(x => x.Id_PrzedmiotNazwa == idPrzedmiotNazwa).Where(x => x.Id_Typ_Zajec == idTyp).Where(x=>x.Id_Wykladowcy==idWyk).Select(x=>x.Id_Przedmiot).SingleOrDefault();
        }

        public static Przedmiot CheckPrzedmiotExist(Guid idTyp, Guid idWykladowca, Guid idPrzedmiotNazwa)
        {
            DataClasses1DataContext db = new DataClasses1DataContext();
            return db.Przedmiots.Where(x => x.Id_Typ_Zajec == idTyp).Where(x => x.Id_Wykladowcy == idWykladowca).Where(x => x.Id_PrzedmiotNazwa == idPrzedmiotNazwa).SingleOrDefault();
        }
    }
}
