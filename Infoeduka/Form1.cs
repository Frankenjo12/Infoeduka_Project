namespace Infoeduka
{
    public partial class Form1 : Form
    {
        private const string LOGROLEPATH = @"../../../Data/LogRole.txt";
        private const string PATHNOTIF = @"../../../Data/Notifications.txt";

        public Form1()
        {
            InitializeComponent();
            string log = File.ReadAllText(LOGROLEPATH);
            if (log != "Admin")
            {
                usersToolStripMenuItem.Visible = false;
            }
        }

        private void logOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Hide();
        }

        private void pbxAdd_Click(object sender, EventArgs e)
        {
            CreateNotification();
        }

        private void LoadNotifications()
        {
            if (!File.Exists(PATHNOTIF))
            {
                File.Create(PATHNOTIF);
            }

            string[] lines = File.ReadAllLines(PATHNOTIF);

            lines.Reverse().ToList().ForEach(line =>
            {
                string[] data = line.Split('|');

                Label title = new Label();
                title.Size = new Size(700, 30);
                title.Font = new Font("Segoe UI", 14);
                title.Text = data[0];

                Label date = new Label();
                date.Size = new Size(100, 30);
                date.Font = new Font("Segoe UI", 10);
                date.Text = data[1];

                Label course = new Label();
                course.Size = new Size(400, 30);
                course.Font = new Font("Segoe UI", 10);
                course.Text = data[2];

                TextBox message = new TextBox();
                message.Size = new Size(720, 85);
                message.Font = new Font("Segoe UI", 10);
                message.ReadOnly = true;
                message.Multiline = true;
                message.Text = data[3];

                FlowLayoutPanel notificationPanel = new FlowLayoutPanel();
                notificationPanel.FlowDirection = FlowDirection.LeftToRight;
                notificationPanel.BackColor = Color.White;
                notificationPanel.Size = new Size(725, 150);

                notificationPanel.Controls.Add(title);
                notificationPanel.Controls.Add(date);
                notificationPanel.Controls.Add(course);
                notificationPanel.Controls.Add(message);

                flpNotifications.Controls.Add(notificationPanel);
            });
        }

        private void CreateNotification()
        {
            AddNotification addNotification = new AddNotification();
            addNotification.Show();
        }

        private void Form1_Activated(object sender, EventArgs e)
        {
            flpNotifications.Controls.Clear();
            LoadNotifications();
        }

        private void usersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Users users = new Users();
            users.Show();
            this.Hide();
        }

        private void coursesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Courses course = new Courses();
            course.Show();
            this.Hide();
        }
    }
}