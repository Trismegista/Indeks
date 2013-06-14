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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Indeks.Views;
using Indeks.LinqToSql;

namespace Indeks
{    
    public partial class Index : Window
    {
        private List<TabItem> _tabItems;
        private TabItem _tabAdd;
        private string _addTabHeader;
        private LoginVM _loginVm;

        public Index(LoginVM loginVm)
        {
            _loginVm = loginVm;
            DataContext = new IndexVM(_loginVm);
            InitializeComponent();
            AddTabItem();
            semesterTab.DataContext = new List<string>();
        }
        //public Index()
        //{
        //    InitializeComponent();
        //    AddTabItem();
        //}
        
        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void AddTabItem()
        {
            StudentServiceVM student = new StudentServiceVM();
            var idStudent = student.FindStudentByLogin(_loginVm.Login).Id_student;
            var listaSemestrow = new SemesterDataService(_loginVm);
            semesterTab.ItemsSource = new SemesterDataService(_loginVm) {   };
            semesterTab.SelectedIndex = 0;
        }
      }
}
