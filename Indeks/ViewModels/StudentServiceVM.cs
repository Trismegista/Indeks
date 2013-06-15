using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Indeks.LinqToSql;
using System.Windows;

namespace Indeks.ViewModels
{
    public class StudentServiceVM
    {
        public LinqToSql.Student FindStudentById(Guid id)
        {
            DataClasses1DataContext student = new DataClasses1DataContext();
            return student.Students.SingleOrDefault(x => x.Id_Student == id);
        }

        public LinqToSql.Student FindStudentByLogin(string login)
        {
            DataClasses1DataContext student = new DataClasses1DataContext();
            try
            {
                return student.Students.Single(x => x.login == login);
            }
            catch ( Exception e)
            {
                return null;
            }
        }

        public bool CanBeLogged(LinqToSql.Student student, string password, string login)
        {
            if (student == null) return false;

            if (student.login == login && student.haslo == password) return true;
            else return false;
        }
    }
}
