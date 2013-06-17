using Indeks.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indeks.LinqToSql
{
    public partial class Student
    {        
        public static List<int> CurentStudentIndexList(Guid login)
        {
            DataClasses1DataContext db = new DataClasses1DataContext();
            var result = db.Students.Where(x => x.Id_Login == login);
            var indexNr = result.Select(x => x.Nr_Indeksu).ToList();
            return indexNr;
        }

        public static IQueryable<Semestr> Semesters(int index)
        {
            DataClasses1DataContext db = new DataClasses1DataContext();
            return db.Students.Where(x => x.Nr_Indeksu == index).SingleOrDefault().StudentSemestrs.Select(x=>x.Semestr).OrderBy(x=>x.Semestr_Nazwa).AsQueryable();
        }

        public static Guid FindStudentIdByIndex(int index)
        {
            DataClasses1DataContext db = new DataClasses1DataContext();
            return db.Students.Where(x => x.Nr_Indeksu == index).Select(x => x.Id_Student).SingleOrDefault();
        }
    }
}
