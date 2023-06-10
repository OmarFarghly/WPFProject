using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfProject.ViewModel;

namespace WpfProject.Model
{
    public class Teacher
    {
        public int Id { get; set; }
        public char Char { get; set; }
        public string Name { get; set; }
        public gender Gender { get; set; }
        public double Salary { get; set; }
        public string Phone { get; set; }
        public Subject subject { get; set; }
        public Teacher()
        {
            subject= new Subject(); 
            
        }
        public override string ToString()
        {
            return Name;
        }
    }
}
