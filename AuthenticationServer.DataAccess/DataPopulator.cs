using System.Collections.Generic;
using AuthenticationServer.DataAccess.HelperModels;

namespace AuthenticationServer.DataAccess
{
    public class DataPopulator
    {
        internal static List<AuthenticationRole> GetRoles(string userName)
        {
            var roles = new List<AuthenticationRole>
            {
                new AuthenticationRole
                {
                    CompanyId = 1,
                    RoleId = 1,
                    RoleName = "Admin"
                },
                new AuthenticationRole
                {
                    CompanyId = 1,
                    RoleId = 2,
                    RoleName = "Administrator"
                }
            };

            return roles;
        }
    }
}