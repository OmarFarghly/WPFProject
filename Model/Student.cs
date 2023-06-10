using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfProject.Model
{
    public class Student
    {
        public int Id { get; set; }
        public char Char { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public gender Gender { get; set; }
        public double Fees { get; set; }
        public List<Subject> subjects { get; set; }
        public Student()
        {
            subjects= new List<Subject>();
           
        }
        public override string ToString()
        {
            return Name;
        }
    }

    public enum gender
    {
        male,
        female
    }
}
