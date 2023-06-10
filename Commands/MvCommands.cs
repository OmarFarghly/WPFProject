using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WpfProject.Commands
{ //Com-1-A Class that implement Icommand Interface
    public class MvCommands : ICommand
    {
        #region Properties 
        //Com-2-Define an action delegate for Excute method and a predicate one for CanExecute Method 
        public Action<object> DelegateForVoid { get; set; }
        public Predicate<object> DelegateForBool { get; set; }
        //eventhandler activates automatically 
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }
        #endregion
        #region Constructor
        //Com-3-Define a Constructor that takes the 2 delegates as arguments 
        public MvCommands(Action<object> _execute,Predicate<object> _canExecute=null)
        {
            DelegateForVoid= _execute;
            DelegateForBool= _canExecute;
        }
        #endregion
        #region Methods
        //Com-4-pass the method in the delegate to the execute and can execute methods 
        public bool CanExecute(object parameter) => DelegateForBool == null || DelegateForBool(parameter); //programm wont work with defination in the lecture
                                                                                                           //check why 
        public void Execute(object parameter) => DelegateForVoid(parameter);

        //Com-5-this class is a general template for all commands no changes need to be made to it 
        #endregion


    }
}
