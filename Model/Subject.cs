using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfProject.ViewModel;

namespace WpfProject.Model
{
    public class Subject
    {
        public int Id { get; set; }
        public char Char { get; set; }
        public string Name { get; set; }
        public List<Teacher> Teachers { get; set; }
        public int TotalHours { get; set; }
        public List<Student> Students { get; set; }
        public Subject()
        {
            Teachers= new List<Teacher>();   
         
            Students = new List<Student>();
            
        }
        public override string ToString()
        {
            return Name;
        }
    }
}
