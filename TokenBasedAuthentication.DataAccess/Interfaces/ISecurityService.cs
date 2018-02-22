using System.Collections.Generic;
using TokenBasedAuthentication.DataAccess.HelperModels;

namespace TokenBasedAuthentication.DataAccess.Interfaces
{
    public interface ISecurityService
    {
        bool Login(string userName, string password);

        List<AuthenticationRole> GetRoleForUser(string userName);
    }
}