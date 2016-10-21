using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{

    class CreateActivity 
    {
        public static Activity Activity(string[] param, Dictionary<string, Teacher> teacherDict)
        {
            // param = [Code, Description, Teacher, ECTS]
            if(param.Length == 4)
            {
                Activity new_teacher = new Activity();
                int ects = 0;
                bool success = int.TryParse(param[3], out ects);

                if (success && teacherDict.ContainsKey(param[2]))
                {
                    return new Activity(param[1], ects, param[0], teacherDict[param[2]]);
                }
            }

            return null;
        }
    }

    class CreateDictActivity
    {
        public static Dictionary<string, Activity> FromFile(string path, Dictionary<string, Teacher> teacherDict)
        {

            List<string> myList = FileWrapper.ReadFile(path);
            Dictionary<string, Activity> activityDict = new Dictionary<string, Activity>();

            foreach (string line in myList)
            {
                string[] param = line.Split(';');
                var new_activity = CreateActivity.Activity(param, teacherDict);
                if (new_activity != null)
                    activityDict.Add(new_activity.Code, new_activity);

            }

            return activityDict;
        }
    }
}
