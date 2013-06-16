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
    }
}
