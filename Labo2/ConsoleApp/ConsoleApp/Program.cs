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
            //var myActivities = CreateDictActivity.FromFile(globalPath + "Activities.txt", myTeachers);
            /*
            LinkEvalToStudent.FromFile(notesPath, myActivities, myStudents);

            //OutputBulletin.ToFile(outputPath, myStudents);
            OutputBulletin.ToConsole(myStudents);
             */


            //Ne pas oublier d'adapter ces 2 lignes de code
            // globalPath est le dossier où se trouvent les fichiers Students.txt, Teachers.txt, Activites.txt
            // ainsi que le dossier contenant les notes pour chaque unité
            string globalPath = @"C:\Users\marci\Desktop\Data\";
            string notesPath = globalPath + @"Notes\";
            string outputPath = globalPath + @"Output\";

            var myTeachers = CreateDictPeople.Teachers(globalPath + "Teachers.txt");
            var myStudents = CreateDictPeople.Students(globalPath + "Students.txt");

            Teacher myTeacher = new Teacher() { FirstName = "T.One", LastName = "T.Two", Salary = 500 };
            Student myStudent = new Student() { FirstName = "Hadri", LastName = "Hein" };

            Activity myActivity = new Activity() { ECTS = 3, Code = "Code", Name = "Name", Teacher = myTeacher };

            Cote myEval = new Cote();
            myEval.SetNote(15);

            Course myCourse = new Course(myActivity);

            myCourse.AddEval(myStudent, myEval);

            myStudent.Add(myCourse);

            Console.WriteLine(myStudent.Bulletin());
            Console.WriteLine(myCourse.DisplayStudents());
            
            Console.ReadLine();
        }

       
    }

}
