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
        private LoginVM _loginVm;
        private List<TabItem> _tabItems;
        private TabItem _tabAdd;   

        public Index(LoginVM loginVm)
        {
            _loginVm = loginVm;
            DataContext = new IndexVM(_loginVm);
            InitializeComponent();

            _tabItems = new List<TabItem>();
            TabItem tabAdd = new TabItem();
            tabAdd.Header = "+";
            _tabItems.Add(tabAdd);
            this.AddTabItem();
            tabDynamic.DataContext = _tabItems;
            tabDynamic.SelectedIndex = 0;
        }
        
        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private TabItem AddTabItem()
        {
            int count = _tabItems.Count;

            StudentServiceVM student = new StudentServiceVM();
            SemesterDataService listaSemesterow = new SemesterDataService();
            var idStudent = student.FindStudentByLogin(_loginVm.Login).Id_Student;

            //List<SemesterDataService> studenci = listaSemesterow.LoadDataGrid(idStudent).ToList();
            var semestry = listaSemesterow.StudentSemestersList(idStudent);

            TabItem tab = new TabItem();
            foreach (LinqToSql.ListaStudent val in semestry)
            {
                SemesterDataService semestr = new SemesterDataService();
                tab.Header = string.Format("Tab {0}", count);
                tab.Name = string.Format("tab{0}", count);
                tab.HeaderTemplate = tabDynamic.FindResource("TabHeader") as DataTemplate;

                //TextBox txt = new TextBox();
                //txt.Name = "txt";
                //txt.Text = " widze cie i nie wiem co jeszcze ";
                //tab.Content = txt;

                DataGrid grid = new DataGrid();
                grid.Name = "name";
                grid.ItemsSource = semestr.SemesterDetails(val.Id_Semestr);
                tab.Content = grid;

                _tabItems.Insert(count - 1, tab);
            }
            return tab;
        }

        private void tabDynamic_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            TabItem tab = tabDynamic.SelectedItem as TabItem;

            if (tab != null && tab.Header != null)
            {
                if (tab.Header.Equals("+"))
                {
                    tabDynamic.DataContext = null;

                    TabItem newTab = this.AddTabItem();

                    tabDynamic.DataContext = _tabItems;

                    tabDynamic.SelectedItem = newTab;
                }
                else
                {
                }
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            string tabName = (sender as Button).CommandParameter.ToString();

            var item = tabDynamic.Items.Cast<TabItem>().Where(i => i.Name.Equals(tabName)).SingleOrDefault();

            TabItem tab = item as TabItem;

            if (tab != null)
            {
                if (_tabItems.Count < 3)
                {
                    MessageBox.Show("Cannot remove last tab.");
                }
                else if (MessageBox.Show(string.Format("Are you sure you want to remove the tab '{0}'?", tab.Header.ToString()),
                    "Remove Tab", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    TabItem selectedTab = tabDynamic.SelectedItem as TabItem;
                    tabDynamic.DataContext = null;
                    _tabItems.Remove(tab);
                    tabDynamic.DataContext = _tabItems;

                    if (selectedTab == null || selectedTab.Equals(tab))
                    {
                        selectedTab = _tabItems[0];
                    }
                    tabDynamic.SelectedItem = selectedTab;
                }
            }
        }
        //private void AddTabItem()
        //{
        //    StudentServiceVM student = new StudentServiceVM();
        //    var idStudent = student.FindStudentByLogin(_loginVm.Login).Id_Student;
        //    SemesterDataService listaSemesterow = new SemesterDataService(_loginVm);
        //    List<SemesterDataService> studenci = listaSemesterow.LoadDataGrid(idStudent).ToList();
        //    TabItem cos = new TabItem();
        //    semesterTab.ItemsSource = studenci;
        //    semesterTab.SelectedIndex = 0;
        //}
      }
}
