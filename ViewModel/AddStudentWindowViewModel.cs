using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;
using WpfProject.Commands;
using WpfProject.Model;

namespace WpfProject.ViewModel
{
    public class AddStudentWindowViewModel
    {
        #region  Fields

        #endregion
        #region  Properties
        public MvCommands AddCommand { get; set; }
        public MvCommands CloseCommand { get; set; }
        #endregion
        #region  Constructor 
        public AddStudentWindowViewModel()
        {

            AddCommand = new MvCommands(ExcuteAddingTeacher, CanExecuteAddingTeacher);
            CloseCommand = new MvCommands(ExcuteCloseWindow, CanExecuteCloseWindow);
        }
        #endregion
        #region  Methods  

        #region Add
        public bool CanExecuteAddingTeacher(object paramter)
        {
            return true;
        }
        public void ExcuteAddingTeacher(object parameter)
        {
            
            try
            {
                //pass an instance of the window in commandparameter as a parameter
                var window = parameter as Window;

                //search the window instance for items with the following names 
                int id = int.Parse((window.FindName("Id") as TextBox).Text);
                string character = (window.FindName("Char") as TextBox).Text;
                string name = (window.FindName("Name") as TextBox).Text;
                string gender = (window.FindName("Gender") as TextBox).Text;
                double fees = double.Parse((window.FindName("Fees") as TextBox).Text);
                string phone = (window.FindName("Phone") as TextBox).Text;
                var Subjects = (window.FindName("Subject") as ListBox).SelectedItems;

                // Create a new instance of Student
                var student = new Student
                {
                    Id = id,
                    Char = character.ToCharArray().FirstOrDefault(),
                    Name = name,
                    Gender = (gender)Enum.Parse(typeof(gender), gender.ToLower()),
                    Fees = fees,
                    Phone = phone,
                   
                };
                foreach (var item in Subjects)
                {
                    student.subjects.Add(item as Subject); 
                }
            
               
                StudentWindowViewModel.Students.Add(student);
                NavigationViewModel.myDbContext.Students.Add(student);
                NavigationViewModel.myDbContext.SaveChanges();
                window.Close();
            }
            catch (Exception ex )
            {

                MessageBox.Show(ex.Message);    
            }
          
        }
        #endregion
        #region Close
        public bool CanExecuteCloseWindow(object paramter)
        {
            return true;
        }
        public void ExcuteCloseWindow(object parameter)
        {
            (parameter as Window).Close();
        }
        #endregion
        #endregion
    }
}
