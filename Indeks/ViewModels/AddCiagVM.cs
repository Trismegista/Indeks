using Indeks.Interfaces;
using Indeks.LinqToSql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Indeks.ViewModels
{
    public class AddCiagVM : ApplicationVM
    {
        public AddCiagVM()
        {
            ExecuteAddCiagCommand = new Commanding(AddCiagCommand, CanAddCiagCommand);
            StopienStudiowNazwa = StopienStudiow.GetStopienStudiows();
            TypStudiowNazwa = TypStudiow.GetTypStudiows();
        }

        public ICommand ExecuteAddCiagCommand { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string property = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }

        private bool CanAddCiagCommand(object parameter)
        {
            if (String.IsNullOrEmpty(_selectedStopien) || String.IsNullOrEmpty(_selectedTyp)) return false;
            return true;
        }

        private void AddCiagCommand(object parameter)
        {
            DataClasses1DataContext context = new DataClasses1DataContext();

            Guid idStopien = StopienStudiow.FindStupienStudiowIdByName(_selectedStopien);
            Guid idTyp = TypStudiow.FindTypStudiowIdByName(_selectedTyp);
            
            string firstLetterOfStopien = _selectedStopien[0].ToString();
            string firstLetterOfTyp = _selectedTyp[0].ToString();
            string ciagName = firstLetterOfStopien.ToUpper() + firstLetterOfTyp.ToUpper();

            var ciag = new Ciag
            {
                Id_Stopien_Studiow = idStopien,
                Id_Typ_Studiow = idTyp,
                Ciag_Nazwa = ciagName,
            };
            context.Ciags.InsertOnSubmit(ciag);
            context.SubmitChanges();

            Window frm = (Window)parameter;
            frm.Close();
        }

        private List<string> _stopienStudiowNazwa;
        public List<string> StopienStudiowNazwa
        {
            get
            {
                return _stopienStudiowNazwa;
            }
            set
            {
                _stopienStudiowNazwa = value;
                OnPropertyChanged();
            }
        }

        private List<string> _typStudiowNazwa;
        public List<string> TypStudiowNazwa
        {
            get
            {
                return _typStudiowNazwa;
            }
            set
            {
                _typStudiowNazwa = value;
                OnPropertyChanged();
            }
        }

        private string _selectedStopien;
        public string SelectedStopien
        {
            get
            {
                return _selectedStopien;
            }
            set
            {
                if (value != _selectedStopien)
                {
                    _selectedStopien = value;
                    OnPropertyChanged();
                }
            }
        }

        private string _selectedTyp;
        public string SelectedTyp
        {
            get
            {
                return _selectedTyp;
            }
            set
            {
                if (value != _selectedTyp)
                {
                    _selectedTyp = value;
                    OnPropertyChanged();
                }
            }
        }

        DataClasses1DataContext context = new DataClasses1DataContext();
    }
}
