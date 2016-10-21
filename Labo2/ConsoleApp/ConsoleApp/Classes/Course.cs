using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    class Course
    {
        private Dictionary<string, Evaluation> evaluations = new Dictionary<string, Evaluation>();
        private List<Student> students = new List<Student>();
        private Activity activity;

        public Activity Activity
        {
            get { return activity; }
            set { activity = value; }
        }


        public Course(Activity activity)
        {
            Activity = activity;
        }

        public void AddEval(Student student, Evaluation eval)
        {
            if (!students.Contains(student))
                students.Add(student);
            evaluations.Add(student.DictKey(), eval);
        }

        public double StandardDeviation()
        {
            return -1.0;
        }

        public double Average()
        {
            return -1.0;
        }

        public StringBuilder DisplayStudents()
        {
            StringBuilder sb = new StringBuilder();

            foreach (Student student in students)
            {
                sb.AppendLine(student.DisplayName());
            }

            return sb;
        }

        public double Note(string dictKey)
        {
            return evaluations[dictKey].Note();
        }

        public override string ToString()
        {
            return acti.ToString();
        }
    }
}
