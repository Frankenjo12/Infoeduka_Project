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
    public partial class AddCourse : Form
    {
        private const string PATHCOURSE = @"../../../Data/Courses.txt";

        public AddCourse()
        {
            InitializeComponent();
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            Course course = new Course();
            course.Name = tbName.Text;
            course.Lecturer = tbLecturer.Text;
            course.ECTS = int.Parse(tbECTS.Text);

            if (!File.Exists(PATHCOURSE))
            {
                File.Create(PATHCOURSE);
            }

            File.AppendAllTextAsync(PATHCOURSE, Course.setForFileLine(course) + "\n");
            this.Hide();
        }
    }
}
