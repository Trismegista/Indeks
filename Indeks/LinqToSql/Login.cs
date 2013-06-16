using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indeks.LinqToSql
{
    public partial class Login
    {
        DataClasses1DataContext db = new DataClasses1DataContext();

        public Login FindUserByLogin(string login)
        {
            var tempData = db.Logins.SingleOrDefault(x => x.User_Login.Equals(login));
            if (tempData == null) return null;
            else
            {
                return new Login
                {
                    Id_Login = tempData.Id_Login,
                    Id_Adres = tempData.Id_Adres,
                    User_Login = tempData.User_Login,
                    Haslo = tempData.Haslo,
                    Student_Imie = tempData.Student_Imie,
                    Student_Nazwisko = tempData.Student_Nazwisko,
                    Student_E_Mail = tempData.Student_E_Mail,
                    Student_Telefon = tempData.Student_Telefon
                };
            }
        }

        public bool IsAuthenticated(Login user, string haslo, string login)
        {
            if (user == null) return false;
            if (user.Haslo == haslo && user.User_Login == login)
            {
                return true;
            }
            else return false;
        }

        public Guid GetUserId(string login)
        {
            return db.Logins.Where(x => x.User_Login == login).Select(x => x.Id_Login).SingleOrDefault();
        }
    }
}
