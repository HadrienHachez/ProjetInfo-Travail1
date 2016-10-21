using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ConsoleApp
{
    class FileWrapper
    {
        public static List<string> ReadFile(string filePath)
        {
            List<string> myList = new List<string> { };

            if (!File.Exists(filePath))
                return myList;

            using (StreamReader mySteam = File.OpenText(filePath))
            {
                string line;
                while ( (line = mySteam.ReadLine()) != null)
                {
                    myList.Add(line);
                }
            }

            return myList;
        }

        private static void WriteFile(List<string> list, string filePath)
        {
            using (StreamWriter myFile = new StreamWriter(filePath))
                {
                    foreach (string line in list)
                        myFile.WriteLineAsync(line);
                }
        }

        public static void WriteToFile(List<string> list, string filePath)
        {
            WriteFile(list, filePath);
        }

        public static void WriteToFile(StringBuilder sb, string filePath)
        {
            WriteFile(new List<string>(sb.ToString().Split('\n')), filePath);
        }

    }
}
