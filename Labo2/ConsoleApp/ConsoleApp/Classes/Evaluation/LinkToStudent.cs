using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    class LinkEvalToStudent
    {
        public static void FromFile(string folderpath, Dictionary<string, Activity> activities, Dictionary<string, Student> students)
        {
            List<string> activitiesKeys = activities.Keys.ToList();

            foreach (string key in activitiesKeys)
            {
                FileWrapper activityFile = new FileWrapper(folderpath + key + ".txt");
                List<string> studentNotes = activityFile.ReadFile();

                foreach (string line in studentNotes)
                {
                    string[] param = line.Split(';');
                    if (param.Length == 3)
                    {
                        string studentKey = param[0] + param[1];
                        if (students.ContainsKey(studentKey))
                        {
                            var new_eval = CoteOrApprec(param[2]);
                            new_eval.Activity = activities[key];
                            //Console.WriteLine(new_eval);
                            students[studentKey].Add(new_eval);
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
