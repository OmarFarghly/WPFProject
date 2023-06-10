using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using WpfProject.Commands;
using WpfProject.DataBaseContext;
using WpfProject.Model;
using WpfProject.View;

namespace WpfProject.ViewModel
{
    public class StudentWindowViewModel :Utilites.ViewModelBase
    {
        #region  Fields
       
        #endregion
        #region  Properties
        public static ObservableCollection<Student> Students { get; set; }
        public Student SelectedStudent { get; set; } 
        //Com-6-Define a property of class command for every command used in xaml file 
        public MvCommands AddCommand { get; set; }
        public MvCommands DeleteCommand { get; set; }
        
        #endregion
        #region  Constructor 
        public StudentWindowViewModel()
        {
            AddCommand = new MvCommands(ExcuteAddingStudent, CanExecuteAddingStudent);
            DeleteCommand = new MvCommands(ExcuteDeleteStudent, CanExecuteDeleteStudent);
        }
        #endregion
        #region  Methods  

        #region Add
        public bool CanExecuteAddingStudent(object paramter)
        {
            return true;
        }
        public void ExcuteAddingStudent(object parameter)
        {
            AddStudentWindow addStudent = new AddStudentWindow();
            addStudent.Show();
        }
        #endregion
        #region Delete
        public bool CanExecuteDeleteStudent(object paramter)
        {
            return true;
        }
        public void ExcuteDeleteStudent(object parameter)
        {
            Students.Remove(SelectedStudent);
            NavigationViewModel.myDbContext.SaveChanges();
            //order is critical here the object needs to be removed first from database then removed from ObservableCollection
        }
       
        #endregion

        #endregion
    }

}
