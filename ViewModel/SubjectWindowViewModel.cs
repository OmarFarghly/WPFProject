using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfProject.Commands;
using WpfProject.DataBaseContext;
using WpfProject.Model;
using WpfProject.View;

namespace WpfProject.ViewModel
{
    public class SubjectWindowViewModel : Utilites.ViewModelBase
    {
        #region  Fields

        #endregion
        #region  Properties
        public static ObservableCollection<Subject> Subjects { get; set; }
        public Subject SelectedSubject { get; set; }
        //Com-6-Define a property of class command for every command used in xaml file 
        public MvCommands AddCommand { get; set; }
        public MvCommands DeleteCommand { get; set; }
        
        #endregion
        #region  Constructor 
        public SubjectWindowViewModel()
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
            AddSubjectWindow subject= new AddSubjectWindow();
            subject.Show(); 
        }
        #endregion
        #region Delete
        public bool CanExecuteDeleteStudent(object paramter)
        {
            return true;
        }
        public void ExcuteDeleteStudent(object parameter)
        {
            NavigationViewModel.myDbContext.Subjects.Remove(SelectedSubject);
            Subjects.Remove(SelectedSubject);
            NavigationViewModel.myDbContext.SaveChanges();
        }
    
        #endregion

        #endregion
    }
}
