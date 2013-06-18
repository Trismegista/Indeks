using Indeks.Interfaces;
using Indeks.LinqToSql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Indeks.ViewModels
{
    public class RegistrationGroupVM : ApplicationVM, INotifyPropertyChanged
    {
        Guid _groupId;

        public RegistrationGroupVM()
        {
            ExecuteRegisterGroupCommand = new Commanding(RegisterGroup,CanRegisterGroup);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(String property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }

        #region Bindings
        private string _kierunek;
        public string Kierunek
        {
            get { return _kierunek; }
            set
            {
                _kierunek = value;
                OnPropertyChanged("Kierunek");
            }
        }

        private string _typStudiow;
        public string TypStudiow
        {
            get { return _typStudiow; }
            set
            {
                _typStudiow = value;
                OnPropertyChanged("TypStudiow");
            }
        }

        private string _rodzajStudiow;
        public string RodzajStudiow
        {
            get { return _rodzajStudiow; }
            set
            {
                _rodzajStudiow = value;
                OnPropertyChanged("RodzajStudiow");
            }
        }

        private string _ciag;
        public string Ciag
        {
            get { return _ciag; }
            set
            {
                _ciag = value;
                OnPropertyChanged("Ciag");
            }
        }

        private string _grupa;
        public string Grupa
        {
            get { return _grupa; }
            set
            {
                _grupa = value;
                OnPropertyChanged("Grupa");
            }
        }
        #endregion

        #region Commands

        public ICommand ExecuteRegisterGroupCommand { get; set; }

        #endregion

        #region Command Questions

        private bool CanRegisterGroup(object parameter)
        {
 	        return true;
        }
        #endregion

        #region Command Executes

        private void RegisterGroup(object parameter)
        {
            //DataClasses1DataContext context = new DataClasses1DataContext();

            //var kierunek = new Kierunek
            //{
            //    Kierunek_Nazwa = _kierunek
            //};
            //context.Kieruneks.InsertOnSubmit(kierunek);
            //context.SubmitChanges();

            //var typStudiow = new TypStudiow
            //{
            //    Typ_Studiow_Nazwa = _typStudiow
            //};
            //context.TypStudiows.InsertOnSubmit(typStudiow);
            //context.SubmitChanges();

            //var stopienStudiow = new StopienStudiow
            //{
            //    Stopien_Studiow_Nazwa = _rodzajStudiow
            //};
            //context.StopienStudiows.InsertOnSubmit(stopienStudiow);
            //context.SubmitChanges();

            //var ciag = new Ciag
            //{
            //    Ciag_Nazwa = _ciag,
            //    Id_Stopien_Studiow = stopienStudiow.Id_Stopien_Studiow,
            //    Id_Typ_Studiow = typStudiow.Id_Typ_Studiow
            //};
            //context.Ciags.InsertOnSubmit(ciag);
            //context.SubmitChanges();

            //var kierunekCiag = new LinqToSql.KierunekCiag
            //{
            //    Id_Kierunek = kierunek.Id_Kierunek,
            //    Id_Ciag = ciag.Id_Ciag
            //};
            //context.KierunekCiags.InsertOnSubmit(kierunekCiag);
            //context.SubmitChanges();

            //var grupa = new Grupa
            //{
            //    Grupa_Nazwa = _grupa
            //};
            //context.Grupas.InsertOnSubmit(grupa);
            //context.SubmitChanges();

            //var kierunekCiagGrupa = new LinqToSql.KierunekCiagGrupa
            //{
            //    Id_Ciag = ciag.Id_Ciag,
            //    Id_Grupa = grupa.Id_Grupa
            //};

            //context.KierunekCiagGrupas.InsertOnSubmit(kierunekCiagGrupa);
            //context.SubmitChanges();

            //_groupId = grupa.Id_Grupa;

            //Window frm = (Window)parameter;
            //frm.Close();
        }
        #endregion

        public Guid CurrentGroupId
        {
            get { return _groupId; }
        }
    }
}
