using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indeks.LinqToSql
{
    public partial class Zdjecie
    {
        public static string GetZdjecieSource(Guid idLogin)
        {
            DataClasses1DataContext db = new DataClasses1DataContext();
            var idZdjecie = db.Logins.Where(x => x.Id_Login == idLogin).Select(x => x.Id_Zdjecie).SingleOrDefault();
            return db.Zdjecies.Where(x => x.Id_Zdjecia == idZdjecie).Select(x => x.Sciezka).SingleOrDefault().ToString();
        }

        public static int GetLastPhoto()
        {
            DataClasses1DataContext db = new DataClasses1DataContext();
            var photoList = db.Zdjecies.Select(x => x.Nazwa).ToList();
            int lastPhotoName = photoList.Count();
            return lastPhotoName;
        }
        public static Zdjecie CopyPhotoToImages(string source)
        {
            DataClasses1DataContext context = new DataClasses1DataContext();
            string oldExtension = Path.GetExtension(source);
            string sciezkaProgramu = Directory.GetCurrentDirectory();
            string[] sciezkaArray = sciezkaProgramu.Split('\\');
            string sciezkaProgramuDocelowa = "";
            for (int i = 0; i < sciezkaArray.Length - 2; i++)
            {
                sciezkaProgramuDocelowa = sciezkaProgramuDocelowa + sciezkaArray[i] + "\\";
            }
            string nowaSciezka = sciezkaProgramuDocelowa + "Images\\"+GetLastPhoto()+oldExtension;
            File.Delete(nowaSciezka);
            File.Copy(source, nowaSciezka);

            var photo = new Zdjecie
            {
                Sciezka = nowaSciezka,
                Nazwa = GetLastPhoto().ToString()
            };
            context.Zdjecies.InsertOnSubmit(photo);
            context.SubmitChanges();
            return photo;
        }
    }
}
