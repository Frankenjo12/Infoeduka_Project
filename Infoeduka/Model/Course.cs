using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace Infoeduka.Model
{
    public class Course : IComparable<Course>
    {
        private const char DEL = '|';

        public string Name { get; set; }
        public string Lecturer { get; set; }
        public int ECTS { get; set; }

        public static string setForFileLine(Course course)
            => course.Name + "|" + course.Lecturer + "|" + course.ECTS.ToString();

        public static Course parseFromFileLine(string line)
        {
            string[] data = line.Split(DEL);
            Course course = new Course();
            course.Name = data[0];
            course.Lecturer = data[1];
            course.ECTS = int.Parse(data[2]);
            return course;
        }

        public override string ToString() => $"{Name}      {Lecturer}      {ECTS}";

        public int CompareTo(Course? other) => Name.CompareTo(other.Name);
    }
}