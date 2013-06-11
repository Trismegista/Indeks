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

namespace Indeks
{
    /// <summary>
    /// Interaction logic for RegisterWindow.xaml
    /// </summary>
    public partial class RegisterWindow : Window
    {
        public RegisterWindow()
        {
            InitializeComponent();
        }
        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }
        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            if (txtRegisterPassword.Password != txtRegisterPasswordRepeat.Password) return;
            DataClasses1DataContext context = new DataClasses1DataContext();
            Studnet student = new Studnet();
            Student stud = new Student();
            student.imie = txtFirstName.Text;
            student.nazwisko = txtLastName.Text;
            student.telefon = txtPhone.Text;
            student.Id_stunet = Guid.NewGuid();
            student.haslo = txtRegisterPassword.Password;
            context.Studnets.InsertOnSubmit(student);
            context.SubmitChanges();
        }
    }
}
