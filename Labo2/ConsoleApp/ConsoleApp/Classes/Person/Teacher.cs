using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    class Teacher : Person
    {
        private int salary;

        public int Salary
        {
            get
            {
                return salary;
            }

            set
            {
                salary = value;
            }
        }

        public override string DictKey()
        {
            return LastName;
        }

        public Teacher(Person source, int salary) : base(source.FirstName, source.LastName)
        {
            Salary = salary;
        }

        public Teacher()
        {

        }
    }
}
