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
using System.Windows.Shapes;

namespace Indeks.Views
{
    /// <summary>
    /// Interaction logic for AddNewPrzedmiotVM.xaml
    /// </summary>
    public partial class AddNewPrzedmiot : Window
    {
        public AddNewPrzedmiot()
        {
            DataContext = new AddNewPrzedmiotVM();
            InitializeComponent();
        }
    }
}
