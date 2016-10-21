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
}
