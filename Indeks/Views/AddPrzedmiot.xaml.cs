using Indeks.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Indeks.Views
{
    /// <summary>
    /// Interaction logic for AddPrzedmiot.xaml
    /// </summary>
    public partial class AddPrzedmiot : Window
    {
        Guid _idSemester;
        Guid _idGrupa;
        public AddPrzedmiot(Guid idSemester, Guid idGrupa)
        {
            _idSemester = idSemester;
            _idGrupa = idGrupa;
            DataContext = new RegistrationLyricsVM(_idSemester, _idGrupa);
            InitializeComponent();
        }
    }
}
