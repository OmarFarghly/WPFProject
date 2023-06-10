using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace WpfProject.Utilites
{//base class for all view model classes it provides support for property change notifications
    public class ViewModelBase : INotifyPropertyChanged
    {
        #region Properties
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion
        #region Methods
        public void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            //?. operator, it is called the null-conditional operator or the null-conditional access operator.
            //It is used to guard against null references and prevent a null reference exception from being thrown.
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName)); //program wont work if we remove ? why??
        }
        #endregion


    }
}
