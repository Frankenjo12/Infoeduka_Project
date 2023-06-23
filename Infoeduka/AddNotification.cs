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
    public partial class AddNotification : Form
    {
        private const string PATHNOTIF = @"../../../Data/Notifications.txt";
        private const string PATHCOURSE = @"../../../Data/Courses.txt";

        public AddNotification()
        {
            InitializeComponent();
            if (!File.Exists(PATHCOURSE))
            {
                File.Create(PATHCOURSE);
            }

            string[] lines = File.ReadAllLines(PATHCOURSE);
            List<Course> courses = new();
            lines.ToList().ForEach(line => courses.Add(Course.parseFromFileLine(line)));

            courses.ForEach(course => cbCourses.Items.Add(course.Name));
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            Notification notif = new Notification();
            notif.Title = tbTitle.Text;
            notif.DateTime = DateTime.Now;
            notif.Course = cbCourses.SelectedItem.ToString();
            notif.Message = tbMessage.Text;

            if (!File.Exists(PATHNOTIF))
            {
                File.Create(PATHNOTIF);
            }

            File.AppendAllTextAsync(PATHNOTIF, Notification.setForFileLine(notif) + "\n");
            this.Hide();
        }
    }
}
