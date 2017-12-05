using System;
using System.Security.Cryptography;
using System.Text;

namespace FreeezeWebApp.Models.Application.Objects
{
    public static class PasswordHasher
    {
        public static string Hash(string password, string salt)
        {
            StringBuilder builder = new StringBuilder(password.Length + salt.Length);
            builder.Append(password.Substring(0, password.Length / 2));
            builder.Append(salt);
            builder.Append(password.Substring(password.Length / 2 + 1));

            return BitConverter.ToString(new SHA512CryptoServiceProvider().ComputeHash(Encoding.Default.GetBytes(builder.ToString()))).Replace("-", String.Empty).ToUpper();
        }
    }
}