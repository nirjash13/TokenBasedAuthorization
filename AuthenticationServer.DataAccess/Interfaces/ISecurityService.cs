using System.Collections.Generic;
using AuthenticationServer.DataAccess.HelperModels;

namespace AuthenticationServer.DataAccess.Interfaces
{
    public interface ISecurityService
    {
        bool Login(string userName, string password);

        List<AuthenticationRole> GetRoleForUser(string userName);
    }
}