using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

using Microsoft.Owin.Security.OAuth;
using TokenBasedAuthentication.DataAccess.HelperModels;
using TokenBasedAuthentication.DataAccess.Interfaces;
using TokenBasedAuthentication.Utilities;

namespace TokenBasedAuthentication.Infrastructure
{
    public class TokenBasedAuthenticationServerProvider : OAuthAuthorizationServerProvider
    {
        public TokenBasedAuthenticationServerProvider(ISecurityService securityService)
        {
            SecurityService = securityService;
        }
        public ISecurityService SecurityService { get; set; }

        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            await Task.Run(() => { context.Validated(); });
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            await Task.Run(() =>
            {
                var identity = new ClaimsIdentity(context.Options.AuthenticationType);

                var encryptedPassword = Cryptor.Encrypt(context.Password);

                var isAuthenticated = SecurityService.Login(context.UserName, encryptedPassword);

                if (isAuthenticated)
                {
                    var roles = SecurityService.GetRoleForUser(context.UserName);

                    AddClaims(roles, ref identity);
                    context.Validated(identity);
                }

                else
                {
                    context.SetError("invalid_grant", "Provided username and password is incorrect");
                }
            });
        }

        /// <summary>
        /// This method is used to add claims to the user. 
        /// Whenever a new user role is added in the system, that user role also needs to be added here if we want to use that role in api.
        /// </summary>
        /// <param name="roles"></param>
        /// <param name="identity"></param>
        private void AddClaims(List<AuthenticationRole> roles, ref ClaimsIdentity identity)
        {
            foreach (var userRole in roles)
            {
                identity.AddClaim(new Claim(ClaimTypes.Role, userRole.RoleName));
                identity.AddClaim(new Claim(ClaimTypes.Name, userRole.RoleName));
                if (userRole.RoleName == EnumUtil.GetEnumDesc(AuthenticationUserRolesEnum.Admin))
                {
                    identity.AddClaim(new Claim(ClaimTypes.Role,
                        Enum.GetName(typeof(AuthenticationUserRolesEnum), AuthenticationUserRolesEnum.Admin)));
                }

                if (userRole.RoleName == EnumUtil.GetEnumDesc(AuthenticationUserRolesEnum.Accounts))
                {
                    identity.AddClaim(new Claim(ClaimTypes.Role,
                        Enum.GetName(typeof(AuthenticationUserRolesEnum), AuthenticationUserRolesEnum.Accounts)));
                }

                if (userRole.RoleName == EnumUtil.GetEnumDesc(AuthenticationUserRolesEnum.DataEntryOperator))
                {
                    identity.AddClaim(new Claim(ClaimTypes.Role,
                        Enum.GetName(typeof(AuthenticationUserRolesEnum),
                            AuthenticationUserRolesEnum.DataEntryOperator)));
                }
            }
        }
    }
}