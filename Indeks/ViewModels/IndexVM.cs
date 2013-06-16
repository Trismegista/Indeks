﻿using Indeks.Interfaces;
using Indeks.LinqToSql;
using Indeks.Views;
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
    public class IndexVM : ApplicationVM, INotifyPropertyChanged
    {
        LoginVM _loginVm;

        public IndexVM(LoginVM loginVm)
        {
            _loginVm = loginVm;
            ExecuteOpenSemesterCommand = new Commanding(AddSemesterCommand, CanAddSemesterCommand);
            ExecuteOpenGroupCommand = new Commanding(AddGroupCommand, CanAddGroupCommand);
            //ExecuteTestButtonCommand = new Commanding(TestInformation, CanTestInformation);
            NumeryIndeksow = Student.CurentStudentIndexList(_loginVm.CurrentStudentId);            
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string property = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }
        #region Bindings   
     
        private IQueryable<Semestr> _semesters;
        public IQueryable<Semestr> Semesters
        {
            get
            {
                return _semesters;
            }
            set
            {
                //if (value != _semesters)
                {
                    _semesters = value;
                    OnPropertyChanged();
                }
            }
        }

        private List<int> _numeryIndeksow;
        public List<int> NumeryIndeksow
        {
            get
            {
                return _numeryIndeksow;
            }
            set
            {
                _numeryIndeksow = value;
                OnPropertyChanged();
            }
        }
        #endregion
        #region commands

        public ICommand ExecuteTestButtonCommand { get; set; }
        public ICommand ExecuteOpenGroupCommand { get; set; }
        public ICommand ExecuteOpenSemesterCommand { get; set; }

        #endregion

        #region Command Questions
        private bool CanAddGroupCommand(object parameter)
        {
            return true;
        }

        private bool CanAddSemesterCommand(object parameter)
        {
            return true;
        }

        private bool CanTestInformation(object parameter)
        {
            return true;
        }

        #endregion

        #region Execute Commands
        private void AddSemesterCommand(object parameter)
        {
            Semester frm = new Semester(_loginVm);
            Nullable<bool> dialogResult = frm.ShowDialog();
        }

        private void AddGroupCommand(object parameter)
        {
            Window frm = new GroupRegistration();
            Nullable<bool> dialogResult = frm.ShowDialog();
        }

        private int _wybranySemestr;
        public int WybranySemestr
        {
            get { return _wybranySemestr; }
            set
            {
                if (value != _wybranySemestr)
                {
                    _wybranySemestr = value;
                    OnPropertyChanged();
                }
            }
        }


        private int _wybranyIndex;
        public int WybranyIndeks
        {
            get
            {
                return _wybranyIndex;
            }
            set
            {
                if (_wybranyIndex != value)
                {
                    _wybranyIndex = value;
                    OnPropertyChanged();
                    Semesters = Student.Semesters(_wybranyIndex);
                    WybranySemestr = 0;
                }
            }
        }


        //private void TestInformation(object parameter)
        //{
        //    Student st = new Student();
        //    var test = st.CurentStudentIndexList(_loginVm.CurrentStudentId);
        //    MessageBox.Show(test[0].ToString());
        //}

        #endregion

      }
    }
