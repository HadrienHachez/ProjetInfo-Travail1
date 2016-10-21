using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    class LinkEvalToStudent
    {
        public static void FromFile(string folderpath, Dictionary<string, Course> courses, Dictionary<string, Student> students)
        {
            foreach (string key in courses.Keys)
            {
                string filePath = folderpath + key + ".txt";
                List<string> studentNotes = FileWrapper.ReadFile(filePath);

                foreach (string line in studentNotes)
                {
                    string[] param = line.Split(';');
                    if (param.Length == 3)
                    {
                        string studentKey = param[0] + param[1];
                        if (students.ContainsKey(studentKey))
                        {
                            Student currentStudent = students[studentKey];
                            Course currentCourse = courses[key];

                            var new_eval = CoteOrApprec(param[2]);
                            currentCourse.AddEval(currentStudent, new_eval);
                            currentStudent.Add(currentCourse);
                            
                        }
                    }
                }
                    
            }
            
        }

        private static Evaluation CoteOrApprec(string param) 
        {
            int integer = 0;
            if (int.TryParse(param, out integer))
                return CreateEval(integer);
            else
                return CreateEval(param);
        }

        private static Evaluation CreateEval(string apprec)
        {
            Appreciation eval = new Appreciation();
            eval.setAppreciation(apprec);

            return eval;
        }

        private static Evaluation CreateEval(int note)
        {
            Cote eval = new Cote();
            eval.SetNote(note);

            return eval;
        }
    }
}
