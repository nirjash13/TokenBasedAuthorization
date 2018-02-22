using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace AuthenticationServer.Utilities
{
    public static class Cryptor
    {
        public static string Encrypt(string cleanString)
        {
            //TODO: please change the hashing algorithm to SHA-2
            byte[] clearBytes = new UnicodeEncoding().GetBytes(cleanString);
            byte[] hashedBytes = ((HashAlgorithm)CryptoConfig.CreateFromName("MD5")).ComputeHash(clearBytes);

            return BitConverter.ToString(hashedBytes);
        }
    }
}
