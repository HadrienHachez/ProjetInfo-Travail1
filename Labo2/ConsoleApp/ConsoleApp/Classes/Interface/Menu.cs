using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{ 
    class Interface
    {
        private int currentMenu=0;
        private Dictionary<string, int> menuDict = new Dictionary<string, int>() { { "0", 0 },
                                                                                   { "-1", -1 },
                                                                                   {"1", 1 },
                                                                                   {"2", 2 } };

        private Dictionary<string, Student> _students = new Dictionary<string, Student>();
        private Dictionary<string, Course> _courses = new Dictionary<string, Course>();
        public bool running = true;

        public Interface(Dictionary<string, Student> students, Dictionary<string, Course> courses)
        {
            _students = students;
            _courses = courses;
        }

        private void MainMenu()
        {
            Console.WriteLine("Main Menu : 0");
            Console.WriteLine("Students : 1");
            Console.WriteLine("Courses : 2");
            Console.WriteLine("Exit : -1");
        }

        private void Welcome()
        {
            Console.WriteLine("Welcome message");
        }

        private void ExitMessage()
        {
            Console.WriteLine("Goodbye!");
        }

        private void StudentMenu()
        {
            foreach (var student in _students.Values)
            {
                Console.WriteLine(student.DisplayName());
            }
        }

        private void CoursesMenu()
        {
            foreach (var course in _courses.Values)
            {
                Console.WriteLine(course.ToString());
            }
        }

        private void Navigate(string param)
        {
            if (menuDict.Keys.Contains(param))
            {
                Console.WriteLine(currentMenu);
                currentMenu = menuDict[param];
            }
            else
            {
                Console.WriteLine(currentMenu);
                currentMenu = -1;
            }
        }

        public void Display()
        {
            switch (currentMenu)
            {
                case 0:
                    Console.Clear();
                    Welcome();
                    MainMenu();
                    Navigate(Console.ReadLine());
                    break;

                case 1:
                    Console.Clear();
                    StudentMenu();
                    Navigate(Console.ReadLine());
                    break;

                case 2:
                    Console.Clear();
                    CoursesMenu();
                    Navigate(Console.ReadLine());
                    break;

                case -1:
                    Console.Clear();
                    ExitMessage();
                    running = false;
                    break;
            }
        }
    }
}
