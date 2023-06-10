using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Xml.Linq;
using WpfProject.Commands;
using WpfProject.DataBaseContext;
using WpfProject.Model;
using WpfProject.View;

namespace WpfProject.ViewModel
{
    public class TeacherWindowViewModel :Utilites.ViewModelBase
    {
        #region  Fields

        #endregion
        #region  Properties
        public static ObservableCollection<Teacher> Teachers { get; set; }
        public Teacher SelectedTeacher { get; set; }
        //Com-6-Define a property of class command for every command used in xaml file 
        public MvCommands AddCommand { get; set; }
        public MvCommands DeleteCommand { get; set; }
       
        #endregion
        #region  Constructor 
        public TeacherWindowViewModel()
        {
            //buttons
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
            AddTeacherWindow addTeacher = new AddTeacherWindow(); 
            addTeacher.Show();  

        }
        #endregion
        #region Delete
        public bool CanExecuteDeleteStudent(object paramter)
        {
            return true;
        }
        public void ExcuteDeleteStudent(object parameter)
        {
            try
            {
                NavigationViewModel.myDbContext.Teachers.Remove(SelectedTeacher);
                Teachers.Remove(SelectedTeacher);
                NavigationViewModel.myDbContext.SaveChanges();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);    
            }
           
        }
        
        #endregion

        #endregion
    }
}
