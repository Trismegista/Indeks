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
    public partial class GroupRegistration : Window
    {
        private Guid _studentId;
        public GroupRegistration(Guid studentId)
        {
            _studentId = studentId;
            DataContext = new RegistrationGroupVM(_studentId);
            InitializeComponent();
        }
    }
}
