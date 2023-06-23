using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infoeduka.Model
{
    internal class User : IComparable<User>
    {
        private const char DEL = '|';

        public string Email { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }

        public static User parseFromFileLine(string line)
        {
            string[] data = line.Split(DEL);
            User user = new User();
            user.Email = data[0];
            user.Password = data[1];
            user.Role = data[2];

            return user;
        }

        public static string SetForFileLine(User user)
            => user.Email + DEL + user.Password + DEL + user.Role;

        public int CompareTo(User? other) => Email.CompareTo(other.Email);

        public override bool Equals(object? obj)
        {
            return obj is User user &&
                   Email == user.Email &&
                   Password == user.Password;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Email, Password);
        }

        public override string ToString() => $"{Email}      {Password}      {Role}";
    }
}
