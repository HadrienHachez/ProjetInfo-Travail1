using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    class Person
    {
        private string lastName, firstName;
        public string FirstName
        {
            get
            {
                return firstName;
            }

            set
            {
                firstName = value;
            }
        }
        public string LastName
        {
            get
            {
                return lastName;
            }

            set
            {
                lastName = value;
            }
        }

        public string DisplayName()
        {
            return String.Format("{0} {1}", FirstName, LastName);
        }

        public virtual string DictKey()
        {
            return null;
        }

        public Person()
        {

        }

        public Person(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

    }
}
