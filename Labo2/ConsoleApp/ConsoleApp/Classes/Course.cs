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

        public Activity acti
        {
            get { return activity; }
            set { activity = value; }
        }


        public Course(Activity activity)
        {
            acti = activity;
        }

        public void AddEval(Student student, Evaluation eval)
        {
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

        public string DisplayStudents()
        {
            return null;
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
