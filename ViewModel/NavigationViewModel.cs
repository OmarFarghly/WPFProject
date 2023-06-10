using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using WpfProject.Commands;
using WpfProject.DataBaseContext;
using WpfProject.Model;
using WpfProject.Utilites;
using WpfProject.View;
using System.Collections.ObjectModel;

namespace WpfProject.ViewModel
{
    public class NavigationViewModel :ViewModelBase
    {
        #region Fields
        private object _currentView;
        #endregion
        #region Properties 
        public object CurrentView
        {
            get { return _currentView; }
            set { _currentView = value;OnPropertyChanged(); } 
        }
        //create a command property for every Window
        public MvCommands DashBoardCommand { get; set; }
        public MvCommands TeachersCommand { get; set; }
        public MvCommands StudentsCommand { get; set; }
        public MvCommands SubjectsCommand { get; set; }
        public MvCommands CloseWindowCommand { get; }
        public static MyDbContext myDbContext { get; set; }

        #endregion
        #region Constructor
        public NavigationViewModel()
        {
            //database instance
            myDbContext = new MyDbContext();
            TeacherWindowViewModel.Teachers = new ObservableCollection<Teacher>();
            RetrieveTeachers();
            SubjectWindowViewModel.Subjects = new ObservableCollection<Subject>();
            RetrieveSubjects();
            StudentWindowViewModel.Students = new ObservableCollection<Student>();
            RetrieveStudents();
            //previous collection and database methods are written here so they get executed when the programm starts running
            //pass methods to the mvcommands instance 
            DashBoardCommand = new MvCommands(DashBoard);
            TeachersCommand = new MvCommands(TeachersWindow);
            StudentsCommand = new MvCommands(StudentsWindow);
            SubjectsCommand = new MvCommands(SubjectsWindow);
   
            //startup page 
            CurrentView = new DashBoardWindowViewModel();

            CloseWindowCommand = new MvCommands(CloseWindow);


        }
        #endregion
        #region Methods
        private void DashBoard(object obj) => CurrentView = new DashBoardWindowViewModel();
        private void TeachersWindow(object obj) => CurrentView = new TeacherWindowViewModel();
        private void StudentsWindow(object obj) =>CurrentView =new StudentWindowViewModel(); 
        private void SubjectsWindow(object obj)=> CurrentView= new SubjectWindowViewModel();
        private void CloseWindow(object parameter)
        {
            
            if (parameter is System.Windows.Window window)
            {
                window.Close();
            }
        }
        #region Database methods 
        public void RetrieveTeachers()
        {
            foreach (var teacher in NavigationViewModel.myDbContext.Teachers.ToList())
            {
                TeacherWindowViewModel.Teachers.Add(teacher);
                teacher.Char = teacher.Name.ToCharArray().FirstOrDefault();
                teacher.subject = NavigationViewModel.myDbContext.Teachers.Where(x => x.Id == teacher.Id).Select(x => x.subject).FirstOrDefault();
            }
        }
        public void RetrieveSubjects()
        {
            foreach (var subject in NavigationViewModel.myDbContext.Subjects.ToList())
            {
                SubjectWindowViewModel.Subjects.Add(subject);
                subject.Students = NavigationViewModel.myDbContext.Subjects.Where(x => x.Id == subject.Id).SelectMany(x => x.Students).ToList();
                subject.Teachers = NavigationViewModel.myDbContext.Subjects.Where(x => x.Id == subject.Id).SelectMany(x => x.Teachers).ToList();
            }
        }
        public void RetrieveStudents()
        {
            foreach (var student in NavigationViewModel.myDbContext.Students.ToList())
            {
                StudentWindowViewModel.Students.Add(student);
                student.Char = student.Name.ToCharArray().FirstOrDefault();
                student.subjects = NavigationViewModel.myDbContext.Students.Where(x => x.Id == student.Id).SelectMany(x => x.subjects).ToList();
            }
        }

        #endregion

        #endregion
    }
}
