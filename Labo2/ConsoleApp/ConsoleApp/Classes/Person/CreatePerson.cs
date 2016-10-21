using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{

    class CreatePerson
    {
        public static Teacher Teacher(string[] param) 
        {
            if(param.Length == 3)
            {
                Teacher new_teacher = new Teacher() { FirstName = param[1], LastName = param[0] };
                int salary = 0;
                bool success = int.TryParse(param[2], out salary);

                if (success)
                {
                    new_teacher.Salary = salary;
                    return new_teacher;
                }
            }

            return null;
        }

        public static Student Student(string[] param)
        {
            if (param.Length == 2)
                return new Student() { LastName = param[0], FirstName = param[1] };
            else
                return null;
        }

    }


    class CreateDictPeople
    {
        private static List<Tuple<Student, Teacher>> FromFile(string path)
        {
            List<string> myList = FileWrapper.ReadFile(path);
            List<Tuple<Student, Teacher>> people = new List<Tuple<Student, Teacher>>();

            foreach (string line in myList)
            {
                string[] param = line.Split(';');
                Tuple<Student, Teacher> newTuple  = new Tuple<Student, Teacher>(CreatePerson.Student(param), CreatePerson.Teacher(param));
                if(newTuple.Item1 != null || newTuple.Item2 != null)
                {
                    people.Add(newTuple);
                }
            }

            return people;
        }

        public static Dictionary<string, Teacher> Teachers(string path)
        {
            var myPeople = FromFile(path);
            Dictionary<string, Teacher> myTeachers = new Dictionary<string, Teacher>();
            foreach (var people in myPeople)
            {
                if (people.Item2 != null)
                    myTeachers.Add(people.Item2.DictKey(), people.Item2);
            }
            return myTeachers;
        }

        public static Dictionary<string, Student> Students(string path)
        {
            var myPeople = FromFile(path);
            Dictionary<string, Student> myStudents = new Dictionary<string, Student>();
            foreach (var people in myPeople)
            {
                if (people.Item1 != null)
                    myStudents.Add(people.Item1.DictKey(), people.Item1);
            }
            return myStudents;

        }
    }
}
