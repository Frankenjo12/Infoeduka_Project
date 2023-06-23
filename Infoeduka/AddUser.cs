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
    public partial class AddUser : Form
    {
        private const string PATHUSERS = @"../../../Data/Users.txt";

        public AddUser()
        {
            InitializeComponent();
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            User user = new User();
            user.Email = tbEmail.Text;
            user.Password = tbPassword.Text;
            if (rbAdmin.Checked == true)
            {
                user.Role = rbAdmin.Text;
            }
            else
            {
                user.Role = rbLecturer.Text;
            }

            if (!File.Exists(PATHUSERS))
            {
                File.Create(PATHUSERS);
            }

            File.AppendAllTextAsync(PATHUSERS, User.SetForFileLine(user) + "\n");
            this.Hide();
        }

        private void rbLecturer_Click(object sender, EventArgs e)
        {
            rbAdmin.Checked = false;
            rbLecturer.Checked = true;
        }

        private void rbAdmin_Click(object sender, EventArgs e)
        {
            rbAdmin.Checked = true;
            rbLecturer.Checked = false;
        }
    }
}
