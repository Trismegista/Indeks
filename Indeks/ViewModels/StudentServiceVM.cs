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

        public LinqToSql.Login FindUserByLogin(string login)
        {
            DataClasses1DataContext student = new DataClasses1DataContext();
            try
            {
                return student.Logins.SingleOrDefault(x => x.User_Login.Equals(login));
            }
            catch ( Exception e)
            {
                return null;
            }
        }

        public bool CanBeLogged(LinqToSql.Login user, string password, string login)
        {
            if (user == null) return false;

            if (user.User_Login == login && user.Haslo == password) return true;
            else return false;
        }
    }
}
