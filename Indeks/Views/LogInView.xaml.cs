﻿using System;
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
    /// Interaction logic for LogInView.xaml
    /// </summary>
    public partial class LogInView : Window
    {
        
        public LogInView()
        {
            InitializeComponent();
        }
        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            this.Close();
        }
        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            if ( txtUserName.Text == user.imie && txtPassword.Password == user.haslo )
                DialogResult = true;
        }
        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            var frm = new RegisterWindow();
            frm.Show();
        }
    }
}