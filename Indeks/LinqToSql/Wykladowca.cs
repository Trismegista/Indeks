using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indeks.LinqToSql
{
    public partial class Wykladowca
    {
        public static List<string> GetWykladowcas()
        {
            DataClasses1DataContext db = new DataClasses1DataContext();
            var idWykladowcasList = db.Wykladowcas.OrderBy(x=>x.Wykladowca_Nazwisko).Select(x => x.Id_Wykladowcy).ToList();
            List<string> nazwiskoImieList = new List<string>();
            foreach (Guid val in idWykladowcasList)
            {
                var imieWykladowcy = db.Wykladowcas.Where(x => x.Id_Wykladowcy == val).Select(x => x.Wykladowca_Nazwisko).SingleOrDefault();
                var nazwiskoWykladowcy = db.Wykladowcas.Where(x => x.Id_Wykladowcy == val).Select(x => x.Wykladowca_Imie).SingleOrDefault();
                string nazwiskoImie = nazwiskoWykladowcy.ToString() + imieWykladowcy.ToString();
                nazwiskoImieList.Add(nazwiskoImie);
            }
            return nazwiskoImieList;
        }

        public static Guid FindWykladowcaIdByNameAndLectureId(Guid idLecture, string name)
        {
            DataClasses1DataContext db = new DataClasses1DataContext();
            string[] nazwiskoImie = name.Split('-');
            string imie = nazwiskoImie[1];
            string nazwisko = nazwiskoImie[0];
            var listaWykladowcow = db.Wykladowcas.Where(x => x._Wykladowca_Nazwisko == nazwisko).Where(x => x._Wykladowca_Imie == imie).Select(x => x._Id_Wykladowcy);
            Guid idWykladowcy = Guid.NewGuid();
            foreach (Guid val in listaWykladowcow)
            {
                Guid tempWykladowca = db.WykladowcaPrzedmiots.Where(x => x.Id_Przedmiotu == idLecture).Where(x => x.Id_Wykladowcy == val).Select(x => x.Id_Wykladowcy).SingleOrDefault();
                if (tempWykladowca != null && tempWykladowca.ToString() != "00000000-0000-0000-0000-000000000000" )
                {
                    idWykladowcy = tempWykladowca;
                    break;
                }
            }
            return idWykladowcy;
        }
    }
}
