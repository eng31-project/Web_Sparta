using System;
using System.Security.Cryptography;

namespace UserPortal.Models
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

        public static string HashWithSalt(string password, byte[] salt)
        {
            if (password == null) return "";

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

        /// <summary>
        /// Validates whether the password can be hashed to the corresponding hash
        /// </summary>
        /// <param name="password">Password to validate.</param>
        /// <param name="hash">Hash to validate the password against.</param>
        /// <returns></returns>
        public static bool ValidateHash(string password, string hash)
        {
            byte[] passwordAndSalt = Convert.FromBase64String(hash);
            byte[] salt = new byte[16];

            for (int i = 0; i < salt.Length; i++)
            {
                salt[i] = passwordAndSalt[i];
            }

            if (HashWithSalt(password, salt) == hash)
            {
                return true;
            }

            return false;
        }
    }
}
