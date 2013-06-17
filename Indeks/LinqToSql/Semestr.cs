using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indeks.LinqToSql
{
    public partial class Semestr
    {
        public List<Przedmiot> Przedmioty
        {
            get
            {
                return SemestrPrzedmiots.Select(x => x.Przedmiot).ToList();
            }
        }
        public string NaglowekPrzedmiot { get { return "Przedmiot"; } }
        public string NaglowekWykladowca { get { return "Wykładowca"; } }
        public string NaglowekZajecia { get { return "Zajęcia"; } }
        public string NaglowekETCS { get { return "ETCS"; } }
        public string NaglowekGodzina { get { return "Godziny"; } }
    }
}
