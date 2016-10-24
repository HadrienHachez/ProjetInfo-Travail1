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

        public Course(Activity activity)
        {
            this.activity = activity;
        }

        public void AddEval(Student student, Evaluation eval)
        {
            if (!students.Contains(student))
                students.Add(student);
            evaluations.Add(student.DictKey(), eval);
        }

        public double StandardDeviation()
        {
            double average = Average(), tot = 0;
            int i = 0;
            foreach (var item in evaluations.Values)
            {
                i++;
                tot += Math.Pow(average - item.Note(),2);
            }
            return Math.Pow(tot,1/2);
        }

        public double Average()
        {
            double tot = 0;
            int i = 0;
            foreach (var item in evaluations.Values)
            {
                i++;
                tot += item.Note();
            }
            return tot/i;
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
            return activity.ToString();
        }

        public string DictKey()
        {
            return activity.Code;
        }
    }
}
