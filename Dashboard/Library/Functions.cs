using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace Dashboard.Library
{
    public static class Functions
    {
        public static string MD5Calc(string _original)
        {
            // Create a new String builder to collect the bytes and create a string
            StringBuilder sB = new StringBuilder();
            if (!String.IsNullOrEmpty(_original))
            {
                // Create a new instance of the MD5CryptoServiceProvider object
                MD5 md5Hasher = MD5.Create();
                // Convert the input string to a byte array and compute the hash.
                byte[] data = md5Hasher.ComputeHash(Encoding.Default.GetBytes(_original));

                // Loop through each byte of the hashed data and format each one as a hexadecimal string
                for (int i = 0; i < data.Length; i++)
                {
                    sB.Append(data[i].ToString("x2"));
                }
            }

            // Return the hexadecimal string
            return sB.ToString();
        }
       
        public static string PasswordMD5Calc(string password, int userID, bool alreadyHashed = false)
        {
            if (alreadyHashed)
                return Functions.MD5Calc(password.Trim() + userID.ToString());

            return Functions.MD5Calc(Functions.MD5Calc(password.Trim()) + userID.ToString());
        }

        public static bool IsTokenValid(string authToken, int userId)
        {
            if (String.IsNullOrEmpty(authToken))
                return false;

            return authToken == Functions.MD5Calc(userId.ToString());
        }
    }
}