using System.Collections.Generic;

namespace AuthenticationServer.DataAccess.HelperModels
{
    public partial class AuthenticationRole
    {
        public int RoleId { get; set; }
        public int CompanyId { get; set; }
        public string RoleName { get; set; }
        
    }
}
