using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    class Student : Person
    {
        private List<Evaluation> listeEval = new List<Evaluation>();

        public Student(Person person) : base(person.FirstName, person.LastName)
        {
            listeEval = new List<Evaluation>();
        }

        public Student()
        { 
        }

        public void Add(Evaluation new_eval)
        {
            listeEval.Add(new_eval);
        }

        public double Average()
        {
            return Convert.ToDouble( listeEval.Sum(eval => eval.Note()) ) / (listeEval.Count*20);
        }

        public StringBuilder Bulletin()
        {
            StringBuilder bulletin = new StringBuilder();

            bulletin.AppendLine(DisplayName());

            foreach (Evaluation eval in listeEval)
                bulletin.AppendLine(eval.ToString());            

            bulletin.AppendLine(String.Format("Moyenne de {0:P}", Average()));

            return bulletin;
        }
    }
}
