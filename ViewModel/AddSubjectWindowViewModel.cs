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
    public class AddSubjectWindowViewModel
    {
        #region  Fields

        #endregion
        #region  Properties
        public MvCommands AddCommand { get; set; }
        public MvCommands CloseCommand { get; set; }
        #endregion
        #region  Constructor 
        public AddSubjectWindowViewModel()
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
                int totalhours = int.Parse((window.FindName("TotalHours") as TextBox).Text);
               

                // Create a new instance of subject
                var sub = new Subject
                {
                    Id = id,
                    Char = character.ToCharArray().FirstOrDefault(),
                    Name = name,
                    TotalHours = totalhours,
                    
                };
                //add subject to a static list of subjects 

                SubjectWindowViewModel.Subjects.Add(sub);
                NavigationViewModel.myDbContext.Subjects.Add(sub);
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
