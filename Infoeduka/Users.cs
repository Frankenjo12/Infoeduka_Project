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
    public partial class Users : Form
    {
        private const string PATHUSERS = @"../../../Data/Users.txt";
        private const string LOGROLEPATH = @"../../../Data/LogRole.txt";
        private const char DEL = '|';

        public Users()
        {
            InitializeComponent();
            string log = File.ReadAllText(LOGROLEPATH);
            if (log != "Admin")
            {
                usersToolStripMenuItem.Visible = false;
            }
        }

        private void Users_Activated(object sender, EventArgs e)
        {
            lbUsers.Items.Clear();
            LoadUsers();
        }

        private void LoadUsers()
        {
            if (!File.Exists(PATHUSERS))
            {
                File.Create(PATHUSERS);
            }

            string[] lines = File.ReadAllLines(PATHUSERS);
            List<User> users = new List<User>();
            foreach (string line in lines)
            {
                users.Add(User.parseFromFileLine(line));
            }
            users.Sort();

            lbUsers.Items.AddRange(users.ToArray());
        }

        private void pbxAdd_Click(object sender, EventArgs e)
        {
            CreateUser();
        }

        private void CreateUser()
        {
            AddUser addUser = new AddUser();
            addUser.Show();
        }

        private void notificationsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1 main = new Form1();
            main.Show();
            this.Hide();
        }

        private void logOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Hide();
        }

        private void coursesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Courses courses = new Courses();
            courses.Show();
            this.Hide();
        }
    }
}
