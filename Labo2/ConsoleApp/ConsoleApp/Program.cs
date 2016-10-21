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

            //Ne pas oublier d'adapter ces 2 lignes de code
            // globalPath est le dossier où se trouvent les fichiers Students.txt, Teachers.txt, Activites.txt
            // ainsi que le dossier contenant les notes pour chaque unité

            string globalPath = @"C:\Users\marci\Desktop\Data\";
            string notesPath = globalPath + @"Notes\";
            string outputPath = globalPath + @"Output\";

            var myTeachers = CreateDictPeople.Teachers(globalPath + "Teachers.txt");
            var myStudents = CreateDictPeople.Students(globalPath + "Students.txt");
            var myCourses = CreateDictCourse.FromFile(globalPath + "Activities.txt", myTeachers);
            

            Console.WriteLine(DictToString(myTeachers));
            Console.WriteLine(DictToString(myStudents));
            Console.WriteLine(DictToString(myCourses));

            LinkEvalToStudent.FromFile(notesPath, myCourses, myStudents);

            OutputBulletin.ToConsole(myStudents);

            Console.ReadLine();
        }

        private static StringBuilder DictToString(Dictionary<string, Teacher> dict)
        {
            StringBuilder sb = new StringBuilder();

            foreach (var person in dict.Values)
            {
                sb.AppendLine(person.DisplayName());
            }

            return sb;
        }

        private static StringBuilder DictToString(Dictionary<string, Student> dict)
        {
            StringBuilder sb = new StringBuilder();

            foreach (var person in dict.Values)
            {
                sb.AppendLine(person.DisplayName());
            }

            return sb;
        }

        private static StringBuilder DictToString(Dictionary<string, Course> dict)
        {
            StringBuilder sb = new StringBuilder();

            foreach (var course in dict.Values)
            {
                sb.AppendLine(course.ToString());
            }

            return sb;
        }


    }

}
