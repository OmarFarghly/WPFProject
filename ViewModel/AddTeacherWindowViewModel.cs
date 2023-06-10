using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using WpfProject.Commands;
using WpfProject.Model;
using WpfProject.View;

namespace WpfProject.ViewModel
{
    public class AddTeacherWindowViewModel :Utilites.ViewModelBase
    {
        #region  Fields

        #endregion
        #region  Properties
        public MvCommands AddCommand { get; set; }
        public MvCommands CloseCommand { get; set; }
        #endregion
        #region  Constructor 
        public AddTeacherWindowViewModel()
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
                double salary = double.Parse((window.FindName("Salary") as TextBox).Text);
                string phone = (window.FindName("Phone") as TextBox).Text;
                Subject subject = (window.FindName("Subject") as ComboBox).SelectedItem as Subject;

                // Create a new instance of Teacher
                var teacher = new Teacher
                {
                    Id = id,
                    Char = character.ToCharArray().FirstOrDefault(),
                    Name = name,
                    Gender = (gender)Enum.Parse(typeof(gender), gender.ToLower()),
                    Salary = salary,
                    Phone = phone,
                    subject = subject,

                };
                TeacherWindowViewModel.Teachers.Add(teacher);
                NavigationViewModel.myDbContext.Teachers.Add(teacher);
                NavigationViewModel.myDbContext.SaveChanges();
                window.Close();
            }
            catch (Exception ex)
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
