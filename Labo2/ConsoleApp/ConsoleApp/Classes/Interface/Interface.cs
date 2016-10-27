using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{ 
    class Interface
    {
        private int currentMenu=1;
        private Dictionary<string, int> menuDict = new Dictionary<string, int>() { { "0", 0 },
                                                                                   {"1", 1 },
                                                                                   {"3", 3 },
                                                                                   {"2", 2 } };

        private Dictionary<string, Student> _students = new Dictionary<string, Student>();
        private Dictionary<string, Course> _courses = new Dictionary<string, Course>();
        public bool running = true;

        public Interface(Dictionary<string, Student> students, Dictionary<string, Course> courses)
        {
            _students = students;
            _courses = courses;
        }

        public void Display()
        {
            switch (currentMenu)
            {
                case 1:
                    Console.Clear();
                    Welcome();
                    Navigate();
                    break;

                case 2:
                    Console.Clear();
                    StudentMenu();
                    Navigate();
                    break;

                case 3:
                    Console.Clear();
                    CoursesMenu();
                    Navigate();
                    break;

                case 0:
                    Console.Clear();
                    ExitMessage();
                    running = false;
                    break;
            }
        }

        private void Navigate()
        {
            MenuIndex();
            string param = Console.ReadLine();
            if (menuDict.Keys.Contains(param))
            {
                Console.WriteLine(currentMenu);
                currentMenu = menuDict[param];
            }
            else
            {
                Console.WriteLine(currentMenu);
                currentMenu = 0;
            }
        }

        private void MenuIndex()
        {
            Console.WriteLine("1) Main Menu");
            Console.WriteLine("2) Students");
            Console.WriteLine("3) Courses");
            Console.WriteLine("0) Exit");
        }

        private void Welcome()
        {
            Console.WriteLine("__--**Bulletin 2.0**--__");
        }

        private void ExitMessage()
        {
            Console.WriteLine("Press any key to exit");
            Console.ReadKey();
            Console.Clear();
        }

        private void StudentMenu()
        {
            DisplayAllStudents();
            Console.WriteLine();
            Console.WriteLine(OutputStudentNotes("Firstname lastname : "));
        }

        private void CoursesMenu()
        {
            DisplayAllCourses();
            Console.WriteLine();
        }

        private void DisplayAllStudents()
        {
            foreach (var student in _students.Values.OrderBy(x => x.DictKey()))
            {
                Console.WriteLine(student.DisplayName());
            }
        }

        private void DisplayAllCourses()
        {
            foreach (var course in _courses.Values.OrderBy(x => x.DictKey()))
            {
                Console.WriteLine(course.ToString());
            }
        }

        private string BuildDictKey(string userInput)
        {
            return String.Concat(userInput.Split()).ToUpper();
        }

        private string OutputStudentNotes(string message)
        {
            string dictKey = BuildDictKey(GatherInput(message));
            if (_students.Keys.Contains(dictKey))
                return _students[dictKey].Bulletin().ToString();
            else
                return "N'existe pas";
        }

        private string GatherInput(string messageToShow)
        {
            Console.Write(messageToShow);
            return Console.ReadLine();
        }

    }
}
