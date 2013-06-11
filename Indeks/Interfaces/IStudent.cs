using System.Linq;

namespace Indeks.Interfaces
{
    public interface IStudent : IEntity
    {
        string Imie { get; set; }
        string Nazwisko { get; set; }
        string Telefon { get; set; }
        string Password { get; set; }

        void ChangePassword(string oldPassword, string newPassword);
    }
}
