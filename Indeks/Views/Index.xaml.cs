﻿using Indeks.ViewModels;
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

        public Index(LoginVM loginVm)
        {
            _loginVm = loginVm;
            DataContext = new IndexVM(_loginVm);
            InitializeComponent();
        }
      }
}
