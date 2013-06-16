using Indeks.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indeks.LinqToSql
{
    public class SemesterDataService
    {
        //LoginVM _loginVm;
        //public SemesterDataService()
        //{
        //    //_loginVm = loginVm;
        //}
        //public string Nazwa { get; set; }
        //public string Przedmiot { get; set; }
        //public string Wykladowca { get; set; }
        //public int PunktyETCS { get; set; }
        //public int LiczbaGodzin { get; set; }
        //public string Zajecia { get; set; }

        //public IEnumerable<LinqToSql.Lista> StudentSemestersNames(Guid idStudent)
        //{
        //    DataClasses1DataContext ls = new DataClasses1DataContext();
        //    var listaSemestrow = ls.ListaStudents.Where(x => x.Id_Student == idStudent).Select(x => x.Id_Semestr).ToList();
        //    List<LinqToSql.Lista> semestry = new List<LinqToSql.Lista>();
        //    foreach (Guid value in listaSemestrow)
        //        {
        //            semestry.Add(ls.Listas.SingleOrDefault(x => x.Id_Semestr == value));
        //        }
        //    return semestry;
        //}

        //public IEnumerable<SemesterDataService> ExecuteGetData
        //{
        //    get { return LoadDataGrid(CurrentUser()); }
        //}

        //public IEnumerable<LinqToSql.ListaStudent> StudentSemestersList(Guid idStudent)
        //{
        //    DataClasses1DataContext ls = new DataClasses1DataContext();
        //    return ls.ListaStudents.Where(x => x.Id_Student.Equals(idStudent));
        //}

        //public SemesterDataService SemesterDetails(Guid idSemester)
        //{
        //    DataClasses1DataContext ls = new DataClasses1DataContext();
        //    var dataSemestr = ls.Listas.Where(x => x.Id_Semestr == idSemester).SingleOrDefault();
        //    return new SemesterDataService
        //    {
        //        Nazwa = dataSemestr.Nazwa,
        //        Przedmiot = dataSemestr.Przedmiot,
        //        Wykladowca = dataSemestr.Wykladowca,
        //        PunktyETCS = dataSemestr.PunktyETCS,
        //        LiczbaGodzin = dataSemestr.LGodzin,
        //        Zajecia = dataSemestr.Zajecia
        //    };
        //}

        //public IEnumerable<SemesterDataService> LoadDataGrid(Guid idStudent)
        //{
        //    var semestry = new List<SemesterDataService>();
        //    var sem = new SemesterDataService();
        //    var listaSemestrow = sem.StudentSemestersNames(idStudent);
        //    foreach ( LinqToSql.Lista value in listaSemestrow )
        //    semestry.Add(new SemesterDataService()
        //    {
        //        Nazwa = value.Nazwa,
        //        Przedmiot = value.Przedmiot,
        //        Wykladowca = value.Wykladowca,
        //        PunktyETCS = value.PunktyETCS,
        //        LiczbaGodzin = value.LGodzin,
        //        Zajecia = value.Zajecia
        //    });
        //    return semestry;
        //}
        //public Guid CurrentUser()
        //{
        //    StudentServiceVM student = new StudentServiceVM();
        //    return student.FindStudentByLogin(_loginVm.Login).Id_Student;
        //}
    }
}
