using Infoeduka.Model;
using Microsoft.VisualBasic.Logging;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Infoeduka
{
    public partial class Login : Form
    {
        private const string USERPATH = @"../../../Data/Users.txt";
        private const string LOGROLEPATH = @"../../../Data/LogRole.txt";
        List<UserModel> users = new();
        private string logRole = "";

        public Login()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            LoadUsers();
            ValidateUser();
        }

        private void ValidateUser()
        {
            UserModel user = new UserModel();
            user.Email = tbEmail.Text;
            user.Password = tbPass.Text;

            if(!users.Contains(user))
            {
                tbEmail.Text = "";
                tbPass.Text = "";
            }
            else
            {
                logRole = users.Find(u => u.Email == user.Email).Role;
                File.WriteAllText(LOGROLEPATH, logRole);

                Form1 main = new Form1();
                main.Show();
                this.Hide();
            }
        }

        private void LoadUsers()
        {
            if(!File.Exists(USERPATH))
            {
                File.Create(USERPATH);
            }
            
            string[] lines = File.ReadAllLines(USERPATH);
            foreach (string line in lines)
            {
                users.Add(UserModel.parseFromFileLine(line));
            }
        }
    }
}
