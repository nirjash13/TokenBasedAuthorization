using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AuthenticationServer.DataAccess.HelperModels;
using AuthenticationServer.DataAccess.Interfaces;
using AuthenticationServer.Utilities;


namespace AuthenticationServer.DataAccess.Services
{
    public class SecurityService : ISecurityService
    {
        public bool Login(string userName, string password)
        {
            var encryptedPassword = Cryptor.Encrypt("Admin123");

            if (string.Compare(encryptedPassword, password) == 0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public List<AuthenticationRole> GetRoleForUser(string userName)
        {
            return DataPopulator.GetRoles(userName);
        }
    }
}
