using System.Collections.Generic;
using TokenBasedAuthentication.DataAccess.HelperModels;

namespace TokenBasedAuthentication.DataAccess.HelperMethods
{
    public class DataPopulator
    {
        public static List<AuthenticationRole> GetRoles()
        {
            var list = new List<AuthenticationRole>
            {
                new AuthenticationRole
                {
                    CompanyId = 1,
                    RoleId = 1,
                    RoleName = "Administrator"
                },
                new AuthenticationRole
                {
                    CompanyId = 1,
                    RoleId = 2,
                    RoleName = "Admin"
                }
            };


            return list;
        }
    }
}