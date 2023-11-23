using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UntitledBankApp.Factories
{
    public class UserFactory
    {
        public User CreateUser(Role role, string fullname, string username, string password)
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
