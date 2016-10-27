﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    class Student : Person
    {
        private List<Course> CourseList = new List<Course>();

        public Student(Person person) : base(person.FirstName, person.LastName)
        {
            CourseList = new List<Course>();
        }

        public Student()
        { 
        }

        public override string DictKey()
        {
            return (LastName + FirstName).ToUpper();
        }

        public void Add(Course newCourse)
        {
            CourseList.Add(newCourse);
        }

        public double Average()
        {
            return Convert.ToDouble( CourseList.Sum(course => course.Note(DictKey())) ) / (CourseList.Count*20);
        }

        public StringBuilder Bulletin()
        {
            StringBuilder bulletin = new StringBuilder();

            bulletin.AppendLine(DisplayName());

            foreach (Course course in CourseList)
                bulletin.AppendLine(String.Format("{0} Z:{1}", 
                                    course.ToString() + course.Note(DictKey()), 
                                    ComputeZ(course)));

            bulletin.AppendLine(String.Format("Moyenne de {0:P}", Average()));

            return bulletin;
        }

        private double ComputeZ(Course stat)
        {
            return (stat.Note(DictKey()) - stat.Average()) / stat.StandardDeviation();
        }
    }
}
