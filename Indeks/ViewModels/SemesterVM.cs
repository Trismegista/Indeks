using Indeks.Interfaces;
using Indeks.LinqToSql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Input;

namespace Indeks.ViewModels
{
    public class SemesterVM : ApplicationVM, INotifyPropertyChanged
    {
        public SemesterVM(LoginVM loginVM)
        {
            _loginVM = loginVM;
            //ExecuteAddSemesterCommand = new Commanding(CreateSemester, CanCreateSemester);
        }
        private LoginVM _loginVM;
        public ICommand ExecuteAddSemesterCommand { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(String property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }

        //private string _semesterName;
        //public string SemesterName
        //{
        //    get { return _semesterName; }
        //    set
        //    {
        //        _semesterName = value;
        //        OnPropertyChanged("SemesterName");
        //    }
        //}

        //private string _lecture;
        //public string Lecture
        //{
        //    get { return _lecture; }
        //    set
        //    {
        //        _lecture = value;
        //        OnPropertyChanged("Lecture");
        //    }
        //}

        //private string _teacher;
        //public string Teacher
        //{
        //    get { return _teacher; }
        //    set
        //    {
        //        _teacher = value;
        //        OnPropertyChanged("Teacher");
        //    }
        //}

        //private string _eTCSPoints;
        //public string ETCSPoints
        //{
        //    get { return _eTCSPoints; }
        //    set
        //    {
        //        _eTCSPoints = value;
        //        OnPropertyChanged("ETCSPoints");
        //    }
        //}

        //private string _hours;
        //public string Hours
        //{
        //    get { return _hours; }
        //    set
        //    {
        //        _hours = value;
        //        OnPropertyChanged("Hours");
        //    }
        //}

        //private string _lectureType;
        //public string LectureType
        //{
        //    get { return _lectureType; }
        //    set
        //    {
        //        _lectureType = value;
        //        OnPropertyChanged("LectureType");
        //    }
        //}

        //private void ClearParameters()
        //{
        //    _semesterName = "";
        //    _teacher = "";
        //    _hours = "";
        //    _lecture = "";
        //    _lectureType = "";
        //    _eTCSPoints = "";
        //}

        //private bool CanCreateSemester(object parameter)
        //{
        //    return true;
        //}

        //private void CreateSemester(object parameter)
        //{
        //    int points = Convert.ToInt32(_eTCSPoints);
        //    int hours = Convert.ToInt32(_hours);
        //    DataClasses1DataContext context = new DataClasses1DataContext();
        //    var semester = new LinqToSql.Lista()
        //    {
        //        Nazwa = _semesterName,
        //        Przedmiot = _lecture,
        //        Wykladowca = _teacher,
        //        PunktyETCS = points,
        //        LGodzin = hours,
        //        Zajecia= _lectureType
        //    };
        //    context.Listas.InsertOnSubmit(semester);
        //    context.SubmitChanges();
        //    var listaStudents = new ListaStudent() 
            
        //    { 
        //         Id_Semestr = context.Listas.SingleOrDefault(x => x.Id_Semestr == semester.Id_Semestr).Id_Semestr, 
        //         Id_Student = context.Students.SingleOrDefault(x => x.login == _loginVM.Login).Id_Student 
        //    };

        //    context.ListaStudents.InsertOnSubmit(listaStudents);
        //    context.SubmitChanges();
        //    //MessageBox.Show(_loginVM.GetLogin());
        //    Window frm = (Window)parameter;
        //    ClearParameters();
        //    frm.Close();
        //}
    }
}
