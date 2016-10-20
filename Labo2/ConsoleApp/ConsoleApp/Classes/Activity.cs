using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    class Activity
    {
        private int ects;
        private string name, code;
        private Teacher teacher;

        
        public int ECTS
        {
            get { return ects; }
            set { ects = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string Code
        {
            get { return code; }
            set { code = value; }
        }

        public Teacher Teacher
        {
            get { return teacher; }
            set { teacher = value; }
        }

        public Activity(string name, int ects, string code, Teacher teacher)
        {
            this.ECTS = ects;
            this.Name = name;
            this.Code = code;
            this.Teacher = teacher;
        }

        public Activity()
        { }

        public override string ToString()
        {
            return string.Format("{0} : {1} ({2}, {3})", this.Code, this.Name, this.ECTS, this.Teacher.DisplayName());
        }
    }
}
