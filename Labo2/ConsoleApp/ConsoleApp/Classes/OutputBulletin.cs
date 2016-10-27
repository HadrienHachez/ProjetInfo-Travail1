using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    class OutputBulletin
    {
        public static void ToFile(string directoryPath, Dictionary<string, Student> students)
        {
            foreach (var key in students.Keys)
            {
                ToFile(directoryPath, students[key]);
            }
            Console.WriteLine("Done writing to the file(s)");
        }

        public static void ToFile(string directoryPath, Student student)
        {
            Directory.CreateDirectory(directoryPath);
            string path = directoryPath + student.DisplayName() + ".txt";
            FileWrapper.WriteToFile(student.Bulletin(), path);
        }

        public static void ToConsole(Dictionary<string, Student> students)
        {
            foreach (var key in students.Keys)
            {
                Console.WriteLine(students[key].Bulletin());
            }
        }
    }
}
