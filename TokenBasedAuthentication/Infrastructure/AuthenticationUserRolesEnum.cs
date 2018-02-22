using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace TokenBasedAuthentication.Infrastructure
{
    public enum AuthenticationUserRolesEnum
    {
        [Description("Administrator")]
        Admin = 0,
        [Description("Data Entry Operator")]
        DataEntryOperator = 1,
        [Description("Accounts")]
        Accounts = 2

    }
}