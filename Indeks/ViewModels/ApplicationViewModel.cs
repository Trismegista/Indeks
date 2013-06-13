using Indeks.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

        private void CloseCurentWindow(object parameter)
        {
            Window window = (Window)parameter;
            window.Close();
        }

        private bool CanMinimizeCurentWindow(object parameter)
        {
            return true;
        }

        private void MinimizeCurentWindow(object parameter)
        {
            Window window = (Window)parameter;
            window.WindowState = WindowState.Minimized;
        }
    }
}
