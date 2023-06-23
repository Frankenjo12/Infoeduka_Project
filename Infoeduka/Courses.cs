
using Infoeduka.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Infoeduka
{
    public partial class Courses : Form
    {
        private const string LOGROLEPATH = @"../../../Data/LogRole.txt";
        private const string PATHCOURSES = @"../../../Data/Courses.txt";
        private const char DEL = '|';

        public Courses()
        {
            InitializeComponent();
            string log = File.ReadAllText(LOGROLEPATH);
            if (log != "Admin")
            {
                usersToolStripMenuItem.Visible = false;
            }
        }

        private void notificationsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1 main = new Form1();
            main.Show();
            this.Hide();
        }

        private void usersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Users users = new Users();
            users.Show();
            this.Hide();
        }

        private void logOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Hide();
        }

        private void Courses_Activated(object sender, EventArgs e)
        {
            LoadCourses();
        }

        private void LoadCourses()
        {
            lbCourses.Items.Clear();

            if (!File.Exists(PATHCOURSES))
            {
                File.Create(PATHCOURSES);
            }

            string[] lines = File.ReadAllLines(PATHCOURSES);
            List<Course> courses = new List<Course>();
            foreach (string line in lines)
            {
                courses.Add(Course.parseFromFileLine(line));
            }
            courses.Sort();

            lbCourses.Items.AddRange(courses.ToArray());
        }

        private void pbxAdd_Click(object sender, EventArgs e)
        {
            CreateCourse();
        }

        private void CreateCourse()
        {
            AddCourse addCourse = new AddCourse();
            addCourse.Show();
        }
    }
}
