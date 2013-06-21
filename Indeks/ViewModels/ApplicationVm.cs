using Indeks.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Indeks.ViewModels
{
    public class ApplicationVM
    {
        public ApplicationVM()
        {
            ExecuteCloseCommand = new Commanding(CloseCurentWindow, CanCloseCurentWindow);
            ExecuteMinimizeCommand = new Commanding(MinimizeCurentWindow, CanMinimizeCurentWindow);
        }

        public ICommand ExecuteMinimizeCommand { get; set; }
        public ICommand ExecuteCloseCommand { get; set; }

        private bool CanCloseCurentWindow(object parameter)
        {
            return true;
        }

        private bool CanMinimizeCurentWindow(object parameter)
        {
            return true;
        }

        private void CloseCurentWindow(object parameter)
        {
            Window window = (Window)parameter;
            if (window.Title == "MainWindow")
            Application.Current.Shutdown();
            else
            window.Close();
        }

        private void MinimizeCurentWindow(object parameter)
        {
            Window window = (Window)parameter;
            window.WindowState = WindowState.Minimized;
        }

        public static bool IsNumeric(string text)
        {
            Regex regex = new Regex("[^0-9.-]+");
            return !regex.IsMatch(text);
        }
    }
}
