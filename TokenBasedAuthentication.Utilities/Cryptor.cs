using System;
using System.Security.Cryptography;
using System.Text;

namespace TokenBasedAuthentication.Utilities
{
    public static class Cryptor
    {
        public static string Encrypt(string cleanString)
        {
            //TODO: change the hashing algo to SHA-2
            byte[] clearBytes = new UnicodeEncoding().GetBytes(cleanString);
            byte[] hashedBytes = ((HashAlgorithm) CryptoConfig.CreateFromName("MD5")).ComputeHash(clearBytes);

            return BitConverter.ToString(hashedBytes);
        }
    }
}