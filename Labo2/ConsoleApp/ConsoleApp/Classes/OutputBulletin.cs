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
                FileWrapper studentFile = new FileWrapper(outputFilePath + students[key].DisplayName() + ".txt");
                studentFile.WriteToFile(students[key].Bulletin());
            }
            Console.WriteLine("Done writing to the file(s)");
        }
        public static void ToConsole(Dictionary<string, Student> students)
        {
            //Console.WriteLine(students.Keys);
            foreach (var key in students.Keys)
            {
                Console.WriteLine(students[key].Bulletin());
            }
        }
    }
}
