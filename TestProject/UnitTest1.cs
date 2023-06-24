using Infoeduka;
using Infoeduka.Model;
using Microsoft.VisualBasic.ApplicationServices;
using System.Drawing.Text;
using System.ComponentModel.Design.Serialization;
using System.Drawing;
using System.Windows.Forms;

namespace TestProject
{
    [TestClass]
    public class UnitTest1
    {
        private const string USERPATH = @"../../../../Infoeduka/Data/Users.txt";
        private const string PATHNOTIF = @"../../../../Infoeduka/Data/Notifications.txt";
        private const string PATHCOURSE = @"../../../../Infoeduka/Data/Courses.txt";
        private const string PATHUSERS = @"../../../../Infoeduka/Data/Users.txt";

        [TestMethod]
        public void TestLogin()
        {
            List<UserModel> users = new List<UserModel>();

            if (!File.Exists(USERPATH))
            {
                File.Create(USERPATH);
            }

            string[] lines = File.ReadAllLines(USERPATH);
            

            foreach (string line in lines)
            {
                users.Add(UserModel.parseFromFileLine(line));
            }

            Assert.IsTrue(users.Count() > 0);

            UserModel user = new UserModel();
            user.Email = "email";
            user.Password = "1234";

            if (!users.Contains(user))
            {
                Assert.Fail();
            }
        }

        [TestMethod]
        public void TestNotifications()
        {
            List<Notification> notif = new List<Notification>();

            if (!File.Exists(PATHNOTIF))
            {
                File.Create(PATHNOTIF);
            }

            string[] lines = File.ReadAllLines(PATHNOTIF);
            foreach (string line in lines)
            {
                string[] data = line.Split('|');
                Notification notification = new Notification();
                notification.Title = data[0];
                notification.DateTime = DateTime.Parse(data[1]);
                notification.Course = data[2];
                notification.Message = data[3];

                notif.Add(notification);
            }

            Assert.IsTrue(notif.Count() > 0);
        }

        [TestMethod]
        public void TestCourses()
        {
            List<Course> courses = new List<Course>();

            if (!File.Exists(PATHCOURSE))
            {
                File.Create(PATHCOURSE);
            }

            string[] lines = File.ReadAllLines(PATHCOURSE);
            foreach (string line in lines)
            {
                courses.Add(Course.parseFromFileLine(line));
            }

            Assert.IsTrue(courses.Count() > 0);
        }

        [TestMethod]
        public void TestUsers()
        {
            List<UserModel> users = new List<UserModel>();

            if (!File.Exists(PATHUSERS))
            {
                File.Create(PATHUSERS);
            }

            string[] lines = File.ReadAllLines(PATHUSERS);
            foreach (string line in lines)
            {
                users.Add(UserModel.parseFromFileLine(line));
            }

            Assert.IsTrue(users.Count() > 0);
        }

        [TestMethod]
        public void TestAddingUsers()
        {
            string[] lines = File.ReadAllLines(PATHUSERS); 
            int startCount = lines.Count();

            UserModel user = new UserModel();
            user.Email = "testUser";
            user.Password = "TestPassword";

            if (!File.Exists(PATHUSERS))
            {
                File.Create(PATHUSERS);
            }

            File.AppendAllTextAsync(PATHUSERS, UserModel.SetForFileLine(user) + "\n");

            lines = File.ReadAllLines(PATHUSERS);
            int endCount = lines.Count();

            Assert.IsTrue(endCount == startCount + 1);
        }

        [TestMethod]
        public void TestAddingNotifications()
        {
            string[] lines = File.ReadAllLines(PATHNOTIF);
            int startCount = lines.Count();

            Notification notification = new Notification();
            notification.Title = "Test";
            notification.DateTime = DateTime.Now;
            notification.Course = "TestCourse";
            notification.Message = "TestMessage";

            if (!File.Exists(PATHNOTIF))
            {
                File.Create(PATHNOTIF);
            }

            File.AppendAllTextAsync(PATHNOTIF, Notification.setForFileLine(notification) + "\n");

            lines = File.ReadAllLines(PATHNOTIF);
            int endCount = lines.Count();

            Assert.IsTrue(endCount == startCount + 1);
        }

        [TestMethod]
        public void TestAddingCourses()
        {
            string[] lines = File.ReadAllLines(PATHCOURSE);
            int startCount = lines.Count();

            Course course = new Course();
            course.Name = "Test";
            course.Lecturer = "Test";
            course.ECTS = 6;

            if (!File.Exists(PATHCOURSE))
            {
                File.Create(PATHCOURSE);
            }

            File.AppendAllTextAsync(PATHCOURSE, Course.setForFileLine(course) + "\n");

            lines = File.ReadAllLines(PATHCOURSE);
            int endCount = lines.Count();

            Assert.IsTrue(endCount == startCount + 1);
        }
    }
}