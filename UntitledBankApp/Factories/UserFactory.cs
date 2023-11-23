using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UntitledBankApp.Factories
{
    public class UserFactory
    {
        private List<User> _users;

        public UserFactory(List<User> users)
        {
            _users = users;
        }

        public bool CreateUser(Role role, string fullname, string username, string password)
        {
            bool checkUsername = _users.Exists(u => u.Username == username);
            if (checkUsername)
            {
                return false;
            }
            else
            {
                User newUser = CreateSpecificUser(role, fullname, username, password);
                _users.Add(newUser);
                return true;
            }
        }
        private static User CreateSpecificUser(Role role, string fullname, string username, string password)
        {
            switch (role)
            {
                case Role.Admin:
                    return new Admin(fullname, username, password);
                case Role.Client:
                    return new Client(fullname, username, password);
                default:
                    throw new ArgumentException("Invalid role");
            }
        }
    }
}
