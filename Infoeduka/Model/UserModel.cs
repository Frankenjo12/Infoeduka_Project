using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infoeduka.Model
{
    public class UserModel : IComparable<UserModel>
    {
        private const char DEL = '|';

        public string Email { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }

        public static UserModel parseFromFileLine(string line)
        {
            string[] data = line.Split(DEL);
            UserModel user = new UserModel();
            user.Email = data[0];
            user.Password = data[1];
            user.Role = data[2];

            return user;
        }

        public static string SetForFileLine(UserModel user)
            => user.Email + DEL + user.Password + DEL + user.Role;

        public int CompareTo(UserModel? other) => Email.CompareTo(other.Email);

        public override bool Equals(object? obj)
        {
            return obj is UserModel user &&
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
