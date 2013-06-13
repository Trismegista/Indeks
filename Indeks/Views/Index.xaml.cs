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

namespace Indeks
{    
    public partial class Index : Window
    {
        private List<TabItem> _tabItems;
        private TabItem _tabAdd;
        private string _addTabHeader;
        private LoginVM _loginVm;

        public Index(LoginVM loginVm) : this()
        {
            _loginVm = loginVm;
            DataContext = new IndexVM(_loginVm);
        }

        public Index()
        {
           try
            {
                InitializeComponent();
                
                _tabItems = new List<TabItem>();
                TabItem tabAdd = new TabItem();
                tabAdd.Header = "+";
                _addTabHeader = "+";
                _tabItems.Add(tabAdd);
                this.AddTabItem();
                semesterTab.DataContext = _tabItems;
                semesterTab.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
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
            TabItem tab = new TabItem();
            tab.Header = string.Format("Tab {0}", count);
            tab.Name = string.Format("tab{0}", count);
            tab.HeaderTemplate = semesterTab.FindResource("TabHeader") as DataTemplate;
            tab.DataContext = new { Header = "adkljasdaskjda", Text = "alskdjaldjad", Students = new string[3] { "asdkljasdkjas", "aaa", "111" } };
            _tabItems.Insert(count - 1, tab);
            return tab;
        }
        private void tabDynamic_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            TabItem tab = semesterTab.SelectedItem as TabItem;

            if (tab != null && tab.Header != null)
            {
                if (tab.Header.Equals(_addTabHeader))
                {

                    semesterTab.DataContext = null;
                    TabItem newTab = this.AddTabItem();
                    semesterTab.DataContext = _tabItems;
                    semesterTab.SelectedItem = newTab;
                }
                else
                {

                }
            }
        }
        //private void btnDelete_Click(object sender, RoutedEventArgs e)
        //{
        //    string tabName = (sender as Button).CommandParameter.ToString();

        //    var item = semesterTab.Items.Cast<tabitem>().Where(i => i.Name.Equals(tabName)).SingleOrDefault();

        //    TabItem tab = item as TabItem;

        //    if (tab != null)
        //    {
        //        if (_tabItems.Count < 3)
        //        {
        //            MessageBox.Show("Cannot remove last tab.");
        //        }
        //        else if (MessageBox.Show(string.Format("Are you sure you want to remove the tab '{0}'?", tab.Header.ToString()),
        //            "Remove Tab", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
        //        {
        //            TabItem selectedTab = semesterTab.SelectedItem as TabItem;

        //            semesterTab.DataContext = null;

        //            _tabItems.Remove(tab);

        //            semesterTab.DataContext = _tabItems;

        //            if (selectedTab == null || selectedTab.Equals(tab))
        //            {
        //                selectedTab = _tabItems[0];
        //            }
        //            semesterTab.SelectedItem = selectedTab;
        //        }
        //    }
        //}
      }
}
