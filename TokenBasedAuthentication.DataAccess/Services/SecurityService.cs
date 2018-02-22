using System;
using System.Collections.Generic;
using TokenBasedAuthentication.DataAccess.HelperMethods;
using TokenBasedAuthentication.DataAccess.HelperModels;
using TokenBasedAuthentication.DataAccess.Interfaces;
using TokenBasedAuthentication.Utilities;

namespace TokenBasedAuthentication.DataAccess.Services
{
    public class SecurityService : ISecurityService
    {
        public bool Login(string userName, string password)
        {
            var encryptedPassword = Cryptor.Encrypt("admin123");
            if (String.CompareOrdinal(password, encryptedPassword) == 0)
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
            return DataPopulator.GetRoles();
        }
    }
}