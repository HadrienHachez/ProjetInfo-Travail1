using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    
    class Program
    {

        static void Main(string[] args)
        {
            string globalPath = @"C:\Users\Dell\Desktop\Labo2\Data\";
            string outputPath = globalPath + @"Output\";

            var myTeachers = CreateDictPeople.Teachers(globalPath + "Teachers.txt");
             var myActivities = CreateDictActivity.FromFile(globalPath + "Activities.txt", myTeachers);
             var myStudents = CreateDictPeople.Students(globalPath + "Students.txt");

             LinkEvalToStudent.FromFile(globalPath + @"Notes\", myActivities, myStudents);

            OutputBulletin.ToFile(outputPath, myStudents);
            OutputBulletin.ToConsole(myStudents);

            Console.ReadLine();
        }

       
    }

}
