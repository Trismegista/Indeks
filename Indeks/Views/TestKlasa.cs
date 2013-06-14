using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Indeks.LinqToSql;



namespace Indeks.Views
{
    public class TestKlasa
    {
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        public string Naglowek { get; set; }
        
        public List<SemesterData> ExecuteGetData{
            get{ return LoadDataGrid(); }
        }

        public List<SemesterData> LoadDataGrid()
        {
            var semestry = new List<SemesterData>();
            semestry.Add(new SemesterData()
            {
                NazwaSemestru = "Semestr1",
                Przedmiot = "Matematyka",
                PunktyETCS = 5,
                LiczbaGodzin = 20,
                Wykładowca = "Wodecki",
                Zajecia = "Wyklad"
            });
            semestry.Add(new SemesterData()
            {
                NazwaSemestru = "Semestr2",
                Przedmiot = "Informatyka",
                PunktyETCS = 52,
                LiczbaGodzin = 202,
                Wykładowca = "Żołnierek",
                Zajecia = "ćwiczenia"
            });
            semestry.Add(new SemesterData()
            {
                NazwaSemestru = "Semestr3",
                Przedmiot = "Grafika",
                PunktyETCS = 7,
                LiczbaGodzin = 2,
                Wykładowca = "Bernaś",
                Zajecia = "Projekt"
            });
            semestry.Add(new SemesterData()
            {
                NazwaSemestru = "Semestr4",
                Przedmiot = "Ciskowski",
                PunktyETCS = 10,
                LiczbaGodzin = 15,
                Wykładowca = "Sulak",
                Zajecia = "Wyklad"
            });
            
            return semestry;
        }
    }
}
