using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    class Student : Person
    {
        private List<Course> CourseList = new List<Course>();

        public Student(Person person) : base(person.FirstName, person.LastName)
        {
            CourseList = new List<Course>();
        }

        public Student()
        { 
        }

        public override string DictKey()
        {
            return (LastName + FirstName).ToUpper();
        }

        public void Add(Course newCourse)
        {
            CourseList.Add(newCourse);
        }

        public double Average()
        {
            return Convert.ToDouble( CourseList.Sum(course => course.Note(DictKey())) ) / (CourseList.Count*20);
        }

        public StringBuilder Bulletin()
        {
            StringBuilder bulletin = new StringBuilder();

            bulletin.AppendLine(DisplayName());

            if (CourseList.Count != 0)
            {
                foreach (Course course in CourseList)
                    bulletin.AppendLine(String.Format("\n{0} \n        Score:{1}/20 Z:{2:0.00}",
                                        course.ToString(),
                                        course.Note(DictKey()),
                                        ComputeZ(course)));

                bulletin.AppendLine(String.Format("\nwith an average score of {0:P}", Average()));
            }
            else
                bulletin.AppendLine("\nDid not take any exams");
            return bulletin;
        }

        private double ComputeZ(Course stat)
        {
            return ( Convert.ToDouble(stat.Note(DictKey())) - stat.Average()) / stat.StandardDeviation();
        }
    }
}
