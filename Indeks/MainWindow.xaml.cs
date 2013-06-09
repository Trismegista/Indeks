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
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<TabItem> _tabItems;
        private TabItem _tabAdd;
        private string _addTabHeader;
        public MainWindow()
        {
           try
            {
                InitializeComponent();
                DisplayLoginScreen();
                // initialize tabItem array
                _tabItems = new List<TabItem>();

                // add a tabItem with + in header 
                TabItem tabAdd = new TabItem();
                tabAdd.Header = "+";
                _addTabHeader = "+";
                _tabItems.Add(tabAdd);

                // add first tab
                this.AddTabItem();

                // bind tab control
                semesterTab.DataContext = _tabItems;

                semesterTab.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void DisplayLoginScreen()
        {
            LogInView frm = new LogInView();

            frm.ShowDialog();
            if (frm.DialogResult.HasValue && frm.DialogResult.Value)
                MessageBox.Show("User Logged In");
            else
                this.Close();
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

            // create new tab item
            TabItem tab = new TabItem();
            tab.Header = string.Format("Tab {0}", count);
            tab.Name = string.Format("tab{0}", count);
            tab.HeaderTemplate = semesterTab.FindResource("TabHeader") as DataTemplate;

            // add controls to tab item, this case I added just a textbox
            TextBox txt = new TextBox();
            txt.Name = "txt";
            tab.Content = txt;

            // insert tab item right before the last (+) tab item
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
                    // clear tab control binding
                    semesterTab.DataContext = null;

                    // add new tab
                    TabItem newTab = this.AddTabItem();

                    // bind tab control
                    semesterTab.DataContext = _tabItems;

                    // select newly added tab item
                    semesterTab.SelectedItem = newTab;
                }
                else
                {
                    // your code here...
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
        //            // get selected tab
        //            TabItem selectedTab = semesterTab.SelectedItem as TabItem;

        //            // clear tab control binding
        //            semesterTab.DataContext = null;

        //            _tabItems.Remove(tab);

        //            // bind tab control
        //            semesterTab.DataContext = _tabItems;

        //            // select previously selected tab. if that is removed then select first tab
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
