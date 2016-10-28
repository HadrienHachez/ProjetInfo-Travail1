using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    
    class Program
    {

        static void Main(string[] args)
        {
            string rootPathPath = Path.GetDirectoryName(Process.GetCurrentProcess().MainModule.FileName);
            string configFilePath = rootPathPath + @"\config.ini";

            string globalPath = FileWrapper.ReadFile(configFilePath)[0];
            string notesPath = globalPath + @"Notes\";
            string outputPath = globalPath + @"Output\";

            var myTeachers = CreateDictPeople.Teachers(globalPath + "Teachers.txt");
            var myStudents = CreateDictPeople.Students(globalPath + "Students.txt");
            var myCourses = CreateDictCourse.FromFile(globalPath + "Activities.txt", myTeachers);

            LinkEvalToStudent.FromFile(notesPath, myCourses, myStudents);

            var HumanInterface = new Interface(myStudents, myCourses);

            while(HumanInterface.running)
                HumanInterface.Display();

        }


    }

}
