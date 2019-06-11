using System;
using System.Security.Cryptography;

namespace hw_108_ASP_Core_Challenge.Classes
{
    public static class Hash
    {
        public static string HashPW(string password)
        {
            if (password == null) return "";

            // hashing and stuff
            /* make a new byte array */
            byte[] salt;

            /* generate salt */
            new RNGCryptoServiceProvider().GetBytes(salt = new byte[16]);

            /* hash and salt it using PBKDF2 */
            var pbkdf2 = new Rfc2898DeriveBytes(password, salt, 10000);

            // place the string in the byte array (that's what getbytes does)
            byte[] hash = pbkdf2.GetBytes(20);

            // make new byte array where to store the hashed password+salt
            // why 36? cause 20 are for the hash and 16 for the salt
            byte[] hashBytes = new byte[36];

            // place the hash and salt in their respective places
            Array.Copy(salt, 0, hashBytes, 0, 16);
            Array.Copy(hash, 0, hashBytes, 16, 20);

            // now, convert our fancy byte array to a string
            return Convert.ToBase64String(hashBytes);
        }
    }
}
