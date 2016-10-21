using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    class OutputBulletin
    {
        public static void ToFile(string outputFilePath, Dictionary<string, Student> students)
        {
            foreach (var key in students.Keys)
            {
                string path = outputFilePath + students[key].DisplayName() + ".txt";
                FileWrapper.WriteToFile(students[key].Bulletin(), path);
            }
            Console.WriteLine("Done writing to the file(s)");
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
