using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    class CreateDictCourse
    {
            public static Dictionary<string, Course> FromFile(string path, Dictionary<string, Teacher> teacherDict)
            {

                List<string> myList = FileWrapper.ReadFile(path);
                Dictionary<string, Course> courseDict = new Dictionary<string, Course>();

                foreach (string line in myList)
                {
                    string[] param = line.Split(';');
                    var new_activity = CreateActivity.Activity(param, teacherDict);
                    if (new_activity != null)
                    {
                        Course new_course = new Course(new_activity);
                        courseDict.Add(new_course.DictKey(), new_course);
                    }

                }

                return courseDict;
            }
    }
}
