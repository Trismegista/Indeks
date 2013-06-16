using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indeks.LinqToSql
{
    public partial class Grupa
    {
        DataClasses1DataContext db = new DataClasses1DataContext();
        public List<string> GetStudentGroupsInfo(Guid idStudent)
        {
            return null;
        }

        public List<Guid> GetStudentGroupsId(Guid idStudent)
        {
            return null;
            //return db.KierunekCiagGrupas.Where
        }

    }
}
