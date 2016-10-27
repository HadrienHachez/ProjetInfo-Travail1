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
        private Dictionary<string, int> menuDict = new Dictionary<string, int>() { {"0", 0 },
                                                                                   {"", 1 },
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
                    ExitMessage("Press any key to exit");
                    running = false;
                    break;
            }
        }

        //Changes the currentMenu attribute to change menus
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

        //Shows the menu index
        private void MenuIndex()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\n Menu Index");
            Console.WriteLine("1) Main Menu");
            Console.WriteLine("2) Students");
            Console.WriteLine("3) Courses");
            Console.WriteLine("0) Exit\n");
            Console.ResetColor();
            Console.Write("Choose option [0-3] : ");
        }

        //Shows the welcome message
        private void Welcome()
        {
            Console.WriteLine("__--** Bulletin 2.0 **--__\n");
        }

        //Shows the exit message and clears the console
        private void ExitMessage(string exitMessage)
        {
            Console.WriteLine(exitMessage);
            Console.ReadKey();
            Console.Clear();
        }

        //Shows the Student Menu
        private void StudentMenu()
        {
            string dictKey;

            do
            {
                DisplayAllStudents();
                Console.WriteLine();
                string data = OutputStudentNotes("Input the firstname and lastname of the student : ", out dictKey);
                Console.Clear();
                Console.WriteLine(data);
                if (dictKey != null) //If we match the input to a student, then print out it's bulletin
                {
                    WriteBulletin(_students[dictKey]);
                }
            } while (dictKey == null);
            Console.Clear();
            
        }

        //Shows the Courses Menu
        private void CoursesMenu()
        {
            DisplayAllCourses();
            Console.WriteLine();
            string data = OutputCourseDetails("Input course code : ");
            Console.Clear();
            Console.WriteLine(data);
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

        //Builds a dictionnary key from user input
        private string BuildDictKey(string userInput)
        {
            return BuildDictKey(userInput.Split());
        }

        //Builds a dictionnary key from a string array
        private string BuildDictKey(string[] array)
        {
            return String.Concat(array).ToUpper();
        }

        //Shows a message and waits for user input
        private string GatherInput(string messageToShow)
        {
            Console.Write(messageToShow);
            return Console.ReadLine();
        }

        //Outputs the Bulletin of a student
        private string OutputStudentNotes(string message, out string key)
        {
            string input = GatherInput(message);
            string dictKey = BuildDictKey(input);

            if (_students.Keys.Contains(dictKey)) 
            {
                key = dictKey;
                return _students[dictKey].Bulletin().ToString();
            }
            else
            {   //trying to match a student with the firstname/lastname reversed
                string[] array = input.Split(' ');
                Array.Reverse(array);
                string invertedDictKey = BuildDictKey(array);
                if(_students.Keys.Contains(invertedDictKey))
                    {
                        key = invertedDictKey;
                        return _students[invertedDictKey].Bulletin().ToString();
                    }
                key = null;
                return String.Format("Student \"{0}\" doesn't exist\n", input);
            }
        }

        private string OutputCourseDetails(string message)
        {
            string dictKey = BuildDictKey(GatherInput(message));
            if (_courses.Keys.Contains(dictKey))
                return BuildCourseDetails(_courses[dictKey]);
            else
                return String.Format("Course with code {0} doesn't exist", dictKey);

        }

        private string BuildCourseDetails(Course myCourse)
        {
            return String.Format("{0}\n\n{1}\nwith an average score of {2}/20", 
                                    myCourse.ToString(), 
                                    myCourse.StudentNotes(), 
                                    myCourse.Average());
        }

        private void WriteBulletin(Student student)
        {
            Console.WriteLine("Would you like to write the bulletin to a file? (Y/N)");
            string keyStroke = Console.ReadKey().Key.ToString();
            if (keyStroke.ToUpper() == "Y")
                WriteToFile(student);      
        }

        private void WriteToFile(Student student)
        {
            Console.WriteLine("\nInput a directory to output the file : ");
            string input = Console.ReadLine();
            string directoryOutput = input.EndsWith("\\") ? input : input + "\\"; // si input ne se finit pas par "\", on l'ajoute
            OutputBulletin.ToFile(directoryOutput, student);
            Console.WriteLine("Written to the file sucessfully");
            ExitMessage("Press any key to go back to Menu Index");
        }

    }
}
