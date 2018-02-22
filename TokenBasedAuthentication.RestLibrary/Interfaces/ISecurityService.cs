namespace TokenBasedAuthentication.RestLibrary.Interfaces
{
    public interface ISecurityService
    {
        string GetToken(string userName, string password);
        string TestForAuthorizedUsers(string token);
        string TestAuthenticatedUsers(string token);

        string TestAutheorizationForUserWithUnauthorizedRole(string token);
    }
}