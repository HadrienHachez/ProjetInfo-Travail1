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
        private string filePath;

        public string FilePath
        {
            get { return filePath; }
            set { filePath = value; }
        }

        public FileWrapper (string filePath)
        {
            FilePath = filePath;
        }

        public List<string> ReadFile()
        {
            List<string> myList = new List<string> { };

            if (!File.Exists(FilePath))
                return myList;

            using (StreamReader mySteam = File.OpenText(FilePath))
            {
                string line;
                while ( (line = mySteam.ReadLine()) != null)
                {
                    myList.Add(line);
                }
            }

            return myList;
        }

        private void WriteFile(List<string> list)
        {
            using (StreamWriter myFile = new StreamWriter(FilePath))
                {
                    foreach (string line in list)
                        myFile.WriteLineAsync(line);
                }
        }

        public void WriteToFile(List<string> list)
        {
            WriteFile(list);
        }

        public void WriteToFile(StringBuilder sb)
        {
            WriteFile(new List<string>(sb.ToString().Split('\n')));
        }

    }
}
