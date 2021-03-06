﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indeks.LinqToSql
{
    public partial class Miejscowosc
    {
        public static Miejscowosc CheckMiejscowoscExist(Guid idNazwaMiasto, Guid idUlica)
        {
            DataClasses1DataContext db = new DataClasses1DataContext();
            return db.Miejscowoscs.Where(x => x.Id_Nazwa_Miasto == idNazwaMiasto).Where(x => x.Id_Ulica == idUlica).SingleOrDefault();
        }

        public static bool CheckIfMiejscowoscExist(Guid idUlica, Guid idNazwaMiasto)
        {
            DataClasses1DataContext db = new DataClasses1DataContext();
            var result = db.Miejscowoscs.Where(x => x.Id_Ulica == idUlica).Where(x => x.Id_Nazwa_Miasto == idNazwaMiasto).SingleOrDefault();
            if (result == null)
                return false;
            return true;
        }
    }
}
